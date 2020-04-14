using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///
/// TM_LightContainer
/// 
/// </summary>
///////////////

public class TM_LightTab : MonoBehaviour
{
    ////////////////////////////////

    [Header("Starting Values")]
    public float lightIntensity_BaseValue;
    public float lightRange_BaseValue;

    [Header("List Of Lights")]
    public List<Light> lightSources_List;

    ///////////////////////////////////////////////////////

    public void RefreshLightValues(float lightRatio)
    {
        foreach (Light light in lightSources_List)
        {
            //Set Light Intensity as a Ratio
            light.intensity = lightIntensity_BaseValue * lightRatio;

            //
        }
    }

    ///////////////////////////////////////////////////////

    public void SetBlinkingLights()
    {

    }

    public void RemoveBlinkingLights()
    {
        StopAllCoroutines();
    }

    private IEnumerator BlinkingLights()
    {
        yield break;
    }

    ///////////////////////////////////////////////////////
}
