using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroFunc : MonoBehaviour
{
    Rigidbody2D rb;
    float AngleX;
    float rotationRate = 20f;
    float timeLeft=5f;
    float RandomAngle;
    float ChgDirtime;
    bool chgDir=true;
    public float ClampRate=15f;

    // Start is called before the first frame update
    void Start()
    {

        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ChgDirtime -= Time.deltaTime;
        timeLeft -= Time.deltaTime;
        
        AngleX = -Input.acceleration.x * rotationRate;

        RandomRotate();

        //clamp the angle
        if (transform.eulerAngles.z <= 180)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(transform.rotation.eulerAngles.z, 0, ClampRate));
        }else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(transform.rotation.eulerAngles.z, 360f - ClampRate, 360f));
        }
        
        //rotate base on the phone accelerator
        rb.angularVelocity += Mathf.Clamp(AngleX, -15f, 15f);


    }

    //random rotate some angle 
    void RandomRotate()
    {
        if (chgDir)
        {
            ChgDirtime = 2f;
            RandomAngle = Random.Range(-0.4f, 0.4f)*rotationRate;
            chgDir = false;
        }
        if (ChgDirtime < 0)
        {
            chgDir = true;
        }
        /*        if (transform.rotation.eulerAngles.z < 15 && transform.rotation.eulerAngles.z > -15)
                {*/
        //transform.Rotate(new Vector3(0, 0, RandomAngle));
        //}
        rb.angularVelocity = RandomAngle;

        




    }
    
}
