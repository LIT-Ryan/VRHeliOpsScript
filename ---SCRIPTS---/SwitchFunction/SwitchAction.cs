using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Switch))]
public class SwitchAction : MonoBehaviour
{
    private Switch switchScript;
    public Action switchAction;
    private bool stop = false;

    public enum Action
    {
        Battery,
        Fuel,
        ArmCargo,
        ArmWaterSystem,
        ArmCropDust,
        Avionics,
    }
    // Start is called before the first frame update
    void Start()
    {
        switchScript = this.gameObject.GetComponent<Switch>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switchScript.isON)
        {
            switch (switchAction)
            {
                case Action.Battery:
                    GameManager.batteryOn_ = true;
                    break;
                case Action.Fuel:
                    GameManager.fuelOn_ = true;
                    break;
                case Action.ArmCargo:
                    GameManager.hookOn_ = true;
                    break;
                case Action.ArmCropDust:
                    //error audio
                    break;
                case Action.ArmWaterSystem:
                    TutorialScript.ringPassedCount = 27;
                    break;
                case Action.Avionics:
                    if (!stop)
                    {
                        AudioSource radioAudioSource = GameObject.Find("Radio").GetComponent<AudioSource>();
                        radioAudioSource.volume = 0.11f;
                        radioAudioSource.pitch = 1;
                        radioAudioSource.Play();
                        stop = true;
                    }
                    break;

                    /* Copy and paste resource
         *case Action.:
                break;
        */

            }



        }
        if (!switchScript.isON)
        {
            switch (switchAction)
            {
                case Action.Battery:
                    GameManager.batteryOn_ = false;
                    break;
                case Action.Fuel:
                    GameManager.fuelOn_ = false;
                    break;
                case Action.ArmCargo:
                    GameManager.hookOn_ = false;
                    break;
                case Action.ArmCropDust:
                    //error audio
                    break;
                case Action.ArmWaterSystem:
                    break;
                case Action.Avionics:
                    AudioSource radioAudioSource = GameObject.Find("Radio").GetComponent<AudioSource>();
                    radioAudioSource.volume = 0;
                    stop = false;
                    break;

                    /* Copy and paste resource
         *case Action.:
                break;
        */

            }



        }


    }
}
