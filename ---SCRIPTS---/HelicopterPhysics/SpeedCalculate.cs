using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedCalculate : MonoBehaviour
{
    float deltaTime;
    //public TMP_Text text;
    //public TMP_Text rotationtext;
    float xzSpeed;
    float speed;
    float rotationSpeed;
    float liftSpeed;
    float xSpeed;
    float fowardSpeed;
    public static float speedInput;
    public static float liftSpeedInput;
    Vector3 oldPosition;
    float oldRotationY;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime);
    }
    void FixedUpdate()
    {
        SpeedCheck();
    }
    void SpeedCheck()
    {
        
        speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        rotationSpeed = (Mathf.Abs(oldRotationY - transform.rotation.y)*100f);
        liftSpeed = (oldPosition.y - transform.position.y) * 100f;
        xSpeed = (oldPosition.x - transform.position.x) * 100f;
        liftSpeedInput = (liftSpeed / 35);
        if (liftSpeed <0)
        {
            liftSpeed = -liftSpeed;
        }
        if (xSpeed <0)
        {
            xSpeed = -xSpeed;
        }
        xzSpeed = Mathf.Sqrt((speed * speed) - (liftSpeed * liftSpeed)) ;
        fowardSpeed = Mathf.Sqrt((xzSpeed * xzSpeed) - (xSpeed * xSpeed));
        speedInput = (xzSpeed / 35);
        
        /*
        if (CyclicScript.movementInput >= 0.01f)
        {
            speedInput = (fowardSpeed / 35);

        }
        else
        {
            //speed = 0;
        }
        */
        //text.text = deltaTime.ToString();
        //rotationtext.text = rotationSpeed.ToString();
        oldPosition = transform.position;
        oldRotationY = transform.rotation.y;





    }
}
