﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Serialization;

public class Player_Manager : MonoBehaviour
{

    // The weapon the player has.
    public GameObject MainHandWeapon;

    void Start()
    {
        Save();
        SpawnSavedItem();
    }

    void OnDestroy()
    {

    }

    public void Save()
    {
        float test = 50;

        Debug.Log(Application.persistentDataPath);

        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(Application.persistentDataPath + "/TestFireSave.dat");

        // Create a new Player_Data.
        Player_Data data = new Player_Data();

        //Save the data.
        data.weapon = MainHandWeapon;
        data.baseDamage = test;
        data.baseHealth = test;
        data.currentHealth = test;
        data.baseMana = test;
        data.currentMana = test;
        data.baseMoveSpeed = test;

        //Serialize to xml
        DataContractSerializer bf = new DataContractSerializer(data.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serialize the file
        bf.WriteObject(streamer, data);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();

        string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
        Debug.Log("Serialized Result: " + result);

    }

    public void SpawnSavedItem()
    {
        //TextReader reader = new StreamReader(Application.persistentDataPath + "/TestFireSave.dat");

        //if (reader != null)
        {
            //print("Test Code: Not Null");
            Load(Application.persistentDataPath + "/TestFireSave.dat");
        }
        //else
        {
            //print("Test Code: Null");
        }

    }


    void Load(string filename)
    {




        XmlSerializer serializer = new XmlSerializer(typeof(Player_Manager));
        //TextReader reader = new StreamReader(filename);



        //Player_Manager buildingInfo = serializer.Deserialize(reader) as Player_Manager;



        //GameObject Test = Instantiate(buildingInfo.MainHandWeapon);

        //Player_Manager.reload(rootObject);
        //reader.Close();
        print("Objects loaded from XML file\n");
    }
}


[DataContract]
class Player_Data
{
    [DataMember]
    private GameObject _weapon;

    public GameObject weapon
    {
        get { return _weapon; }
        set { _weapon = value; }
    }

    [DataMember]
    public float baseDamage;
    [DataMember]
    public float baseHealth;
    [DataMember]
    public float currentHealth;
    [DataMember]
    public float baseMana;
    [DataMember]
    public float currentMana;
    [DataMember]
    public float baseMoveSpeed;
}