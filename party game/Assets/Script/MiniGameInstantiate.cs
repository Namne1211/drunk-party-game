using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameInstantiate : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game Camera")]
    public GameObject UICam;
    public GameObject ARCam;
    [Header("Game Sceen")]
    public GameObject PenaltyScreen;
    public GameObject currentScreen;
    public GameObject cardScreen;
    public GameObject ScoreSceen;
    [Header("Card Holder")]
    public GameObject Holder;
    public GameObject PenaltyHolder;
    [Header("Game Text")]
    public TextMeshProUGUI p1Score;
    public TextMeshProUGUI p2Score;
    public TextMeshProUGUI p3Score;
    public TextMeshProUGUI p4Score;
    [Header("")]
    public GameObject normalText;
    public GameObject interactiveText;
    public string Currentinteractive;

    [Header("interactive")]
    public GameObject SwingGame;
    public GameObject ShakeGame;
    public GameObject BalanceGame;
    public bool ingame;
    public bool penaltystate;
    GameObject prevActive;
    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        runCycle();
        ARCam.SetActive(false);
    }
    private void Update()
    {
        casePenalty();
        ScoreBoardUpdate();

        if (Currentinteractive != "")
        {
            ingame = true;
        }
        else
        {
            ingame = false;
        }
    }

    public void Done()
    {
        scoreManager.turnCycle += 1;
        scoreManager.UpdateIcon();
        runCycle();
    }
    public void NotDone()
    {
        scoreManager.turnCycle += 1;
        scoreManager.UpdateIcon();
        scoreManager.PointUpdate();
        runCycle();
    }

    public void ARON()
    {
        if (PenaltyScreen.active == true)
        {
            if (prevActive != null)
                prevActive.SetActive(false);
            int randomChildIdx = Random.Range(0, PenaltyHolder.transform.childCount);
            GameObject randomChild = PenaltyHolder.transform.GetChild(randomChildIdx).gameObject;
            prevActive = randomChild;
            randomChild.SetActive(true);
            penaltystate = true;
        }
        
        UICam.SetActive(false);
        ARCam.SetActive(true);
    }
    public void AROff()
    {
        
        UICam.SetActive(true);
        ARCam.SetActive(false);
        scoreManager.PlayerIcon.SetActive(true);

        //case of penalty screen 
        if (ingame && penaltystate)
        {
            cardScreen.SetActive(true);
            PenaltyScreen.SetActive(false);
            currentScreen.SetActive(false);
            penaltystate = false;

        }
        else if(ingame)
        {
            switch (Currentinteractive)
            {
                case "Swing Game":
                    SwingGame.SetActive(true);
                    cardScreen.SetActive(false);
                    PenaltyScreen.SetActive(false);
                    currentScreen.SetActive(false);
                    GetComponent<ScoreManager>().PlayerIcon.SetActive(false);
                    break;

                case "Shake Game":
                    ShakeGame.SetActive(true);
                    cardScreen.SetActive(false);
                    PenaltyScreen.SetActive(false);
                    currentScreen.SetActive(false);
                    GetComponent<ScoreManager>().PlayerIcon.SetActive(false);
                    break;

                case "Balance Game":
                    BalanceGame.SetActive(true);
                    cardScreen.SetActive(false);
                    PenaltyScreen.SetActive(false);
                    currentScreen.SetActive(false);
                    GetComponent<ScoreManager>().PlayerIcon.SetActive(false);
                    break;
            }
        }
        else if (penaltystate)
        {            
            cardScreen.SetActive(true);
            PenaltyScreen.SetActive(false);
            currentScreen.SetActive(false);
            runCycle();
            penaltystate = false;
        }
        else
        {
            cardScreen.SetActive(false);
            PenaltyScreen.SetActive(false);
            currentScreen.SetActive(true);
        }

    }
    public void cardscreen()
    {
        cardScreen.SetActive(true);
        PenaltyScreen.SetActive(false);
        currentScreen.SetActive(false);
    }
    void runCycle()
    {

        if (prevActive != null)
            prevActive.SetActive(false);
        int randomChildIdx = Random.Range(0, Holder.transform.childCount);
        GameObject randomChild = Holder.transform.GetChild(randomChildIdx).gameObject;
        if (randomChild.GetComponent<Minigame>() != null)
        {
            Currentinteractive = "";
            normalText.SetActive(true);
            interactiveText.SetActive(false);
        }
        else
        {
            Currentinteractive = randomChild.name;
            normalText.SetActive(false);
            interactiveText.SetActive(true);
        }
        prevActive = randomChild;
        randomChild.SetActive(true);
    }
    public void ToPunish()
    {
        PenaltyScreen.SetActive(true);
        ScoreSceen.SetActive(false);
    }
    void casePenalty()
    {
        if (scoreManager.penalty)
        {
            scoreManager.PlayerIcon.SetActive(false);
            cardScreen.SetActive(false);
            currentScreen.SetActive(false);
            PenaltyScreen.SetActive(false);
            ScoreSceen.SetActive(true);
            scoreManager.turnCycle = 0;
            scoreManager.penalty = false;
        }
    }

    void ScoreBoardUpdate()
    {
        switch (scoreManager.CurrentPlayer)
        {
            case 2:
                p1Score.text = scoreManager.P1Score.ToString();
                p2Score.text = scoreManager.P2Score.ToString();
                break;
            case 3:
                p1Score.text = scoreManager.P1Score.ToString();
                p2Score.text = scoreManager.P2Score.ToString();
                p3Score.text = scoreManager.P3Score.ToString();
                break;
            case 4:
                p1Score.text = scoreManager.P1Score.ToString();
                p2Score.text = scoreManager.P2Score.ToString();
                p3Score.text = scoreManager.P3Score.ToString();
                p4Score.text = scoreManager.P4Score.ToString();
                break;
        }


    }
}
