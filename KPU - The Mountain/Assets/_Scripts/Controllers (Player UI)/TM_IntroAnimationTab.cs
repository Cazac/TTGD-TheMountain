using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_IntroAnimationTab : MonoBehaviour
{
 
    public void AnimationEvent_IntroDone()
    {
        TM_PlayerMenuController_Intro.Instance.AnimationEvent_IntroDone();
    }
}
