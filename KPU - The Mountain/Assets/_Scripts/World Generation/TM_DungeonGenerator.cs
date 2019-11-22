using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DungeonGenerator 
/// 
/// </summary>
///////////////

public class TM_DungeonGenerator : MonoBehaviour
{
    ////////////////////////////////

    //Set as Controller?

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
    private int maxRoomAmount = 8;
    private int currentRoomAmount = 0;
    private float generatorWaitSpeed = 1.0f;

    public System.Random seededRandomGen;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Start the Debug Dungeon Generator
        StartCoroutine(GenerateDungeon()); 
    }

    ///////////////////////////////////////////////////////

    public IEnumerator GenerateDungeon()
    {
        print("Test Code: Starting Dungeon Generator");

        //Wait for the player to look at the current model
        yield return new WaitForSeconds(generatorWaitSpeed);

        //Reset the Doorway List
        AvalibleDoorways_List = new List<TM_Door>();

        //Add doors from the start room
        AddDoorsFromRoom(StartRoom);



        //CHeck for Alloted room count and doors avalible
        while ((currentRoomAmount <= maxRoomAmount) && (AvalibleDoorways_List.Count > 0))
        {
    
            //Get Random Door
            int RandomMax_Door = AvalibleDoorways_List.Count;
            int RandomMin_Door = 0;
            int RandomValue_Door = Random.Range(RandomMin_Door, RandomMax_Door);

            //Get Random Room Prefab
            int RandomMax_Room = SpawnRooms_StoneDungeon_List.Count;
            int RandomMin_Room = 0;
            int RandomValue_Room = Random.Range(RandomMin_Room, RandomMax_Room);

            //Choose Door
            TM_Door oldDoor_SCRIPT = AvalibleDoorways_List[RandomValue_Door];

            //Choose Room
            GameObject oldRoom_GO = SpawnRooms_StoneDungeon_List[RandomValue_Room];

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Instantiate the new room
            GameObject spawnRoom_GO = Instantiate(oldRoom_GO, WorldGen_Parent.transform);

            //Get the Room Scripts from the gameobjects
            //TM_Room oldRoom_SCRIPT = chosenDoor.transform.parent.GetComponent<TM_Room>();       //Owner of the chosen door
            TM_Room spawnRoom_SCRIPT = spawnRoom_GO.GetComponent<TM_Room>();
            TM_Door spawnDoor_SCRIPT = spawnRoom_SCRIPT.doorways_LIST[0];



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


            //if ()




            //Add New Doors To pool
            AddDoorsFromRoom(spawnRoom_GO);

            //Set Active Door Between The 2 Rooms
            //oldDoor_SCRIPT.doorFrame.SetActive(true);
            //spawnDoor_SCRIPT.doorWall.SetActive(false);

            //Remove Walls On Doors
            oldDoor_SCRIPT.doorWall.SetActive(false);
            spawnDoor_SCRIPT.doorWall.SetActive(false);

            //Remove Connectio Nodes On Doors
            //oldDoor_SCRIPT.doorConnectionSpot.SetActive(false);
            //spawnDoor_SCRIPT.doorConnectionSpot.SetActive(false);

            //Remove Doors From Spawn Pool
            AvalibleDoorways_List.Remove(oldDoor_SCRIPT);
            AvalibleDoorways_List.Remove(spawnDoor_SCRIPT);

            //Set Frame 1*
            //Set Walls

   


            //          //          // - Randomize the door choice





            //          //          // - Next Iteration


            //          //          // - Remove Doors



            //Wait for the player to look at the current model
            yield return new WaitForSeconds(generatorWaitSpeed);

            //Add a room to the counter
            currentRoomAmount++;
        }


        SealRemainingDoors();

        print("Test Code: Dungeon Generator Has Finished");

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

            //Remove Door Frame
            door.doorFrame.SetActive(false);

            //Remove Connection Nodes
            door.doorConnectionSpot.SetActive(false);


            //Add To Sealed door list ???

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
}
