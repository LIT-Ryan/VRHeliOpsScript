using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Devices;
using UltimateXR.Avatar;

public class FingerTriggerRight : MonoBehaviour
{
    public bool switchDown = false;
    private bool canTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "SwitchUp" && canTrigger)
        {
            Debug.Log("trigger");
            GameObject collidedObject = other.gameObject;
            collidedObject.GetComponentInParent<Switch>().Trigger();
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.5f);
            canTrigger = false;
            Invoke("EnableTrigger", 0.35f);
        }
        else if (other.tag == "SwitchDown" && canTrigger)
        {
            Debug.Log("trigger");
            GameObject collidedObject = other.gameObject;
            collidedObject.GetComponentInParent<Switch>().Trigger();
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.5f);
            canTrigger = false;
            Invoke("EnableTrigger", 0.35f);
        }
        if (other.CompareTag("Button"))
        {
           // UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.5f);
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.tag == "Button")
        {
            GameObject collidedObject = other.gameObject;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.5f);
            collidedObject.GetComponentInParent<ButtonHeli>().isTrigger = true;
        }
        */
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    void EnableTrigger()
    {
        canTrigger = true;
    }
}
