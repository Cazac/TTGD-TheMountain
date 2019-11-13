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

public class BellowsAnimScript : MonoBehaviour {

    private enum State { Empty, Half, Full }
    private State BellowsState = State.Empty;

    public float BellowsCycleLength = 3f;
    public float BellowsFillSpeed = .3f;
    public bool isBellowsAnimating;

    private Renderer[] bellowsRenderers;
    private bool isInflating = true;
    private float currentCycleTime = 0f;

	void Start () {

        // Get all the Renderers of our 3 Bellows states (Full, Half, Empty)
        // Then run BellowsChange to get everything started.

        bellowsRenderers = this.GetComponentsInChildren<Renderer>(true);
        BellowsChange();
	}

    private void Update()
    {
        // If our Bellows is supposed to be animating then add the time since the last frame
        // and see if it's been enough time to cycle again.
        if (isBellowsAnimating)
        {
            currentCycleTime += Time.deltaTime;

            if (currentCycleTime >= BellowsCycleLength)
            {
                currentCycleTime = 0;
                BellowsChange();
            }

        }

    }

    /// <summary>
    /// Handles the states for Inflating and Deflating the Bellows
    /// Essentially we are Invoking this function with a delay to give our
    /// Bellows the look and animation of it Inflating and Deflating.
    /// </summary>
    void BellowsChange()
    {
        if (isInflating)
        {
            switch (BellowsState)
            {
                case State.Empty:
                    BellowsState = State.Half;
                    Invoke("BellowsChange", BellowsFillSpeed / 2);

                    break;
                case State.Half:
                    BellowsState = State.Full;

                    bellowsRenderers[0].enabled = false;
                    bellowsRenderers[1].enabled = true;
                    bellowsRenderers[2].enabled = false;

                    Invoke("BellowsChange", BellowsFillSpeed / 2);

                    break;
                case State.Full:
                    bellowsRenderers[0].enabled = false;
                    bellowsRenderers[1].enabled = false;
                    bellowsRenderers[2].enabled = true;
                    isInflating = !isInflating;

                    break;
            }
        }
        else
        {
            switch (BellowsState)
            {
                case State.Empty:
                    bellowsRenderers[0].enabled = true;
                    bellowsRenderers[1].enabled = false;
                    bellowsRenderers[2].enabled = false;
                    isInflating = !isInflating;

                    break;
                case State.Half:
                    BellowsState = State.Empty;

                    bellowsRenderers[0].enabled = false;
                    bellowsRenderers[1].enabled = true;
                    bellowsRenderers[2].enabled = false;

                    Invoke("BellowsChange", BellowsFillSpeed / 2);

                    break;
                case State.Full:
                    BellowsState = State.Half;
                    Invoke("BellowsChange", BellowsFillSpeed / 2);

                    break;
            }
        }
    }

}
