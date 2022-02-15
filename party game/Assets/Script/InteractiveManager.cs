using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
    MiniGameInstantiate mi;
    // Start is called before the first frame update
    void Start()
    {
        mi.GetComponent<MiniGameInstantiate>();
    }

    public void CheckInteractive()
    {
        if (mi.Currentinteractive != "")
        {
            Debug.Log("normal");
        }
        switch (mi.Currentinteractive)
        {
            case "Swing Game":

                break;
        }
    }
}
