using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TM_SceneChangeCollision : MonoBehaviour
{

    [Header("Scene")]
    public Scene sceneChange;

    [Header("Location?")]
    public int location;


    private void OnTriggerEnter(Collider collider)
    {


        print("Test Code: Change Scene!");

        //SceneManager.LoadScene(sceneChange.name);
    }


}
