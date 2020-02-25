using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TM_BurnableItemTab : MonoBehaviour, IPointerClickHandler
{




    public TM_ItemUI_Base currentBurnableItem;

    public TextMeshProUGUI itemName_Text;
    public TextMeshProUGUI itemCount_Text;
    public Image itemIcon_Image;


    ///////////////////////////////////////////////////////

    private void Awake()
    {
        
    }

    ///////////////////////////////////////////////////////


    public void RefreshTab()
    {
        //Fill Out Info
        itemName_Text.text = currentBurnableItem.ItemName;
        itemCount_Text.text = "x " + currentBurnableItem.CurrentStackSize.ToString();
        itemIcon_Image.sprite = currentBurnableItem.ItemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TM_PlayerMenuController_Fire.Instance.Button_SelectBurnable(this);


    }



    ///////////////////////////////////////////////////////
}
