using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TM_BurnableItemTab : MonoBehaviour, IPointerClickHandler
{






    ///////////////////////////////////////////////////////

    private void Awake()
    {
        
    }

    ///////////////////////////////////////////////////////



    public void OnPointerClick(PointerEventData eventData)
    {
        TM_PlayerMenuController_Fire.Instance.Button_SelectBurnable(this);


    }



    ///////////////////////////////////////////////////////
}
