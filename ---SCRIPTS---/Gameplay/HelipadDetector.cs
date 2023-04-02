using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelipadDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heli"))
        {
            TutorialScript.backToHelipad_ = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Heli"))
        {
            TutorialScript.backToHelipad_ = false;
        }
    }
}
