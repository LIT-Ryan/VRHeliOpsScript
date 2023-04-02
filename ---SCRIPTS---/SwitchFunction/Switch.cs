using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    AudioClip switchClip;
    AudioSource audioSource;
    public bool isON = false;
    public float angle = 80;
    
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            switchClip = Resources.Load<AudioClip>("Audio/Helicopter/13_FlickingSwitch");
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = switchClip;
        }

        if (this.gameObject.GetComponent<SphereCollider>() == null)
        {
            SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
            sphereCollider.center = new Vector3(-0.0002363836f, -0.01729175f, -0.02608985f);
            sphereCollider.radius = 0.004882813f;
        }

        

    }
    public void Trigger()
    {
        
        
        Debug.Log(isON);
        if (isON)
        {
            transform.localRotation = Quaternion.Euler(-0, 0, 0);
            audioSource.Play();
        }
        else
        {
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
            audioSource.Play();
        }
        isON = !isON;

    }
}
