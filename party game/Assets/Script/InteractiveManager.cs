using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
    MiniGameInstantiate mi;
    public GameObject SwingGame;
    public GameObject ShakeGame;
    public GameObject BalanceGame;
    bool ingame;
    // Start is called before the first frame update
    void Start()
    {
        mi = GetComponent<MiniGameInstantiate>();
    }
    private void Update()
    {
        CheckInteractive();
    }
    public void CheckInteractive()
    {
        if (mi.Currentinteractive != "")
        {
            ingame = false;
        }
        switch (mi.Currentinteractive)
        {
            case "Swing Game":
                ingame = true;
                break;

            case "Shake Game":
                ingame = true;
                break;

            case "Balance Game":
                
                break;
        }
    }
}
