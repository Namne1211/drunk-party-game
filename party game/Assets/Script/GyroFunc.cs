using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroFunc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            //transform.rotation = gyroToUnity(Input.gyro.attitude);
            
        }
    }

    private Quaternion gyroToUnity(Quaternion q)
    {
        return new Quaternion(-q.x, q.y, 0, 0);
    }
        
    
}
