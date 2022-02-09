using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentPlayer;
    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;
    public int turnCycle;
    public GameObject PlayerIcon;
    GameObject prevPlayerIcon;
    GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIcon.transform.GetChild(0).gameObject.SetActive(true);
        prevPlayerIcon = PlayerIcon.transform.GetChild(0).gameObject;
        
        CurrentPlayer =4;
        turnCycle = 0;
        P1Score = 0;
        P2Score = 0;
        P3Score = 0;
        P4Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //resetCycle();
    }
    
    public void PointUpdate()
    {       
        switch (turnCycle)
        {
            case 1:
                P1Score += 1;
                break;
            case 2:
                P2Score += 1;
                break;
            case 3:
                P3Score += 1;
                break;
            case 4:
                P4Score += 1;
                break;
        }
    }
    public void UpdateIcon()
    {
        if (prevPlayerIcon != null)
        prevPlayerIcon.SetActive(false);
        resetCycle();
        if(turnCycle >= CurrentPlayer)
        {
            currentPlayer = PlayerIcon.transform.GetChild(0).gameObject;
        }
        else
        {
            currentPlayer = PlayerIcon.transform.GetChild(turnCycle).gameObject;
        }
        
        prevPlayerIcon = currentPlayer;
        currentPlayer.SetActive(true);
    }
    void resetCycle()
    {
        if (turnCycle > CurrentPlayer )
        {
            turnCycle = 1;
        }
    }
}
