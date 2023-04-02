using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Devices;
using UltimateXR.Avatar;


public class CargoDropButton : MonoBehaviour
{
    //public HookScript hookscript;
    // Start is called before the first frame update
    void Start()
    {
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
    }

    void FixedUpdate()
    {
        if(UxrAvatar.LocalAvatarInput.GetButtonsPress(UltimateXR.Core.UxrHandSide.Right, UxrInputButtons.Trigger))
        {
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
            HookScript.drop = true;
        }
        else
        {
            HookScript.drop = false;
        }
        
    }
    // Update is called once per frame
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
            HookScript.drop = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Check if the exited GameObject has a specific tag
        if (other.CompareTag("Finger"))
        {

            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.1f);
            HookScript.drop = false;

        }
    }
    */
   
}