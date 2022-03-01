using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static string P1name;
    public static string P2name;
    public static string P3name;
    public static string P4name;
    public static int roundNum;
    public static int playernumber;

    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player4Name;

    public string ingameName1;
    public string ingameName2;
    public string ingameName3;
    public string ingameName4;

    [Header("game number")]
    public int RoundNumber;
    public int currentRound;
    public int CurrentPlayer;

    [Header("Player score")]
    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;

    [Header("")]
    public bool penalty;

    [Header("Game turn")]
    public int turnCycle;

    public GameObject ScoreScreen;
    public GameObject penaltyScoreScreen;
    public GameObject PlayerIcon;

    public int place1;
    public int place2;
    public int place3;
    public int place4;

    bool placed1;
    bool placed2;
    bool placed3;
    bool placed4;

    [Header("scoreboard placement")]
    public Transform First;
    public Transform Second;
    public Transform Third;
    public Transform Fourth;
    public List<GameObject> playerScores = new List<GameObject>();

    //list for poits
    List<int> playerPoints;
    List<int> playerPointsSort;

    [Header("Name group")]
    //list for names
    public List<TextMeshProUGUI> p1Name = new List<TextMeshProUGUI> ();
    public List<TextMeshProUGUI> p2Name = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> p3Name = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> p4Name = new List<TextMeshProUGUI>();

    GameObject prevPlayerIcon;
    GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerPoints = new List<int> ();
        playerPointsSort = new List<int>();
        if (PlayerIcon != null)
        {
            PlayerIcon.transform.GetChild(0).gameObject.SetActive(true);
            prevPlayerIcon = PlayerIcon.transform.GetChild(0).gameObject;
        }
        


        ingameName1 = P1name;
        ingameName2 = P2name;
        ingameName3 = P3name;
        ingameName4 = P4name;

        RoundNumber = roundNum;
        if (playernumber != 0)
        {
            CurrentPlayer = playernumber;
        }
        else
        {
            CurrentPlayer = 2;
        }

        if(penaltyScoreScreen != null && ScoreScreen!=null)
        penaltyupdatescreen();

        turnCycle = 0;
        P1Score = 0;
        P2Score = 0;
        P3Score = 0;
        P4Score = 0;
        if(playerScores.Count != 0)
        {
            PointsList();
            NameInGame();
        }
        
    }

    public void UpdateName()
    {
        if (player1Name != null && player2Name != null && player3Name != null && player4Name != null)
        {
            P1name = player1Name.text;
            P2name = player2Name.text;
            P3name = player3Name.text;
            P4name = player4Name.text;
        }
    }

    //update list for scoreboard position
    void PointsList()
    {
        switch (CurrentPlayer)
        {
            case 2:
                playerPoints.Add(P1Score);
                playerPoints.Add(P2Score);
                playerPointsSort.Add(P1Score);
                playerPointsSort.Add(P2Score);
                playerScores[2].SetActive(false);
                playerScores[3].SetActive(false);
                break;
            case 3:
                playerPoints.Add(P1Score);
                playerPoints.Add(P2Score);
                playerPoints.Add(P3Score);
                playerPointsSort.Add(P1Score);
                playerPointsSort.Add(P2Score);
                playerPointsSort.Add(P3Score);
                playerScores[3].SetActive(false);
                break;
            case 4:
                playerPoints.Add(P1Score);
                playerPoints.Add(P2Score);
                playerPoints.Add(P3Score);
                playerPoints.Add(P4Score);
                playerPointsSort.Add(P1Score);
                playerPointsSort.Add(P2Score);
                playerPointsSort.Add(P3Score);
                playerPointsSort.Add(P4Score);
                break;
        }
    }

    void UpdateList()
    {
        switch (CurrentPlayer)
        {
            case 2:
                playerPoints[0] = P1Score;
                playerPoints[1] = P2Score;
                playerPointsSort[0] = P1Score;
                playerPointsSort[1] = P2Score;
                break;
            case 3:
                playerPoints[0] = P1Score;
                playerPoints[1] = P2Score;
                playerPoints[2] = P3Score;
                playerPointsSort[0] = P1Score;
                playerPointsSort[1] = P2Score;
                playerPointsSort[2] = P3Score;
                break;
            case 4:
                playerPoints[0] = P1Score;
                playerPoints[1] = P2Score;
                playerPoints[2] = P3Score;
                playerPoints[3] = P4Score;
                playerPointsSort[0] = P1Score;
                playerPointsSort[1] = P2Score;
                playerPointsSort[2] = P3Score;
                playerPointsSort[3] = P4Score;
                break;
        }
        playerPointsSort.Sort(new CustomComparer());
    }

    void penaltyupdatescreen()
    {
        GameObject Player3pen = penaltyScoreScreen.transform.GetChild(penaltyScoreScreen.transform.childCount - 2).gameObject;
        GameObject Player4pen = penaltyScoreScreen.transform.GetChild(penaltyScoreScreen.transform.childCount - 1).gameObject;
        GameObject Player3 = ScoreScreen.transform.GetChild(penaltyScoreScreen.transform.childCount - 2).gameObject;
        GameObject Player4 = ScoreScreen.transform.GetChild(penaltyScoreScreen.transform.childCount - 1).gameObject;

        switch (CurrentPlayer)
        {
            case 2:
                Player3pen.SetActive(false);
                Player4pen.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                break;
            case 3:
                Player4pen.SetActive(false);
                Player4.SetActive(false);
                break;
        }
            
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

        placed1 = true;
        placed2 = true;
        placed3 = true;
        placed4 = true;
        UpdateList();
        updateScorePosition();
        ScoreInGame();

        resetCycle();
        if (prevPlayerIcon != null)
            prevPlayerIcon.SetActive(false);

        if (turnCycle >= CurrentPlayer)
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
    void updateScorePosition()
    {
        switch (CurrentPlayer)
        {
            case 2:
                for(int a = 0;a < 2;a++)
                {
                    if (playerPoints[a] == playerPointsSort[0] && placed1)
                    {
                        place1 = a;
                        placed1 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[1] && placed2)
                    {
                        place2 = a;
                        placed2 = false;
                    }

                }
                break;
            case 3:
                for (int a = 0; a < 3; a++)
                {
                    if (playerPoints[a] == playerPointsSort[0] && placed1)
                    {
                        place1 = a;
                        placed1 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[1] && placed2)
                    {
                        place2 = a;
                        placed2 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[2] && placed3)
                    {
                        place3 = a;
                        placed3 = false;
                    }
                }
                break;
            case 4:
                for (int a = 0; a < 4; a++)
                {
                    if (playerPoints[a] == playerPointsSort[0] && placed1)
                    {
                        place1 = a;
                        placed1 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[1] && placed2)
                    {
                        place2 = a;
                        placed2 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[2] && placed3)
                    {
                        place3 = a;
                        placed3 = false;
                    }
                    else
                    if (playerPoints[a] == playerPointsSort[3] && placed4)
                    {
                        place4 = a;
                        placed4 = false;
                    }
                    
                }
                break;
        }
    }

    //penalty update button
    public void PlusPenaltyScore(int player)
    {
        switch (player)
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
    public void MinusPenaltyScore(int player)
    {
        switch (player)
        {
            case 1:
                P1Score -= 1;
                break;
            case 2:
                P2Score -= 1;
                break;
            case 3:
                P3Score -= 1;
                break;
            case 4:
                P4Score -= 1;
                break;

        }
    }

    //round and player number with menu button
    public void addPlayerNumber(int pNum)
    {
        playernumber = pNum;
    }

    public void addRoundNumber(int rNum)
    {
        roundNum = rNum;
    }

    //update name in game
    void NameInGame()
    {
        foreach(TextMeshProUGUI i in p1Name)
        {
            i.text = ingameName1;
        }
        foreach (TextMeshProUGUI i in p2Name)
        {
            i.text = ingameName2;
        }
        foreach (TextMeshProUGUI i in p3Name)
        {
            i.text = ingameName3;
        }
        foreach (TextMeshProUGUI i in p4Name)
        {
            i.text = ingameName4;
        }
    }

    //update position of score in game

    void ScoreInGame()
    {
        switch (CurrentPlayer)
        {
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    if (place1 == i)
                    {
                        playerScores[i].transform.position = First.position;
                    }
                    else if (place2 == i)
                    {
                        playerScores[i].transform.position = Second.position;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    if (place1 == i)
                    {
                        playerScores[i].transform.position = First.position;
                    }
                    else if (place2 == i)
                    {
                        playerScores[i].transform.position = Second.position;
                    }
                    else if (place3 == i)
                    {
                        playerScores[i].transform.position = Third.position;
                    }
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    if (place1 == i)
                    {
                        playerScores[i].transform.position = First.position;
                    }
                    else if (place2 == i)
                    {
                        playerScores[i].transform.position = Second.position;
                    }
                    else if (place3 == i)
                    {
                        playerScores[i].transform.position = Third.position;
                    }
                    else if (place4 == i)
                    {
                        playerScores[i].transform.position = Fourth.position;
                    }
                }
                break;

        }
        
    }
}

public class CustomComparer : IComparer<int>
{
    Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);

    public int Compare(int x, int y)
    {
        // Convert string comparisons to int
        return _comparer.Compare(x, y);
    }
}