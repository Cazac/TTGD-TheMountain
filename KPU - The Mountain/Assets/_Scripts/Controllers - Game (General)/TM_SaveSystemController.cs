using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_SaveSystemController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_SaveSystemController Instance;

    ////////////////////////////////


    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }



 

}
