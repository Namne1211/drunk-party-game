using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroFunc : MonoBehaviour
{
    public GameObject balanceGame;
    public GameObject Firstpos;
    public GameObject SecondPos;
    public GameObject ThirdPos;
    Rigidbody2D rb;
    float AngleX;
    float rotationRate = 30f;
    float RandomAngle;
    float ChgDirtime;
    bool chgDir=true;
    public float ClampRate=30f;

    // Start is called before the first frame update
    void Start()
    {
        
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (balanceGame != null)
        {
            if(balanceGame.GetComponent<acceleratorTest>() != null)
            {
                if ((balanceGame.GetComponent<acceleratorTest>().winAble) &&
                    (balanceGame.GetComponent<acceleratorTest>().timeLeft > 0 && balanceGame.GetComponent<acceleratorTest>().CountDownTime < 0))
                {
                    RandomRotate();

                }
                else
                {
                    rb.angularVelocity = 0;
                    transform.eulerAngles = new Vector3(0, 0, 0);                   
                }
            }
        }
        if (balanceGame.GetComponent<acceleratorTest>().win)
        {
            ThirdPos.SetActive(true);
            Firstpos.SetActive(false);
            SecondPos.SetActive(false);
        }

    }

    //random rotate some angle 
    void RandomRotate()
    {
        ChgDirtime -= Time.deltaTime;

        AngleX = -Input.acceleration.x * rotationRate;
        if (chgDir)
        {
            ChgDirtime = 2f;
            RandomAngle = Random.Range(-0.7f, 0.7f)*rotationRate;
            chgDir = false;
        }
        if (ChgDirtime < 0)
        {
            chgDir = true;
        }

        rb.angularVelocity = RandomAngle;

        if ((transform.eulerAngles.z >= 14 && transform.eulerAngles.z <= ClampRate) || (transform.eulerAngles.z <= 360-14 && transform.eulerAngles.z >= 360-ClampRate))
        { 
            SecondPos.SetActive(true);
            Firstpos.SetActive(false);
        }
        else
        {
            SecondPos.SetActive(false);
            Firstpos.SetActive(true);
        }


            //clamp the angle
            if (transform.eulerAngles.z <= 180)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(transform.rotation.eulerAngles.z, 0, ClampRate));
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(transform.rotation.eulerAngles.z, 360f - ClampRate, 360f));
        }

        //rotate base on the phone accelerator
        rb.angularVelocity += Mathf.Clamp(AngleX, -15f, 15f);
        
    }
    
}
