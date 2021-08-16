using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    public float minIntensity;
    public float maxIntensity;
    private float lightScaleChange;
    private Light lightSource;

    float random;
 
    void Start()
    {
        random = Random.Range(0.0f, 65535.0f);

        //lightScaleChange = (maxIntensity - minIntensity) / 600;
        //lightSource = GetComponent<Light>();
    }
 
    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        

        //lightSource.intensity = Mathf.Clamp(Random.Range(lightSource.intensity - lightScaleChange, lightSource.intensity + lightScaleChange), minIntensity, maxIntensity);
    }
}
