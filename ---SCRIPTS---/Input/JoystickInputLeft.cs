using System.Collections;
using System.Collections.Generic;
using UltimateXR.Devices;
using UltimateXR.Avatar;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JoystickInputLeft : MonoBehaviour
    {
        public Vector2 leftJoystickValue;
        public bool lButton;
        // Start is called before the first frame update
        // Update is called once per frame
        void FixedUpdate()
        {
            UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
            leftJoystickValue = myAvatar.ControllerInput.GetInput2D (UltimateXR.Core.UxrHandSide.Left , UxrInput2D.Joystick);

        

           
        }
    void Update()
    {
        lButton = UxrAvatar.LocalAvatarInput.GetButtonsPress(UltimateXR.Core.UxrHandSide.Left, UxrInputButtons.Button1 | UxrInputButtons.Button2);
        if (InputManager.debugMode)
        {
            if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UltimateXR.Core.UxrHandSide.Left, UxrInputButtons.Button2)) // button y
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }

        }

    }




}
