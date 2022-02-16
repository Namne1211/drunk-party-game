using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class acceleratorTest : MonoBehaviour
{
    //balance Game
    Rigidbody2D rb;
    public GameObject balanceObj;
    public float loseRate = 12f;
    //swing and shake game
    public TextMeshPro tmp;
    public GameObject beer;

    public GameObject GameManager;
    public int GameNum;

    //timer and win condition
    public float timeLeft;
    bool done;
    public bool winAble;
    bool win;
    public float CountDownTime = 3f;
    bool startCountDown=false;
    [SerializeField]
    bool endRound;
    public GameObject StartButton;
    public GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        //GameStart();
    }

    private void OnEnable()
    {
        if(balanceObj!=null)
            rb = balanceObj.GetComponent<Rigidbody2D>();
        done = true;
        StartButton.SetActive(true);   
        BackButton.SetActive(false);
        CountDownTime = 3f;
        startCountDown = false;
        timeLeft = 5f;
        winAble=true;
        win=false;
        tmp.text = "";
        //NormalButton.SetActive(false);
    }

    private void OnDisable()
    {
        beer.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<MiniGameInstantiate>().ScoreSceen.active)
        { 
            endRound = true;
        }
        else
        {
            endRound = false;
        }

            if (startCountDown && CountDownTime > 0)
        {
            tmp.text = Mathf.Round(CountDownTime).ToString();
            CountDownTime -= Time.deltaTime;
        }
            
        if(CountDownTime < 0)
        {

            tmp.text = "";
            timeLeft -= Time.deltaTime;
            //textholder.SetActive(false);
            switch (GameNum)
            {
                case 1:
                    swingGame();
                    break;
                case 2:
                    shakeGame();
                    break;
                case 3:
                    BalanceGame();
                    break;
            }
        }

        

    }

    public void GameStart()
    {
        StartButton.SetActive(false);
        startCountDown = true;
        win = false;
        winAble = true;
        timeLeft =5f;
    }

    void swingGame()
    {
        if (timeLeft > 0)
        {
            if (Input.acceleration.sqrMagnitude > 50f && winAble)
            {
                win = true;
                GameManager.GetComponent<MiniGameInstantiate>().Done();
                beer.SetActive(true);
                winAble = false;
            }
        }
        else if (timeLeft<0 &&winAble)
        {
            win = false;
            GameManager.GetComponent<MiniGameInstantiate>().NotDone();
            winAble = false;
        }

        if (winAble == false)
        {
            BackButton.SetActive(true);
            if (win)
            {
                tmp.text = "win";
            }
            else
            {
                tmp.text = "lose";
            }
        }
    }

    void shakeGame()
    {
        if (timeLeft > 0)
        {
            if (Input.acceleration.sqrMagnitude < 1f &&winAble)
            {
                win = false;
                GameManager.GetComponent<MiniGameInstantiate>().NotDone();
                tmp.text = "lose";
                winAble = false;
            }

        }
        else if (timeLeft < 0 && winAble == true)
        {
            win = true;
            GameManager.GetComponent<MiniGameInstantiate>().Done();
            winAble = false;
            beer.SetActive(true);
        }
        if (winAble == false)
        {
            BackButton.SetActive(true);
            if (win)
            {
                tmp.text = "win";
            }
            else
            {
                tmp.text = "lose";
            }
        }
    }
    void BalanceGame()
    {
        
        if (timeLeft > 0)
        {
            if ((balanceObj.transform.eulerAngles.z < 180 && balanceObj.transform.eulerAngles.z > loseRate) ||
                (balanceObj.transform.eulerAngles.z < 360 - loseRate && balanceObj.transform.eulerAngles.z > 180)
                && winAble)
            {
                timeLeft = 0;
                win = false;               
                winAble = false;
                GameManager.GetComponent<MiniGameInstantiate>().NotDone();
            }
        }else if(timeLeft<0 && winAble==true)
        {
            win = true;
            GameManager.GetComponent<MiniGameInstantiate>().Done();
            winAble = false;
        }

        if (winAble == false)
        {
            BackButton.SetActive(true);
            if (win)
            {
                tmp.text = "win";
            }
            else
            {
                tmp.text = "lose";
            }
        }


    }

    public void Back()
    {
        this.gameObject.SetActive(false);
        if (endRound==false)
        {
            GameManager.GetComponent<MiniGameInstantiate>().cardScreen.SetActive(true);
            GameManager.GetComponent<ScoreManager>().PlayerIcon.SetActive(true);
        }       
        
    }
}
