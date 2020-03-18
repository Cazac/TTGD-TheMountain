using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DungeonGenerator is used the generate the TM_Rooms and connect them to each other using the TM_BiomeGenerator values.
/// 
/// </summary>
///////////////

public class TM_DungeonGenerator : MonoBehaviour
{
    ////////////////////////////////

    public static TM_DungeonGenerator Instance;

    ////////////////////////////////

    [Header("Initial Room That The Generator Starts From")]
    public GameObject StartRoom;

    [Header("World Gen Spawn Parent")]
    public GameObject WorldGen_Parent;

    [Header("List Of All Possible Rooms To Spawn Randomly")]
    public List<GameObject> SpawnRooms_StoneDungeon_List;

    [Header("List Of All Doorways That Are Not Connected Yet")]
    private List<TM_Door> AvalibleDoorways_List;
    //public List<TM_Door> UnvalibleDoorways;
    //public List<TM_Door> DoorwaysRemoved_LIST;

    //[Header("Colliders for detecting what biome the spawner is located in")]
    //public List<GameObject> BiomeAreas_List;

    [Header("Variables Controlling the Generator")]
    private int maxRoomAmount = 10;
    private int currentRoomAmount = 0;
    private float generatorWaitSpeed = 0.2f;

    public System.Random seededRandomGen;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    
        //Start the Debug Dungeon Generator
        StartCoroutine(GenerateDungeon()); 
    }

    ///////////////////////////////////////////////////////

    public IEnumerator GenerateDungeon()
    {
        print("Test Code: Starting Dungeon Generator...");

        //Wait for the player to look at the current model
        yield return new WaitForSeconds(generatorWaitSpeed);

        //Reset the Doorway List
        AvalibleDoorways_List = new List<TM_Door>();

        //Add doors from the start room
        AddDoorsFromRoom(StartRoom);

        //CHeck for Alloted room count and doors avalible
        while ((currentRoomAmount <= maxRoomAmount) && (AvalibleDoorways_List.Count > 0))
        {
            //TM_Room oldRoom_SCRIPT = chosenDoor.transform.parent.GetComponent<TM_Room>();       //Owner of the chosen door


            //Get Random Door
            int RandomMax_oldDoor = AvalibleDoorways_List.Count;
            int RandomMin_oldDoor = 0;
            int RandomValue_oldDoor = Random.Range(RandomMin_oldDoor, RandomMax_oldDoor);

            //Get Random Room Prefab
            int RandomMax_Room = SpawnRooms_StoneDungeon_List.Count;
            int RandomMin_Room = 0;
            int RandomValue_Room = Random.Range(RandomMin_Room, RandomMax_Room);

            //Choose Door
            TM_Door oldDoor_SCRIPT = AvalibleDoorways_List[RandomValue_oldDoor];

            //Choose Room
            GameObject oldRoom_GO = SpawnRooms_StoneDungeon_List[RandomValue_Room];

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Instantiate the new room
            GameObject spawnRoom_GO = Instantiate(oldRoom_GO, WorldGen_Parent.transform);

            //Get the Room Script
            TM_Room spawnRoom_SCRIPT = spawnRoom_GO.GetComponent<TM_Room>();

            //Get Random Door
            int RandomMax_spawnDoor = spawnRoom_SCRIPT.doorways_LIST.Count;
            int RandomMin_spawnDoor = 0;
            int RandomValue_spawnDoor = Random.Range(RandomMin_spawnDoor, RandomMax_spawnDoor);

            //Choose Door
            TM_Door spawnDoor_SCRIPT = spawnRoom_SCRIPT.doorways_LIST[RandomValue_spawnDoor];

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Get Connection Dots
            GameObject oldConnectionDot = oldDoor_SCRIPT.doorConnectionSpot;
            GameObject spawnConnectionDot = spawnDoor_SCRIPT.doorConnectionSpot;

            //Get starting rotation and flip it 180 to find the wanted rotation
            Vector3 startingRotation = oldConnectionDot.transform.rotation.eulerAngles;
            startingRotation.y += 180f;

            //Get rotational offset
            Vector3 rotationOffset = startingRotation - spawnConnectionDot.transform.rotation.eulerAngles;

            //Set rotational offset
            spawnRoom_GO.transform.Rotate(rotationOffset);

            //Get positional offset
            Vector3 positionOffset = oldConnectionDot.transform.position - spawnConnectionDot.transform.position;

            //Set positional offset
            spawnRoom_GO.transform.position += positionOffset;


            //Check Colliders


            //Wait 2 Frames so that Physics are calculated

            //Physics.Simulate();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();




            bool hasHitAnyCollider = false;



            foreach (BoxCollider boxCollider in spawnRoom_SCRIPT.roomGenerator_BoxCollider)
            {

                if (boxCollider.GetComponent<TM_RoomCollider>().hasCollided)
                {
                    hasHitAnyCollider = true;
                }

            }

            if (hasHitAnyCollider)
            {
                //print("Test Code: Collision");

                yield return new WaitForSeconds(generatorWaitSpeed);

                //Try Again?

                //Set Inactive, Destroy Later
                spawnRoom_GO.SetActive(false);

                //Set Wall On Door
                oldDoor_SCRIPT.doorWall.SetActive(true);

                //Remove Door Frame
                oldDoor_SCRIPT.doorFrame.SetActive(false);
                oldDoor_SCRIPT.door.SetActive(false);

                //Remove Connection Nodes
                oldDoor_SCRIPT.doorConnectionSpot.SetActive(false);


                //Destory Later
                //Destroy();

                AvalibleDoorways_List.Remove(oldDoor_SCRIPT);
            }
            else
            {
                //print("Test Code: No Collision");

                //Add New Doors To pool
                AddDoorsFromRoom(spawnRoom_GO);

                //Remove Active Door Between The 2 Rooms
                spawnDoor_SCRIPT.door.SetActive(false);

                //Remove Walls On Doors
                oldDoor_SCRIPT.doorWall.SetActive(false);
                spawnDoor_SCRIPT.doorWall.SetActive(false);

                //Remove Connectio Nodes On Doors
                oldDoor_SCRIPT.doorConnectionSpot.SetActive(false);
                spawnDoor_SCRIPT.doorConnectionSpot.SetActive(false);

                //Remove Doors From Spawn Pool
                AvalibleDoorways_List.Remove(oldDoor_SCRIPT);
                AvalibleDoorways_List.Remove(spawnDoor_SCRIPT);

                //Setup Room
                Room_SetTheme(spawnRoom_SCRIPT);

                //Wait for the player to look at the current model (DEBUG)
                yield return new WaitForSeconds(generatorWaitSpeed);

                //Add a room to the counter
                currentRoomAmount++;
            }
            
        }

        //Generate Hallways

        //Remove Remaining Doors
        SealRemainingDoors();

        //Removed Disabled Rooms
        RemoveDisabledRooms();

        print("Test Code: ...Dungeon Generator Has Finished");

        //Return Out Of IEnum
        yield return null;
    }

    ///////////////////////////////////////////////////////

    private void AddDoorsFromRoom(GameObject room)
    {
        //Get Room Script from Gameobject
        TM_Room startRoom_SCRIPT = room.GetComponent<TM_Room>();

        //Get All Doors From Room
        foreach (TM_Door door in startRoom_SCRIPT.doorways_LIST)
        {
            //Add Each Door
            AvalibleDoorways_List.Add(door);
        }
    }

    private void SealRemainingDoors()
    {
        foreach (TM_Door door in AvalibleDoorways_List)
        {
            //Set Wall On Door
            door.doorWall.SetActive(true);

            //Remove Door Frame / Door
            door.doorFrame.SetActive(false);
            door.door.SetActive(false);

            //Remove Connection Nodes
            door.doorConnectionSpot.SetActive(false);


            //Add To Sealed door list ???

        }
    }

    private void RemoveDisabledRooms()
    {
        //Loop All Spawned Rooms
        foreach (Transform disabledRoom in WorldGen_Parent.transform)
        {
            //Look For Disabled Rooms
            if (disabledRoom.gameObject.activeSelf == false)
            {
                //Destroy Them
                Destroy(disabledRoom.gameObject);
            }
        }
    }

    public void SetupRandomGenerator()
    {
        //Get a controlable random Value
        int randomValue = Random.Range(0, 100);

        print("Test Code: Generating New Randomizer Using " + randomValue);

        //Set seeded random generator for the class
        seededRandomGen = new System.Random(randomValue);

        //How to use
        //int newNumber = seededRandomGen.Next(0, 100);
    }

    ///////////////////////////////////////////////////////

    public void Room_SetTheme(TM_Room newRoom)
    {
        //Get Random Theme
        int RandomMax_Theme = newRoom.themes_LIST.Count;
        int RandomMin_Theme = 0;
        int RandomValue_Theme = Random.Range(RandomMin_Theme, RandomMax_Theme);

        //Choose Theme
        TM_Theme selectedTheme_Script = newRoom.themes_LIST[RandomValue_Theme];

        //Activate Theme Gameobejct
        selectedTheme_Script.gameObject.SetActive(true);

        //Set Nodes
        Room_SetLootNodes(selectedTheme_Script);
        Room_SetChestNodes();
        Room_SetResourceNodes();
        Room_SetMonsterNodes();
    }

    public void Room_SetLootNodes(TM_Theme theme)
    {
        foreach (Transform nodeTransform in theme.LootNodes_Parent.transform)
        {
            TM_LootNode lootNode = nodeTransform.gameObject.GetComponent<TM_LootNode>();

            //DEBUG REMOVAL
            nodeTransform.gameObject.SetActive(false);
        }
    }

    public void Room_SetChestNodes()
    {

    }

    public void Room_SetResourceNodes()
    {

    }

    public void Room_SetMonsterNodes()
    {

    }

    ///////////////////////////////////////////////////////
}
