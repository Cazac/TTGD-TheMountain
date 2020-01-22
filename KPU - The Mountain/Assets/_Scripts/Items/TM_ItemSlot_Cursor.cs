using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TM_ItemSlot_Cursor : MonoBehaviour, IPointerClickHandler
{



    public TM_ItemUI_Base currentCursorItem;



    //IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    // Start is called before the first frame update
    void Start()
    {
        //currentCursorItem = TM_DatabaseController.Instance.consumableFood_LIST[0];
    }



    private void Update()
    {
        FollowCursor();
    }


    private void FollowCursor()
    {
        print("Test Code: Following");

        if (currentCursorItem != null)
        {
            print("Test Code: Following");

            //Move Icon with cursor
            Vector3 cursorPosition = (Input.mousePosition);
            cursorPosition.z = -5;

            //Apply position
            gameObject.transform.position = cursorPosition;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        /*
        return;

        //Check if node is disabled 
        if (isDisabled == true)
        {
            return;
        }

        //Record Start Parent
        startPositionParent = gameObject.transform.parent.gameObject;

        //CHeck if its a purchese node
        if (isInfinite)
        {
            //Spawn New Drag Unit Panel
            GameObject NewUnit = Instantiate(gameObject, gameObject.transform.parent);

            //Dupplicate All Stats
            NewUnit.GetComponent<TC_UnitDrag>().isInfinite = true;
            NewUnit.GetComponent<TC_UnitDrag>().unitScript = unitScript.DeepCopy();

            //Set starting point
            NewUnit.GetComponent<TC_UnitDrag>().startPositionParent = startPositionParent;

            //Set Unit
            NewUnit.GetComponent<TC_UnitDrag>().startPositionParent.GetComponent<TC_Dropbox>().unitPanel = NewUnit;

            //Set drag canvas refference
            NewUnit.GetComponent<TC_UnitDrag>().unitDragCanvas_Parent = unitDragCanvas_Parent;

            //Allow the Old Panel To Be Moved
            isPaid = true;
            isInfinite = false;

            //Set Drag Parent
            gameObject.transform.SetParent(unitDragCanvas_Parent.transform);

            //Charge the player the training cost
            ChargePlayer();

            //Remove Start Position so that its rooted
            NewUnit.GetComponent<TC_UnitDrag>().startPositionParent = null;
        }
        else
        {
            //Set Drag Parent
            gameObject.transform.SetParent(unitDragCanvas_Parent.transform);
        }


        //soundManager.PlayOnUIClick(soundEffect);
        */
    }



    public void OnEndDrag()
    {
        /*
        //Check if node is disabled 
        if (isDisabled == true)
        {
            return;
        }

        return;

        //Return To Old Position
        if (unitDragCanvas_Parent == gameObject.transform.parent.gameObject)
        {
            if (isPaid == false)
            {
                //Return unit to former spot
                ReturnUnit();
            }
            else
            {
                //Refund and destroy unit
                RefundPlayer();
                Destroy(gameObject);
            }
        }

        //Update Costs
        TC_ButtonController_Barracks.Instance.UpdateCommanderCosts();

        //Save
        TC_ButtonController_Barracks.Instance.Save_AllChanges();
        */
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
