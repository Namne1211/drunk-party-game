using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceleratorTest : MonoBehaviour
{
    public GameObject beer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude > 30f)
        {
            beer.SetActive(true);
        }
            
        
    }
}
