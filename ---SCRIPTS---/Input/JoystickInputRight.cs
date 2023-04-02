using System.Collections;
using System.Collections.Generic;
using UltimateXR.Devices;
using UltimateXR.Avatar;
using UnityEngine;
public class JoystickInputRight : MonoBehaviour
    {
        public Vector2 rightJoystickValue;
    public bool rButton;
        // Start is called before the first frame update
        // Update is called once per frame
        void FixedUpdate()
        {
            UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
            rightJoystickValue = myAvatar.ControllerInput.GetInput2D (UltimateXR.Core.UxrHandSide.Right , UxrInput2D.Joystick);
        }
    void Update()
    {
        rButton = UxrAvatar.LocalAvatarInput.GetButtonsPress(UltimateXR.Core.UxrHandSide.Right, UxrInputButtons.Button1 | UxrInputButtons.Button2);
        if (InputManager.debugMode)
        {
            if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UltimateXR.Core.UxrHandSide.Right, UxrInputButtons.Button2)) // button b
            {
                InputManager.debugMode = false;
            }

        }

        UxrAvatar.LocalAvatarInput.GetButtonsPress(UltimateXR.Core.UxrHandSide.Right, UxrInputButtons.Trigger);
    }
}
