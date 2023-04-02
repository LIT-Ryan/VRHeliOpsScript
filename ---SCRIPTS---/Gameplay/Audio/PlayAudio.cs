using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


public class PlayAudio : MonoBehaviour
{
    public enum Options
    {
        NextTrainingDialogue,
        PlayMiscDialogue,
        NextTrainingCargoDialogue,
        HelicopterAudio

    }

    public enum HeliAudioSelected
    {
        BladeSlap,
        EngineInside,
        EngineOutside,
        EngineStart,
        REngLow,
        Switch_Off,
        Switch_On,
    }

    public enum MiscAudioSelected
    {

    }

    public enum PlayLocations
    {
        AudioMain,
        Audio3D
    }

    public string audioName_;
    public bool playAudio = false;

  

    public Options Action;
    public HeliAudioSelected heliAudioSelected;
    public PlayLocations audioType;
    public MiscAudioSelected miscAudioSelected;

    public AudioSource audioSource;
    public int helicopterAudioList = 0;

    void Start()
    {
        
        switch (audioType)
        {
            case PlayLocations.AudioMain:
                break;
            case PlayLocations.Audio3D:
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                break;

        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Play();
        }
        if (playAudio)
        {
            switch (Action)
            {
                case Options.NextTrainingDialogue:
                    AudioManager.instance.NextTrainingDialogue();
                    break;
                case Options.PlayMiscDialogue:
                    break;
                case Options.NextTrainingCargoDialogue:
                    break;
                case Options.HelicopterAudio:
                    switch (heliAudioSelected)
                    {
                        case HeliAudioSelected.BladeSlap:
                            break;
                        case HeliAudioSelected.EngineInside:
                            break;
                        case HeliAudioSelected.EngineOutside:
                            break;
                        case HeliAudioSelected.EngineStart:
                            break;
                        case HeliAudioSelected.REngLow:
                            break;
                        case HeliAudioSelected.Switch_Off:
                            break;
                        case HeliAudioSelected.Switch_On:
                            break;
                    }
                    break;
            }

            

            playAudio = false;
           
        }
    }
    void Play()
    {
        playAudio = true;
        //AudioManager.instance.NextHelicopterAudio( helicopterAudioList , audioSource);
    }


}
