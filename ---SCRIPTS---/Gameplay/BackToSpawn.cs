using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Heli"))
        {
            TutorialScript.cargoTutorialOn_ = true;
        }
        else
        {
            TutorialScript.cargoTutorialOn_ = false;
        }
    }
}
