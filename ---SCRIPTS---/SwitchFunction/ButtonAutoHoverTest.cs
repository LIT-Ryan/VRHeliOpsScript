using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;

public class ButtonAutoHoverTest : MonoBehaviour
{
    public Transform heliTrans;
    public bool autoHoverOn_ = false;
    float targetHeight;
    public Rigidbody helicopterRigidbody;
    public float currentY;
    public float initialYForce;
    public float val1 = 0;
    public float val2 = 1;
    public float val3 = 10;
    public float hoverForce = 10f;
    public float velocityTransitionTime = 0.5f;

    public GameObject textObjectOn_;
    public GameObject textObjectOff_;

    // Start is called before the first frame update
    void Start()
    {
        textObjectOff_.SetActive(!autoHoverOn_);
        textObjectOn_.SetActive(autoHoverOn_);
        initialYForce = helicopterRigidbody.velocity.y;
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
        TutorialScript.collectiveInputEnable_ = true;
        autoHoverOn_ = false;
        GameManager.autoHoverOn_ = false ;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            if (TutorialScript.autoHoverButtonEnable)
            {
                UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UltimateXR.Core.UxrHandSide.Right, UltimateXR.Haptics.UxrHapticClipType.Click, 1f);
                TutorialScript.collectiveInputEnable_ = !TutorialScript.collectiveInputEnable_;
                targetHeight = heliTrans.position.y; // maintain current height
                helicopterRigidbody.useGravity = !helicopterRigidbody.useGravity;
                GameManager.autoHoverOn_ = !GameManager.autoHoverOn_;
                autoHoverOn_ = !autoHoverOn_;
                textObjectOff_.SetActive(!autoHoverOn_);
                textObjectOn_.SetActive(autoHoverOn_);
            }
            
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (autoHoverOn_)
        {

            helicopterRigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Force);

        }
        else
        {

        }
    }
    void Update()
    {
        if (autoHoverOn_)
        {
            AutoHover();
        }
    }
    void AutoHover()
    {
        currentY = helicopterRigidbody.velocity.x;
        helicopterRigidbody.velocity = new Vector3(helicopterRigidbody.velocity.x, initialYForce, helicopterRigidbody.velocity.z);
        /*
         float currentHeight = heliTrans.position.y;
         float distance = Mathf.Abs(targetHeight - currentHeight);
         float speed = Mathf.Lerp(val1, val2, distance / val3); // adjust speed smoothly

         Vector3 position = heliTrans.position;
         position.y = Mathf.Lerp(currentHeight, targetHeight, speed);
         heliTrans.position = position;
        */
    }
}
