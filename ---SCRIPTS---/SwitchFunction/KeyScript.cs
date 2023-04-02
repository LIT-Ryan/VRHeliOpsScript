using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(GameManager.keyOn_);
        float rotationZ = transform.rotation.eulerAngles.z;
        if (rotationZ <= 290 && rotationZ >= 270 && !GameManager.keyOn_)
        {
            AudioManager.instance.PlayHelicopterAudioOnce(16);
            GameManager.keyOn_ = true;
        }
        else if (rotationZ <= 20 && GameManager.keyOn_)
        {
            AudioManager.instance.PlayHelicopterAudioOnce(16);
            GameManager.keyOn_ = false;
        }
    }
}
