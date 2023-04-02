using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;

public class IpadButtonTest1 : MonoBehaviour
{
    public bool startTutorial = false;
    public bool freeFlight = false;
    private void Start()
    {
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
            Debug.Log("test2");
            if (startTutorial)
            {
                TutorialScript.tutorialOn_ = true;
            }
            else if (freeFlight)
            {
                GameManager.freeFlight_ = true;
            }

        }
    }

}
