using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    [Header("Generation Spawn Container")]
    public GameObject WorldGen_Container;

    ////////////////////////////////

    [Header("Initial Room That The Generator Starts From")]
    public TM_RoomContainer startingRoom_Room;

    ////////////////////////////////

    [Header("List Of All Possible Rooms To Spawn Randomly")]
    public List<GameObject> spawnableRooms_List;

    [Header("List Of Counts Of Spawned Rooms")]
    List<int> spawnableRoomsCount_List;

    ////////////////////////////////

    [Header("Variables Controlling the Generator")]
    private int maxRoomAmount = 15;
    private int currentRoomAmount = 0;
    private float generatorWaitSpeed = 0.2f;

    [Header("List Of All Doorways That Are Not Connected Yet")]
    private List<TM_DoorwayTab> avalibleDoorways_List;

    ////////////////////////////////

    //public List<TM_Door> UnvalibleDoorways;
    //public List<TM_Door> DoorwaysRemoved_LIST;
    //[Header("Colliders for detecting what biome the spawner is located in")]
    //public List<GameObject> BiomeAreas_List;


    //public System.Random seededRandomGen;

    public bool hasNavMeshBeenBuilt;

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
        avalibleDoorways_List = new List<TM_DoorwayTab>();
        spawnableRoomsCount_List = new List<int>();

        //Add Default Room Spawn Rates
        for (int i = 0; i < spawnableRooms_List.Count; i++)
        {
            //Starting Value Of 1
            spawnableRoomsCount_List.Add(1);
        }

        //Add doors from the start room
        AddDoorsFromRoom(startingRoom_Room);

        //Check for Alloted room count and doors avalible
        while ((currentRoomAmount <= maxRoomAmount) && (avalibleDoorways_List.Count > 0))
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Get Random Door
            TM_DoorwayTab avalibleDoor_Doorway = GetRandomDoorway_Avalible();

            //Get Random Room
            int currentRoomNo = GetRandomRoom();  
            GameObject nextRoom_GO = spawnableRooms_List[currentRoomNo];

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Instantiate the new room
            GameObject spawnedRoom_GO = Instantiate(nextRoom_GO, WorldGen_Container.transform);

            //Get the Room Script
            TM_RoomContainer spawnedRoom_Room = spawnedRoom_GO.GetComponent<TM_RoomContainer>();

            //Get the Doorway Script
            TM_DoorwayTab spawnedDoor_Doorway = GetRandomDoorway_Room(spawnedRoom_Room);


            //GET DOOR TPYE

            //MANUALLY SET FOR NOW






            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Get Connection Dots
            GameObject avalibleConnectionDot = avalibleDoor_Doorway.doorFrame_Small.doorConnectionSpot;
            GameObject spawnedConnectionDot = spawnedDoor_Doorway.doorFrame_Small.doorConnectionSpot;

            //Get starting rotation and flip it 180 to find the wanted rotation
            Vector3 startingRotation = avalibleConnectionDot.transform.rotation.eulerAngles;
            startingRotation.y += 180f;

            //Get rotational offset
            Vector3 rotationOffset = startingRotation - spawnedConnectionDot.transform.rotation.eulerAngles;

            //Set rotational offset
            spawnedRoom_GO.transform.Rotate(rotationOffset);

            //Get positional offset
            Vector3 positionOffset = avalibleConnectionDot.transform.position - spawnedConnectionDot.transform.position;

            //Set positional offset
            spawnedRoom_GO.transform.position += positionOffset;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            //Wait 2 Frames so that Physics Simulations are calculated then Check Colliders
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            //Create Bool For Checking a breakout Value
            bool hasHitAnyCollider = false;

            //Loop All Colliders of the spawned room
            foreach (TM_RoomCollider generationCollider in spawnedRoom_Room.generationColliderContainer.generationColliders_List)
            {
                //Check For Collision with Other Colliders
                if (generationCollider.hasCollided)
                { 
                    //Set Break Out Bool
                    hasHitAnyCollider = true;
                    break;
                }
            }

            //Check For Collision
            if (hasHitAnyCollider)
            {
                //Debug Visuals Of Generation
                //yield return new WaitForSeconds(generatorWaitSpeed);

                //Set Inactive, Will Be Destroyed Later
                spawnedRoom_GO.SetActive(false);

                //Set Wall On Door
                avalibleDoor_Doorway.doorFrame_Wall.SetActive(true);

                //Remove Door And Connection Nodes
                avalibleDoor_Doorway.doorFrame_Small.gameObject.SetActive(false);
                avalibleDoor_Doorway.doorExit_Small.gameObject.SetActive(false);


                //Destory Later, Try Again ???



                //Door Did Not Spawn, Remove it
                avalibleDoorways_List.Remove(avalibleDoor_Doorway);
            }
            else
            {
                //Add New Doors To Avalible Doors Pool
                AddDoorsFromRoom(spawnedRoom_Room);

                //Set Doors
                avalibleDoor_Doorway.doorFrame_Small.gameObject.SetActive(true);
                avalibleDoor_Doorway.doorExit_Small.gameObject.SetActive(false);

                //Set Doors
                spawnedDoor_Doorway.doorFrame_Small.gameObject.SetActive(false);
                spawnedDoor_Doorway.doorExit_Small.gameObject.SetActive(true);

                //Remove Walls
                avalibleDoor_Doorway.doorFrame_Wall.SetActive(false);
                spawnedDoor_Doorway.doorFrame_Wall.SetActive(false);

                //Remove Connection Nodes On Door
                avalibleDoor_Doorway.doorFrame_Small.doorConnectionSpot.SetActive(false);

                //Remove Doors From Spawn Pool
                avalibleDoorways_List.Remove(avalibleDoor_Doorway);
                avalibleDoorways_List.Remove(spawnedDoor_Doorway);

                //Succeded, Increase Room Type count for spawnrate
                spawnableRoomsCount_List[currentRoomNo] += 1;

                //Wait for the player to look at the current model (DEBUG)
                //yield return new WaitForSeconds(generatorWaitSpeed);


                //Add a room to the counter
                currentRoomAmount++;
            }
        }

        //Generate Hallways






        //Remove Remaining Doors
        SealRemainingDoors();

        //Removed Disabled Rooms
        RemoveDisabledRooms();

        //Setup Rooms
        Room_Setup();

        //Allow Player To Play
        TM_PlayerMenuController_Intro.Instance.StartFadeOutAnimation();


        print("Test Code: ...Dungeon Generator Has Finished");

        //Return Out Of IEnum
        yield return null;
    }

    ///////////////////////////////////////////////////////

    private void AddDoorsFromRoom(TM_RoomContainer newRoom_Room)
    {
        //Get All Doors From Room
        foreach (TM_DoorwayTab doorway in newRoom_Room.doorContainer.doorwayTabs_List)
        {
            //Add Each Door To Avalible Dooways
            avalibleDoorways_List.Add(doorway);
        }
    }

    private void SealRemainingDoors()
    {
        foreach (TM_DoorwayTab doorwayTab in avalibleDoorways_List)
        {
            //Set Wall
            doorwayTab.doorFrame_Wall.SetActive(true);

            //Remove Doors
            doorwayTab.doorFrame_Small.gameObject.SetActive(false);




            //Add To Sealed door list ???
        }
    }

    private void RemoveDisabledRooms()
    {
        //Loop All Spawned Rooms
        foreach (Transform disabledRoom in WorldGen_Container.transform)
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
        //int randomValue = Random.Range(0, 100);

        //print("Test Code: Generating New Randomizer Using " + randomValue);

        //Set seeded random generator for the class
        //seededRandomGen = new System.Random(randomValue);

        //How to use
        //int newNumber = seededRandomGen.Next(0, 100);
    }

    ///////////////////////////////////////////////////////

    private void Room_Setup()
    {
        print("Test Code: Building Surface Nav Mesh");

        TM_PlayerMenuController_Intro.Instance.GetComponent<NavMeshSurface>().BuildNavMesh();
        hasNavMeshBeenBuilt = true;

        foreach (Transform roomGO in WorldGen_Container.transform)
        {
            TM_RoomContainer currentRoom_Room = roomGO.GetComponent<TM_RoomContainer>();

            //Set Nodes
            Room_SetLootNodes(currentRoom_Room);
            Room_SetEnemyNodes(currentRoom_Room);
            Room_SetResourceNodes(currentRoom_Room);


            if (currentRoom_Room.roomRangeActivator != null)
            {
                //Refreash Range Actiavation
                currentRoom_Room.roomRangeActivator.RefreshFromRange();
            }
        }
    }

    public void Room_SetLootNodes(TM_RoomContainer room)
    {
        foreach (TM_ItemSpawnPointTab itemSpawn in room.itemSpawnContainer.itemSpawnTabs_List)
        {
            TM_Item_SO itemSO = itemSpawn.itemSpawn_LootTable.GetLootDrop();

            if (itemSO != null)
            {
                GameObject placedItem = Instantiate(itemSO.placed_Prefab, room.itemSpawnContainer.itemSpawnContainer_GO.transform);
                placedItem.transform.position = itemSpawn.transform.position;
            }
        }

        foreach (Transform child in room.itemSpawnContainer.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Room_SetResourceNodes(TM_RoomContainer room)
    {

    }

    public void Room_SetEnemyNodes(TM_RoomContainer room)
    {

    }

    ///////////////////////////////////////////////////////

    public int GetRandomRoom()
    {

        List<float> spawnableRoomsRate_List = new List<float>();
       
        float totalValue = 0;
        float currentValue = 0;


        foreach (int roomCount in spawnableRoomsCount_List)
        {
            float spawnRate = Mathf.Pow(0.8f, roomCount);
            spawnableRoomsRate_List.Add(spawnRate);
   
        }

        foreach (float roomSpawnValue in spawnableRoomsRate_List)
        {
            totalValue += roomSpawnValue;
        }



        float randomValue = Random.Range(0f, totalValue);



        for (int i = 0; i < spawnableRooms_List.Count; i++)
        {
            currentValue += spawnableRoomsRate_List[i];

            if (currentValue >= randomValue)
            {
                //Yay
                return i;
            }
        }




        print("Test Code: Error");

        return 0;
    }

    public TM_DoorwayTab GetRandomDoorway_Avalible()
    {
        TM_DoorwayTab doorwayTab = avalibleDoorways_List[Random.Range(0, avalibleDoorways_List.Count)];
        return doorwayTab;
    }

    public TM_DoorwayTab GetRandomDoorway_Room(TM_RoomContainer room)
    {
        //Get Random Door From Room
        TM_DoorwayTab doorwayTab = room.doorContainer.doorwayTabs_List[Random.Range(0, room.doorContainer.doorwayTabs_List.Count)];
        return doorwayTab;
    }




    ///////////////////////////////////////////////////////
}
