using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ButtonHeli))]
public class StartEngine : MonoBehaviour
{
    private ButtonHeli buttonScript;
    private float pressStartTime;
    // Start is called before the first frame update
    void Start()
    {
        buttonScript = this.gameObject.GetComponent<ButtonHeli>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (buttonScript.buttonPressed == true)
        {
            pressStartTime = Time.time;
        }
    }
}
