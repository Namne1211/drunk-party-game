using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static string P1name;
    public static string P2name;
    public static string P3name;
    public static string P4name;
    public int CurrentPlayer;
    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;
    public bool penalty;
    public int turnCycle;
    public int turn;
    public GameObject PlayerIcon;
    GameObject prevPlayerIcon;
    GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIcon.transform.GetChild(0).gameObject.SetActive(true);
        prevPlayerIcon = PlayerIcon.transform.GetChild(0).gameObject;

        
        turnCycle = 0;
        P1Score = 0;
        P2Score = 0;
        P3Score = 0;
        P4Score = 0;
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
    //update player icon and penalty icon
    public void UpdateIcon()
    {
        resetCycle();
        if (prevPlayerIcon != null)
        prevPlayerIcon.SetActive(false);
        
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
    //reset the player cycle
    void resetCycle()
    {
        if (turnCycle == CurrentPlayer)
        {
            penalty = true;
            //turnCycle = 1;
        }
    }
}
