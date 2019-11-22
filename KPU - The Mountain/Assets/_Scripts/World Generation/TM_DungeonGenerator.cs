using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_DungeonGenerator : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject EndRoom;
    public GameObject MiddleRoom;

    public List<TM_Door> AvalibleDoorways;
    public List<TM_Door> UnvalibleDoorways;

    //Needed?
    public List<TM_Door> DoorwaysRemoved_LIST;



    public List<GameObject> SpawnRooms_LIST;



    public List<GameObject> BiomeAreas_List;


    public int maxRoomAmount = 5;
    public int currentRoomAmount = 0;


    public float generatorWaitSpeed = 1.0f;


    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //PlaceARoom();



        //Dicking around with random seed gens



        System.Random rand;
        float newNum;

        rand = new System.Random(5);

        newNum = rand.Next(0, 100);

        //print("Test Code: FIrst " + newNum);

        newNum = rand.Next(0, 100);

        //print("Test Code: FIrst " + newNum);





        rand = new System.Random(600);

        newNum = rand.Next(0, 100);

        //print("Test Code: Second " + newNum);

        newNum = rand.Next(0, 100);

        //print("Test Code: Second " + newNum);




        /*
        //float afa = Mathf.PerlinNoise(100, 200);


        Random random = new Random();

        int seed = 111111;

        Random mySeededRandom = new Random(seed);
        value1 = mySeededRandom(0, 10); //will always be 3
        value2 = mySeededRandom(0, 10); //will always be 1
        value3 = mySeededRandom(0, 10); //will always be 8

        */
    }

    ///////////////////////////////////////////////////////

    public void Button_ResetGenerator()
    {
        //Remove Old Dungeon



        //Slowly Generate New Dungeon
        StartCoroutine(GenerateDungeon());
    }

    ///////////////////////////////////////////////////////

    public IEnumerator GenerateDungeon()
    {
        print("Test Code: Starting Dungeon Generator");

        //Wait for the player to look at the current model
        yield return new WaitForSeconds(generatorWaitSpeed);


        AvalibleDoorways = new List<TM_Door>();

        AddDoorsFromRoom(StartRoom);




        while  ( (currentRoomAmount <= maxRoomAmount) && (AvalibleDoorways.Count > 0) )
        {
    
            //Get Random Door
            int RandomMax_Door = AvalibleDoorways.Count;
            int RandomMin_Door = 0;
            int RandomValue_Door = Random.Range(RandomMin_Door, RandomMax_Door);

            //Choose Door
            TM_Door chosenDoor = AvalibleDoorways[RandomValue_Door];


            //Get distance From Start Room to new Doorway
            //float DoorDistance = Vector3.Distance(StartRoom.transform.position, chosenDoor.gameObject.transform.position);


            //Get Random Room Prefab
            int RandomMax_Room = SpawnRooms_LIST.Count;
            int RandomMin_Room = 0;
            int RandomValue_Room = Random.Range(RandomMin_Room, RandomMax_Room);


            //Choose Room Prefab
            GameObject chosenRoom = SpawnRooms_LIST[RandomValue_Room];




            ///////////////////////////////////////////////////////////////////////////////////////////////////////



            //Instantiate the new room
            GameObject newRoom = Instantiate(chosenRoom);



            TM_Room newRoom_SCRIPT = newRoom.GetComponent<TM_Room>();



            GameObject newRoomDoor = newRoom_SCRIPT.doorways_LIST[0].gameObject;

            //Get starting rotation and flip it 180 to find the wanted rotation
            Vector3 startingRotation = chosenDoor.transform.rotation.eulerAngles;
            startingRotation.y += 180f;


        }




        print("Test Code: Dungeon Generator Has Finished");


        yield return null;
    }

    ///////////////////////////////////////////////////////

    private void AddDoorsFromRoom(GameObject room)
    {
        TM_Room startRoom_SCRIPT = room.GetComponent<TM_Room>();


        foreach (TM_Door door in startRoom_SCRIPT.doorways_LIST)
        {
            //Add All Doors
            AvalibleDoorways.Add(door);
        }

        

    }

    public void PlaceARoom()
    {


        //          //          // - Randomize the room choice


        //Instantiate the new room
        GameObject newRoom = Instantiate(MiddleRoom);

        //Get the Room Scripts from the gameobjects
        TM_Room startRoom_SCRIPT = StartRoom.GetComponent<TM_Room>();
        TM_Room newRoom_SCRIPT = newRoom.GetComponent<TM_Room>();



        //          //          // - Randomize the door choice


        //Get the connecting doors
        GameObject startingDoor = newRoom_SCRIPT.doorways_LIST[0].gameObject;
        GameObject newRoomDoor = startRoom_SCRIPT.doorways_LIST[0].gameObject;

        //Get starting rotation and flip it 180 to find the wanted rotation
        Vector3 startingRotation = startingDoor.transform.rotation.eulerAngles;
        startingRotation.y += 180f;

        //Get rotational offset
        Vector3 rotationOffset = startingRotation - newRoomDoor.transform.rotation.eulerAngles;

        //Set rotational offset
        newRoom.transform.Rotate(rotationOffset);

        //Get positional offset
        Vector3 positionOffset = startingDoor.transform.position - newRoomDoor.transform.position;

        //Set positional offset
        newRoom.transform.position += positionOffset;


        //          //          // - Next Iteration


        //          //          // - Remove Doors

    }

    public void ConnectRooms()
    {

    }

    public void SetupRandomGenerator()
    {
        int randomValue = Random.Range(0, 100);

        print("Test Code: Generating New Randomizer Using " + randomValue);

        System.Random randomGenerator = new System.Random(randomValue);
    }

    public void SpawnBiomeAreas()
    {

    }

    ///////////////////////////////////////////////////////
}
