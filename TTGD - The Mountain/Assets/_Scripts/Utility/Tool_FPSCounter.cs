using UnityEngine;
using System.Collections;

///////////////
/// <summary>
///     
/// Tool_FPSCounter is an imported classes that displays the framerate in top right corner.
/// 
/// </summary>
///////////////

public class Tool_FPSCounter : MonoBehaviour
{
    ////////////////////////////////

    private float deltaTime = 0.0f;

    /////////////////////////////////////////////////////////////////

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 4 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    /////////////////////////////////////////////////////////////////
}
