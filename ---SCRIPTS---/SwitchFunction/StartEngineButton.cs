using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;

public class StartEngineButton : MonoBehaviour
{
    private float timer = 0f;
    private bool insideCollider = false;
    public GameObject starterLightObj;
    public Animator rotorAinm;
    public Vector2 buttonOffset_;
    private GameObject startButton;



    private void Start()
    {
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
        startButton = transform.GetChild(0).gameObject;
        starterLightObj.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        // Check if the entered GameObject has a specific tag
        if (other.CompareTag("Finger"))
        {
            AudioManager.instance.PlayHelicopterAudioOnce(11);
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
            // Set the insideCollider flag and reset the timer
            insideCollider = true;
            timer = 0f;
            starterLightObj.SetActive(true);
            if (!GameManager.engineOn_)
            {
                rotorAinm.Play("Engine_Startup");
                AudioManager.instance.audioSource2.pitch = 0.7f;
                AudioManager.instance.PlayHelicopterAudio(4);
                foreach (Animator animator in GameManager.instance.instrucmentAnimList)
                {
                    animator.SetBool("EngineStart", true);
                    animator.SetTrigger("EngineTrigger");
                }
                
            }
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        startButton.transform.localPosition = Vector3.zero;
        // Check if the exited GameObject has a specific tag
        if (other.CompareTag("Finger"))
        {
            
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.1f);
            // Reset the insideCollider flag and the timer
            starterLightObj.SetActive(false);
            insideCollider = false;
            timer = 0f;
            if (!GameManager.engineOn_)
            {
                rotorAinm.Play("Engine_Off");
                foreach (Animator animator in GameManager.instance.instrucmentAnimList)
                {
                    animator.SetBool("EngineStart", false);
                }

                GameManager.startingEngine_ = false;
                AudioManager.instance.audioSource2.Stop();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "UxrFingerTipRight")
        {
            Vector3 targetPosition =  other.transform.position;
            Vector3 currentPosition = startButton.transform.position;
            currentPosition.x = targetPosition.x;
            //currentPosition.z = Mathf.Clamp(currentPosition.x, buttonOffset_.x/10, buttonOffset_.y/10);
            startButton.transform.position = currentPosition;
            
            
        }

        if (other.CompareTag("Finger"))
        {
            if (!GameManager.engineOn_)
            {
                UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 0.1f);
            }
            
        }
    }

    private void Update()
    {
        // If the GameObject is inside the Collider, start the timer
        if (insideCollider)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                GameManager.engineOn_ = true;
                

                starterLightObj.SetActive(false);

            }
        }
        if (GameManager.engineOn_)
        {
            if (!AudioManager.instance.audioSource2.isPlaying)
            {
                AudioManager.instance.audioSource2.volume = 0.4f;
                AudioManager.instance.audioSource2.loop = true;
                AudioManager.instance.audioSource2.pitch = 0;
                AudioManager.instance.PlayHelicopterAudio(3);
                if (AudioManager.instance.audioSource1.isPlaying)
                {
                    AudioManager.instance.audioSource2.volume = 0.2f;
                }
                
            }
            if (AudioManager.instance.audioSource2.pitch < 1f)
            {
                AudioManager.instance.audioSource2.pitch += Time.deltaTime / 6.7f;
            }
        }
    }
}
