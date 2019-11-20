using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_ExampleClass is used to explain the code styling template we will use for the project "The Mountain"
/// The class name uses capitalization and is preceded by TM_ (The Mountain) to show it is one of our scripts and not imported.
/// Use this summary head to explain the purpose of this class.
/// 
/// </summary>
///////////////

public class TM_ExampleClass : MonoBehaviour
{
    //Using small spacers to divide up grouped variables at the top of the class
    ////////////////////////////////

    //Use headers for groupings of variables
    [Header("Descriptive Headers For Variables")]
    private string variable_1;
    private string variable_2;
    private string variable_3;

    //Make variables explicitly private or public, do not leave blank
    [Header("Descriptive Headers For Variables")]
    public string variable_11;
    private string variable_21;
    public string variable_31;
    private string variable_41;

    //Using large dividers to split up divide up grouped methods 
    /////////////////////////////////////////////////////// - MonoBehaviour Methods

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    /////////////////////////////////////////////////////// - Actions

    private void Action_One()
    {

    }

    private void Action_Two()
    {

    }

    /////////////////////////////////////////////////////// - Saving

    private void Save()
    {

    }

    private void Load()
    {

    }

    ///////////////////////////////////////////////////////
}
