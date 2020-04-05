using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TM_DamagePopup : MonoBehaviour
{

    //The gameobject Text 
    private TextMeshProUGUI textMesh;

    //How long the text lasts
    private const float DISAPPEAR_TIMER_MAX = 0.5f;

    //Static Varible to Determin height of text
    private static int sortingOrder;

    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;


    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        MoveText();
    }

    /////////////////////////////////////////////////////////////////

    public void Setup(int damageAmount)
    {
        //Set value
        textMesh.SetText(damageAmount.ToString());

        //Set Timer for text to disapear
        disappearTimer = DISAPPEAR_TIMER_MAX;

        //Increment / set Layer for better visablity
        //sortingOrder++;
        //textMesh. = sortingOrder;

        //Setup Amount To move per frame
        moveVector = new Vector3(.8f, 1.2f) * 60f;
    }


    public void MoveText()
    {
        //Get Values
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 30f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        // ???
        disappearTimer -= Time.deltaTime;

        // Start disappearing
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /////////////////////////////////////////////////////////////////
}
