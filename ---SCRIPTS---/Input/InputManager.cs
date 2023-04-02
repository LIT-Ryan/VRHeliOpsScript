using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public JoystickInputRight joyInpScriptR;
    public JoystickInputLeft joyInpScriptL;

    public float rJoystickInput;
    public float lJoystickInput;
    public static bool debugMode;
    public GameObject player;

    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        joyInpScriptR = GameObject.Find("JoystickInputRight").GetComponent<JoystickInputRight>();
        joyInpScriptL = GameObject.Find("JoystickInputLeft").GetComponent<JoystickInputLeft>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rJoystickInput= joyInpScriptR.rightJoystickValue.x;
        lJoystickInput = joyInpScriptL.leftJoystickValue.x;
        
        if (joyInpScriptL.lButton && joyInpScriptR.rButton)
        {
            Debug.Log("Cheat");
            debugMode = true;
        }

        if (debugMode)
        {
            UI.SetActive(true);
            player.transform.position += Vector3.up * joyInpScriptL.leftJoystickValue.y/100;
        }
        else
        {
            UI.SetActive(false);
        }

    }
}
