
using UnityEngine;

public class LiftScript : MonoBehaviour
{
   
    public Rigidbody rb;
    public float maxDownForce;
    public float liftForce = 10f;
    private float MaxLiftForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Debug.Log("Lift");
        if (TutorialScript.collectiveInputEnable_)
        {
            Vector3 downForce = -(transform.up * Physics.gravity.magnitude) * maxDownForce;
            if (LiftInput.currentLiftInput <= 0)
            {
                MaxLiftForce = LiftInput.currentLiftInput * 10 * liftForce * 2 / 10;
            }
            else
            {
                MaxLiftForce = LiftInput.currentLiftInput * 10 * liftForce / 10;
            }
            HandleLift();
            Vector3 cyclicForce = transform.up *
                    (UnityEngine.Physics.gravity.magnitude + MaxLiftForce) * rb.mass;

            cyclicForce *= Mathf.Pow(5, 0);

            rb.AddForce(downForce, ForceMode.Force);
            rb.AddForce(cyclicForce, ForceMode.Force);
        }


        
    }

    void HandleLift()
    {
        //Vector3 LiftForce = transform.up * MaxLiftForce2 ;
        // Vector3 DownForce = transform.up * -2;
        //rb.AddForce( LiftForce, ForceMode.Force);
        // rb.AddForce( DownForce);

        //Vector3 liftForce = transform.up *
                //(UnityEngine.Physics.gravity.magnitude + MaxLiftForce) * rb.mass;
        //liftForce *= Mathf.Pow(LiftInput.currentLiftInput, 2) * Mathf.Pow(1, 2f);

       // rb.AddForce(liftForce, ForceMode.Force);
    }

}
