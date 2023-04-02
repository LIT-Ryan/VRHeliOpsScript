using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Helmet"))
        {
            TutorialScript.helmetOn_ = true;
            other.gameObject.SetActive(false);
        }
    }
}
