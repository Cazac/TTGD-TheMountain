using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_IconData : MonoBehaviour
{
    ////////////////////////////////

    [Header("Class Sprites")]
    public Sprite classIcon_Brawler;
    public Sprite classIcon_Knight;
    public Sprite classIcon_Archer;
    public Sprite classIcon_Wizard;
    public Sprite classIcon_Tank;

    ////////////////////////////////

    [Header("Debug Sprites")]
    public Sprite forgeIcon_Cross;
    public Sprite forgeIcon_Question;
    public Sprite forgeIcon_Weapon;







    ///////////////////////////////////////////////////////

    public Sprite FindData_ClassIcon(string className)
    {
        if (className == "Brawler")
        {
            return classIcon_Brawler;
        }
        else if (className == "Knight")
        {
            return classIcon_Knight;
        }
        else if (className == "Archer")
        {
            return classIcon_Archer;
        }
        else if (className == "Wizard")
        {
            return classIcon_Wizard;

        }
        else if (className == "Tank")
        {
            return classIcon_Tank;
        }
        else
        {
            return null;
        }
    }

    ///////////////////////////////////////////////////////
}
