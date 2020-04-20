using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

///////////////
/// <summary>
///     
/// TM_ItemSlot_Basic 
/// 
/// </summary>
///////////////

public class TM_ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    ////////////////////////////////

    [Header("Slot Type")]
    public bool isDisabledSlot;

    [Header("Slot Type")]
    public bool isCursorSlot;
    public bool isInventorySlot;
    public bool isToolbarSlot;
    public bool isContainerSlot;

    [Header("Equipment Slot Type")]
    public bool isEquipHeadSlot;
    public bool isEquipNecklaceSlot;
    public bool isEquipTorsoSlot;
    public bool isEquipArmSlot;
    public bool isEquipLegsSlot;
    public bool isEquipFeetSlot;
    public bool isEquipRingSlot;

    [Header("Single Item Slot Type")]
    public bool isSingleTypeSlot;
    public TM_Item_SO singleTypeItemSO;

    [Header("Home Menu Slot Type")]
    public bool isForgeInputSlot;
    public bool isForgeMatSlot;
    public bool isForgeOutputLeftSlot;
    public bool isForgeOutputRightSlot;

    ////////////////////////////////

    //[Header("Current Item Selected")]
    private TM_ItemUI currentItem { get; set; }

    ////////////////////////////////

    [Header("Slot Icon")]
    public Image slotIcon;

    [Header("Slot Fade Icon")]
    public Image slotFadeIcon;

    [Header("Slot Durablity")]
    public GameObject slotDurablityBar_GO;
    public Image slotDurablityFillBar_Image;

    [Header("Slot Stack Size")]
    public GameObject slotStackSize_GO;
    public TextMeshProUGUI slotStackSize_Text;

    ////////////////////////////////

    //public TM_ItemUI_Base currentSlotItem;

    ///////////////////////////////////////////////////////

    private void Start()
    {
        //Debug Spawning
        //SpawnRandomDebugItem();
    }

    ///////////////////////////////////////////////////////

    public void OnPointerClick(PointerEventData eventData)
    {
        //Check Slot Disabled Status
        if (isDisabledSlot)
        {
            print("Test Code: Disabled");
            return;
        }

        //Look For Mouse Click Type
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Look for Shift / CTRL / Default
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Try To Quick Move Stack
                TryAction_QuickmoveStack();
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                // ???

            }
            else
            {
                //Try To Select
                TryAction_Select();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            // ???

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Right Click
            TryAction_DetachSingle();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Create ToolTip
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Remove ToolTip
    }

    ///////////////////////////////////////////////////////

    public TM_ItemUI ItemSlot_GetItem()
    {
        //Return Current Item
        return currentItem;
    }

    public void ItemSlot_SetItem(TM_ItemUI newItem)
    {
        //Check for an Empty Stack
        if (newItem.currentStackSize <= 0)
        {
            //Remove Item
            ItemSlot_RemoveItem();
            return;
        }

        //Set Item
        currentItem = newItem;

        //Set Sprite
        slotIcon.gameObject.SetActive(true);
        slotIcon.sprite = currentItem.itemIcon;

        //Update UI
        ItemSlot_UpdateItem();
    }

    public void ItemSlot_SetItemFade(Sprite newFadeIcon)
    {
        if (slotFadeIcon != null)
        {
            if (newFadeIcon != null)
            {
                slotFadeIcon.gameObject.SetActive(true);
                slotFadeIcon.sprite = newFadeIcon;
            }
            else
            {
                slotFadeIcon.gameObject.SetActive(false);
            }
        }
        else
        {
            print("Test Code: Error, Fade Icon Was Not Set!");
        }
    }

    public void ItemSlot_DupplicateItem(TM_ItemUI orignalItem)
    {
        //Deep Copy the Item
        currentItem = new TM_ItemUI(orignalItem);

        //Set Item
        ItemSlot_SetItem(currentItem);
    }

    public void ItemSlot_RemoveItem()
    {
        //Clear Values
        currentItem = null;
        slotIcon.sprite = null;
        slotStackSize_Text.text = "";
        slotIcon.gameObject.SetActive(false);
        slotDurablityBar_GO.SetActive(false);
        slotStackSize_GO.SetActive(false);
    }

    public void ItemSlot_UpdateItem()
    {
        //Check for an Empty Stack
        if (currentItem.currentStackSize <= 0)
        {
            //Remove Item
            ItemSlot_RemoveItem();
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_RefreshCurrent();
            return;
        }

        //Durablity
        if (currentItem.maxDurablity > 0)
        {
            //Turn On Durablity and Fill Bar
            slotDurablityBar_GO.SetActive(true);
            //slotDurablityFillBar_Image.fillAmount = (float)currentItem.currentDurablity / currentItem.maxDurablity;
        }
        else
        {
            //Turn Off Durablity and Reset Bar
            slotDurablityBar_GO.SetActive(false);
            //slotDurablityFillBar_Image.fillAmount = 1;
        }

        //Max Stack Size
        if (currentItem.maxStackSize > 0)
        {
            //Turn On Durablity and Set Text
            slotStackSize_GO.SetActive(true);

            if (currentItem.currentStackSize == currentItem.maxStackSize)
            {
                //Set Full Stack Color
                slotStackSize_Text.text = "<color=#ffff00>" + currentItem.currentStackSize.ToString() + "</color>";
            }
            else
            {
                //Set Default White
                slotStackSize_Text.text = currentItem.currentStackSize.ToString();
            }
        }
        else
        {
            //NOT RIGHT


            //Turn Off Stack Icon and Reset Text
            slotStackSize_GO.SetActive(true);
            slotStackSize_Text.text = "1";
        }

        TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_RefreshCurrent();
    }

    public void ItemSlot_DropItemAll()
    {
        //Check For Item
        if (currentItem != null)
        {
            //Create a position infront of the player
            Vector3 spawnPosition = TM_PlayerController_Movement.Instance.gameObject.transform.position;
            spawnPosition += TM_PlayerController_Movement.Instance.gameObject.transform.forward * -3;
            spawnPosition.y += 1;

            //Add Jitter
            spawnPosition += TM_PlayerController_Movement.Instance.gameObject.transform.right * Random.Range(-0.1f, 0.1f);

            //Spawn Item as Dropped
            GameObject newObject = Instantiate(currentItem.original_SO.dropped_Prefab, spawnPosition, Quaternion.identity);

            //Set Stacksize and Durablity 
            newObject.GetComponent<TM_ItemDropped>().currentStackSize = currentItem.currentStackSize;
            newObject.GetComponent<TM_ItemDropped>().currentDurablity = currentItem.currentDurablity;

            //Remove Stack From UI
            TM_CursorController.Instance.Cursor_RemoveItem();
        }
    }

    public void ItemSlot_DropItemSingle()
    {
        //Check For Item
        if (currentItem != null)
        {
            //Create a position infront of the player
            Vector3 spawnPosition = TM_PlayerController_Movement.Instance.gameObject.transform.position;
            spawnPosition += TM_PlayerController_Movement.Instance.gameObject.transform.forward * -3;
            spawnPosition.y += 1;

            //Add Jitter
            spawnPosition += TM_PlayerController_Movement.Instance.gameObject.transform.right * Random.Range(-0.1f, 0.1f);

            //Spawn Item as Dropped
            GameObject newObject = Instantiate(currentItem.original_SO.dropped_Prefab, spawnPosition, Quaternion.identity);

            //Set Stacksize and Durablity 
            newObject.GetComponent<TM_ItemDropped>().currentStackSize = 1;
            newObject.GetComponent<TM_ItemDropped>().currentDurablity = currentItem.currentDurablity;

            //Remove Single Item From UI
            currentItem.currentStackSize--;

            //Update UI
            ItemSlot_UpdateItem();
        }
    }

    public void ItemSlot_Disable()
    {
        isDisabledSlot = true;

        if (isInventorySlot || isToolbarSlot)
        {
            gameObject.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        }
    }

    public void ItemSlot_Enable()
    {
        isDisabledSlot = false;

        if (isInventorySlot || isToolbarSlot)
        {
            gameObject.GetComponent<Image>().color = new Color32(170, 170, 170, 255);
        }
        else 
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    ///////////////////////////////////////////////////////

    public void TryAction_DetachHalf()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_PlaceSingle();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                    {
                        //Attempt To Merge Stacks
                        Action_PickupSingle();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_PickupSingle();
                }
            }
        }
        else if (isToolbarSlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_PlaceSingle();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                    {
                        //Attempt To Merge Stacks
                        Action_PickupSingle();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_PickupSingle();
                }
            }
        }
        else
        {
            print("Test Code: Oops, you forgot to set a slot tag!");
        }
    }

    public void TryAction_DetachSingle()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_PlaceSingle();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                    {
                        //Attempt To Merge Stacks
                        Action_PickupSingle();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_PickupSingle();
                }
            }
        }
        else if (isToolbarSlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_PlaceSingle();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                    {
                        //Attempt To Merge Stacks
                        Action_PickupSingle();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_PickupSingle();
                }
            }
        }
        else
        {
            print("Test Code: Oops, you forgot to set a slot tag!");
        }
    }

    public void TryAction_SplitStack()
    {

        //cursor

        //Target





    }

    public void TryAction_QuickmoveStack()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Attempt a Quickstack if failed no Action
            if (!Action_QuickStack(TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array))
            {
                Action_NoAction();
            }
        }
        else if (isToolbarSlot)
        {
            if (TM_PlayerMenuController_UI.Instance.Forge_Panel.activeSelf)
            {
                //Attempt a Quickstack if failed no Action
                if (!Action_QuickStack(TM_HomeMenuController_Forge.Instance.forge_PlayerItemSlots_Array))
                {
                    Action_NoAction();
                }
            }
            else  if (TM_PlayerMenuController_UI.Instance.Brewery_Panel.activeSelf)
            {
                return;
            }
            else  if (TM_PlayerMenuController_UI.Instance.Dispenser_Panel.activeSelf)
            {
                return;
            }
            else  if (TM_PlayerMenuController_UI.Instance.Storage_Panel.activeSelf)
            {
                return;
            }
            else  if (TM_PlayerMenuController_UI.Instance.Workshop_Panel.activeSelf)
            {
                return;
            }
            else
            {
                //Attempt a Quickstack if failed no Action
                if (!Action_QuickStack(TM_PlayerMenuController_Inventory.Instance.playerItemSlots_Array))
                {
                    Action_NoAction();
                }
            }
        }
    }

    public void TryAction_Select()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Inventory
            SelectType_IsInventory();
        }
        else if (isToolbarSlot)
        {
            //Toolbar
            SelectType_IsToolbarSlot();
        }
        else if (isEquipHeadSlot)
        {
            //Head
            SelectType_IsEquipHeadSlot();
        }
        else if (isEquipNecklaceSlot)
        {

        }
        else if (isEquipTorsoSlot)
        {
            //Torso
            SelectType_IsEquipTorsoSlot();
        }
        else if (isEquipArmSlot)
        {
            //Arms
            SelectType_IsEquipArmSlot();
        }
        else if (isEquipLegsSlot)
        {
            //Legs
            SelectType_IsEquipLegsSlot();
        }
        else if (isEquipFeetSlot)
        {
            //Feet
            SelectType_IsEquipFeetSlot();
        }
        else if (isEquipRingSlot)
        {

        }
        else if (isForgeMatSlot && isSingleTypeSlot)
        {
            //Forge Mat + Single Input
            SelectType_IsForgeMatSlot_IsSingleTypeSlot();
        }
        else if (isForgeInputSlot)
        {
            //Forge Input
            SelectType_IsForgeInput();
        }
        else if (isForgeOutputLeftSlot)
        {
            SelectType_IsForgeOutputLeftSlot();
        }
        else
        {
            print("Test Code: Oops, you forgot to set a slot tag!");
        }
    }

    ///////////////////////////////////////////////////////

    public void SelectType_IsInventory()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Set stack to Inventory
                Action_PlaceStack();
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                {
                    //Attempt To Merge Stacks
                    Action_CombineStacks();
                }
                else
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
            }
        }
    }

    public void SelectType_IsToolbarSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Set stack to Inventory
                Action_PlaceStack();
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                if (TM_CursorController.Instance.Cursor_GetItem().itemName == currentItem.itemName)
                {
                    //Attempt To Merge Stacks
                    Action_CombineStacks();
                }
                else
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
            }
        }
    }

    public void SelectType_IsEquipHeadSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorHead)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorHead)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
            }
        }
    }

    public void SelectType_IsEquipTorsoSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorChest)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorChest)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
            }
        }
    }

    public void SelectType_IsEquipArmSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorArm)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorArm)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
            }
        }
    }

    public void SelectType_IsEquipLegsSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorLeg)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorLeg)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
            }
        }
    }

    public void SelectType_IsEquipFeetSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorBoot)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isArmorBoot)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_PlayerMenuController_Inventory.Instance.Stats_RefreshUI();
            }
        }
    }

    public void SelectType_IsForgeInput()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isWeapon)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateInputItems(currentItem.original_SO);
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().isWeapon)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateInputItems(currentItem.original_SO);
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateInputItems(null);
                TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
            }
        }
    }

    public void SelectType_IsForgeMatSlot_IsSingleTypeSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().original_SO == singleTypeItemSO)
                {
                    //Set stack to Inventory
                    Action_PlaceStack();
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Filter Object Type
                if (TM_CursorController.Instance.Cursor_GetItem().original_SO == singleTypeItemSO)
                {
                    //Switch Stacks
                    Action_SwitchStacks();
                    TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_UpdateOutputItems();
            }
        }
    }

    public void SelectType_IsForgeOutputLeftSlot()
    {
        //Current Item
        if (currentItem == null)
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //No Action
                Action_NoAction();
            }
            else
            {
                //No Action
                Action_NoAction();
            }
        }
        else
        {
            //Cursor Item
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //No Action
                Action_NoAction();
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_PickupStack();
                TM_HomeMenuController_Forge.Instance.ForgeMenuFixed_ConsumeItems();
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void Action_NoAction()
    {
        print("Test Code: Double Empty / No Action");
    }

    ///////////////////////////////////////////////////////

    private void Action_PickupStack()
    {
        //Give Item
        TM_CursorController.Instance.Cursor_SetItem(currentItem);

        //Remove Item
        ItemSlot_RemoveItem();
    }

    private void Action_PlaceStack()
    {
        //Give Item
        ItemSlot_SetItem(TM_CursorController.Instance.Cursor_GetItem());

        //Remove Item
        TM_CursorController.Instance.Cursor_RemoveItem();
    }

    private void Action_SwitchStacks()
    {
        //Get Items
        TM_ItemUI inventoryItem = currentItem;
        TM_ItemUI cursorItem = TM_CursorController.Instance.Cursor_GetItem();

        //Switch Values
        TM_CursorController.Instance.Cursor_SetItem(inventoryItem);
        ItemSlot_SetItem(cursorItem);
    }

    private void Action_CombineStacks()
    {
        if (currentItem.currentStackSize < currentItem.maxStackSize)
        {
            //Get Max Values For Passing and Incoming
            int maxAllowedItems_INV = currentItem.maxStackSize - currentItem.currentStackSize;
            int maxPassableItems_CUR = TM_CursorController.Instance.Cursor_GetItem().currentStackSize;

            //Check for extra values
            if (maxPassableItems_CUR >= maxAllowedItems_INV)
            {
                //Give Some Values
                currentItem.currentStackSize += maxAllowedItems_INV;

                //Remove Some Values
                TM_CursorController.Instance.Cursor_GetItem().currentStackSize -= maxAllowedItems_INV;

                //Set Items Again To Refresh Stats
                ItemSlot_SetItem(currentItem);
                TM_CursorController.Instance.Cursor_SetItem(TM_CursorController.Instance.Cursor_GetItem());
            }
            else
            {
                //Deposit All Values
                currentItem.currentStackSize += TM_CursorController.Instance.Cursor_GetItem().currentStackSize;

                //Clear the Cursor
                TM_CursorController.Instance.Cursor_RemoveItem();

                //Set Items Again To Refresh Stats (Cursor was already removed)
                ItemSlot_SetItem(currentItem);
            }
        }
        else
        {
            //Go back and just swap stacks
            Action_SwitchStacks();
        }
    }

    private void Action_PickupSingle()
    {
        //Check If Not Empty
        if (TM_CursorController.Instance.Cursor_GetItem() == null)
        {
            //Give an Item and Make it Single
            TM_CursorController.Instance.Cursor_DupplicateItem(currentItem);
            TM_CursorController.Instance.Cursor_GetItem().currentStackSize = 1;
            TM_CursorController.Instance.Cursor_UpdateItem();
        }
        else
        {
            //Add an Item
            TM_CursorController.Instance.Cursor_GetItem().currentStackSize++;
            TM_CursorController.Instance.Cursor_UpdateItem();
        }




        //Remove a Single Item
        currentItem.currentStackSize--;
        ItemSlot_UpdateItem();
    }

    private void Action_PlaceSingle()
    {
        //Check If Not Empty
        if (currentItem == null)
        {
            //Give an Item and Make it Single
            ItemSlot_DupplicateItem(TM_CursorController.Instance.Cursor_GetItem());
            currentItem.currentStackSize = 1;
            ItemSlot_UpdateItem();
        }
        else
        {
            //Add an Item
            currentItem.currentStackSize++;
            ItemSlot_UpdateItem();
        }

        //Remove a Single Item
        TM_CursorController.Instance.Cursor_GetItem().currentStackSize--;
        TM_CursorController.Instance.Cursor_UpdateItem();
    }

    ///////////////////////////////////////////////////////

    //Overload witha  simple transofmation for input, could be reduced later??
    public bool Action_QuickStack(GameObject[] currentInventory_List)
    {
        //List of Possible Merges
        List<TM_ItemSlot> possibleEmptySpots_List = new List<TM_ItemSlot>();
        List<TM_ItemSlot> possibleMerges_List = new List<TM_ItemSlot>();

        ///////////////////////////////////////////////////////

        //Find Empty Slots in Toolbar
        foreach (GameObject itemSlot in currentInventory_List)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            //Search Empty Spots
            if (slot.currentItem == null)
            {
                //Add to Empty Spots
                possibleEmptySpots_List.Add(slot);
            }
            else
            {
                //Check For Matching Names
                if (slot.currentItem.itemName == currentItem.itemName)
                {
                    //Check For Non-Max Values
                    if (slot.currentItem.currentStackSize < slot.currentItem.maxStackSize)
                    {
                        //Add to Mergable Spots
                        possibleMerges_List.Add(slot);
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////

        for (int i = 0; i < possibleMerges_List.Count; i++)
        {
            //Calculate Max Item Recivable / Passable
            int maxAllowedItems_TOL = possibleMerges_List[i].currentItem.maxStackSize - possibleMerges_List[i].currentItem.currentStackSize;
            int maxPassableItems_INV = currentItem.currentStackSize;

            //Check for extra values
            if (maxPassableItems_INV >= maxAllowedItems_TOL)
            {
                //Give Some Values
                possibleMerges_List[i].currentItem.currentStackSize += maxAllowedItems_TOL;

                //Remove Some Values
                currentItem.currentStackSize -= maxAllowedItems_TOL;

                //Set Items Again To Refresh Stats
                ItemSlot_SetItem(currentItem);
                possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);

                //If SetItem Removed the currentItem, break out
                if (currentItem == null)
                {
                    //Return True the transfer was successful
                    return true;
                }
            }
            else
            {
                //Deposit All Values
                possibleMerges_List[i].currentItem.currentStackSize += currentItem.currentStackSize;

                //Clear the INV Item
                ItemSlot_RemoveItem();

                //Set Items Again To Refresh Stats (INV was already removed)
                possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);

                //Return True the transfer was successful
                return true;
            }
        }

        ///////////////////////////////////////////////////////

        if (possibleEmptySpots_List.Count > 0)
        {
            //???
            if (currentItem != null)
            {
                //Move Stack
                possibleEmptySpots_List[0].ItemSlot_SetItem(currentItem);

                //print("Test Code: Found Free Slot");

                //Remove Stack
                ItemSlot_RemoveItem();
            }

            //Return True the transfer was successful
            return true;
        }

        ///////////////////////////////////////////////////////

        //Nothing Avalible Return False
        return false;
    }

    //Overload witha  simple transofmation for input, could be reduced later??
    public bool Action_QuickStack(TM_ItemSlot[] currentInventory_List)
    {
        //List of Possible Merges
        List<TM_ItemSlot> possibleEmptySpots_List = new List<TM_ItemSlot>();
        List<TM_ItemSlot> possibleMerges_List = new List<TM_ItemSlot>();

        ///////////////////////////////////////////////////////

        //Find Empty Slots in Toolbar
        foreach (TM_ItemSlot slot in currentInventory_List)
        {
            //Search Empty Spots
            if (slot.currentItem == null)
            {
                //Add to Empty Spots
                possibleEmptySpots_List.Add(slot);
            }
            else
            {
                //Check For Matching Names
                if (slot.currentItem.itemName == currentItem.itemName)
                {
                    //Check For Non-Max Values
                    if (slot.currentItem.currentStackSize < slot.currentItem.maxStackSize)
                    {
                        //Add to Mergable Spots
                        possibleMerges_List.Add(slot);
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////

        for (int i = 0; i < possibleMerges_List.Count; i++)
        {
            //Calculate Max Item Recivable / Passable
            int maxAllowedItems_TOL = possibleMerges_List[i].currentItem.maxStackSize - possibleMerges_List[i].currentItem.currentStackSize;
            int maxPassableItems_INV = currentItem.currentStackSize;

            //Check for extra values
            if (maxPassableItems_INV >= maxAllowedItems_TOL)
            {
                //Give Some Values
                possibleMerges_List[i].currentItem.currentStackSize += maxAllowedItems_TOL;

                //Remove Some Values
                currentItem.currentStackSize -= maxAllowedItems_TOL;

                //Set Items Again To Refresh Stats
                ItemSlot_SetItem(currentItem);
                possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);

                //If SetItem Removed the currentItem, break out
                if (currentItem == null)
                {
                    //Return True the transfer was successful
                    return true;
                }
            }
            else
            {
                //Deposit All Values
                possibleMerges_List[i].currentItem.currentStackSize += currentItem.currentStackSize;

                //Clear the INV Item
                ItemSlot_RemoveItem();

                //Set Items Again To Refresh Stats (INV was already removed)
                possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);

                //Return True the transfer was successful
                return true;
            }
        }

        ///////////////////////////////////////////////////////

        if (possibleEmptySpots_List.Count > 0)
        {
            //???
            if (currentItem != null)
            {
                //Move Stack
                possibleEmptySpots_List[0].ItemSlot_SetItem(currentItem);

                //Remove Stack
                ItemSlot_RemoveItem();
            }

            //Return True the transfer was successful
            return true;
        }

        ///////////////////////////////////////////////////////

        //Nothing Avalible Return False
        return false;
    }

    ///////////////////////////////////////////////////////
}