using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size *= 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.X))   //debug test
        {
            dialogObj.GetComponent<Dialog>().NextWayPoint();
            Debug.Log("ColluderEnetr");
        }
        */
    }

   void OnTriggerEnter(Collider other)
    {
        //Debug.Log("touch");

        if (other.CompareTag("Heli"))
        {
            WaypointManager.instance.NextWayPoint();
            TutorialScript.ringPassedCount += 1;
            TutorialScript.ringTimer += 1;
            AudioManager.instance.PlayHelicopterAudioOnce(12);
            this.gameObject.SetActive(false);
        }
        
    }
}
