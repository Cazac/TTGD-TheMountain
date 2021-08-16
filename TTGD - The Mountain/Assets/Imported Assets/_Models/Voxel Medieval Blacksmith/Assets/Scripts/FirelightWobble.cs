// **********
// Released by JustUsGamers.net
// Under the CC0 - Creative Commons Zero license
// No attribution is required, feel free to share this freely
// JustUsGamers.net holds no responsibility for the use of this code
// and provides no warranty.
// **********

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirelightWobble : MonoBehaviour {

    // Adjust these in the editor to affect how the light wobbles.
    public float WobbleIntensity = .05f;
    public float WobbleSpeed = 20f;
    public float LightIntensity = 2f;

    private Vector3 homePosition;
    private Vector3 nextPosition;
    private bool finishedWobble = false;
    private Light theLight;
    private float newIntensity;

    private void Start()
    {
        // Gets the Light and its Home Position
        // Then calls NewWobble() to get things started.

        theLight = this.GetComponent<Light>();
        homePosition = this.transform.position;
        NewWobble();
    }

    void Update () {
        // We want to see if our current Wobble has finished.
        // If yes, then get a new one started
        // if not, Lerp to destination.

        theLight.intensity = Mathf.Lerp(theLight.intensity, newIntensity, Time.deltaTime * 4f);

        if (finishedWobble)
        {
            NewWobble();
            finishedWobble = false;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, WobbleSpeed * Time.deltaTime);

        if (Vector3.Distance( this.transform.position, nextPosition) <= WobbleIntensity * .1f)
        {
            finishedWobble = true;
        }
	}

    /// <summary>
    /// Sets nextPosition to a random location based around the lights
    /// home position. This is affected by WobbleIntensity.
    /// </summary>
    private void NewWobble()
    {
        nextPosition = homePosition + new Vector3(
            Random.Range(-WobbleIntensity, WobbleIntensity),
            Random.Range(-WobbleIntensity, WobbleIntensity),
            Random.Range(-WobbleIntensity, WobbleIntensity));

        newIntensity = LightIntensity + ( (nextPosition.y - homePosition.y) / WobbleIntensity / 4);
    }
}
