using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_CreditsController controls the credits sequence at the end of the game or though the menu.
/// 
/// </summary>
///////////////

public class TM_CreditsController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_CreditsController Instance;

    ////////////////////////////////

    [Header("Canvas Credits Gameobject Animator")]
    public Animator CreditsAnimator;

    [Header("Animation Speed Variables")]
    private int animatorDelay = 2;
    private int animatorSpeed_Fast = 5;
    private int animatorSpeed_Regular = 1;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        //Play Music
        //FindObjectOfType<SoundManager>().PlaySpecificSound("Peace");

        //Start the Coroutine to play the slideshow after a delay
        StartCoroutine(CreditsPlay());
    }

    private void Update()
    {
        //Set Scroll Speed
        SpeedUp();

        //Quit the Credits
        ExitCredits();
    }

    ///////////////////////////////////////////////////////

    private void SpeedUp()
    {
        //Look for the spacebar key to speed up the credits
        if (Input.GetKey("space"))
        {
            //Go faster
            CreditsAnimator.speed = animatorSpeed_Fast;
        }
        else
        {
            //Go slower
            CreditsAnimator.speed = animatorSpeed_Regular;
        }
    }

    private void ExitCredits()
    {
        //Look for the escape key to exit the credits
        if (Input.GetKey("escape"))
        {
            //Load back into main game
            SceneManager.LoadScene("TM_Title");
        }
    }

    ///////////////////////////////////////////////////////

    private IEnumerator CreditsPlay()
    {
        //Wait before starting the slideshow
        yield return new WaitForSeconds(animatorDelay);

        //Play Credits Slideshow
        CreditsAnimator.Play("Play");
    }

    ///////////////////////////////////////////////////////
}
