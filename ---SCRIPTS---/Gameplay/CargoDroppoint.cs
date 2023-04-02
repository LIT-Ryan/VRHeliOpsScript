using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoDroppoint : MonoBehaviour
{
    //AudioClip collectClip;
   // AudioSource audioSource;

    private void Start()
    {
        /*audioSource = gameObject.AddComponent<AudioSource>();
        collectClip = Resources.Load<AudioClip>("Audio/CollectSound");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collectClip;
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cargo")
        {
            //audioSource.Play();
            TutorialScript.dropSuccess_ = true;
            TutorialScript.dropSuccessCount_ += 1;
            AudioManager.instance.PlayHelicopterAudioOnce(12);
            Destroy(this.gameObject);

        }
    }
}
