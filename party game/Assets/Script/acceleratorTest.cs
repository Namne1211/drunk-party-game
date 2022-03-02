using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class acceleratorTest : MonoBehaviour
{
    //balance Game
    Rigidbody2D rb;
    public GameObject balanceObj;
    public float loseRate = 22f;

    //swing and shake game
    public TextMeshPro tmp;
    public float WinCounter;
    public GameObject GameManager;
    public int GameNum;

    //timer and win condition
    public float timeLeft;
    bool done;
    public bool winAble;
    public bool win;
    public float CountDownTime = 3f;
    bool startCountDown=false;
    [SerializeField]
    bool endRound;
    public GameObject manual;
    public GameObject character;
    public GameObject StartButton;
    public GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        //GameStart();
    }

    private void OnEnable()
    {
        manual.SetActive(true);
        WinCounter =0;
        if(balanceObj!=null)
            rb = balanceObj.GetComponent<Rigidbody2D>();
        done = true;
        StartButton.SetActive(true);   
        BackButton.SetActive(false);
        CountDownTime = 3f;
        startCountDown = false;
        timeLeft = 10f;
        winAble=true;
        win=false;
        tmp.text = "";
        //NormalButton.SetActive(false);
    }

    private void OnDisable()
    {

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
        manual.SetActive(false);
        StartButton.SetActive(false);
        startCountDown = true;
        win = false;
        winAble = true;
        SoundManagerScript.PlaySound("countDown");
    }

    void swingGame()
    {
        if (timeLeft > 0)
        {
            if (Input.acceleration.sqrMagnitude > 60f && winAble)
            {
                SoundManagerScript.PlaySound("Breaks");
                if(character!=null)
                    character.GetComponent<Animator>().SetTrigger("Win");
                win = true;
                GameManager.GetComponent<MiniGameInstantiate>().Done();
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
            if (Input.acceleration.sqrMagnitude < 2f )
            {
                if (character != null)
                {

                    character.GetComponent<Animator>().SetBool("shake",false);
                }                 
                WinCounter = WinCounter;                
            }
            else
            {
                if (character != null)
                {
                    SoundManagerScript.PlaySound("shake");
                    character.GetComponent<Animator>().SetBool("shake", true);
                }
                WinCounter += Time.deltaTime;
            }
            if(WinCounter > 5f && winAble)
            {
                if (character != null)
                {
                    SoundManagerScript.PlaySound("pop");
                    character.GetComponent<Animator>().SetTrigger("pop");
                }
                win = true;
                GameManager.GetComponent<MiniGameInstantiate>().Done();
                winAble = false;
            }
            

        }
        else if (timeLeft < 0 && winAble)
        {
            win = false;
            GameManager.GetComponent<MiniGameInstantiate>().NotDone();
            tmp.text = "lose";
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
    void BalanceGame()
    {
        
        if (timeLeft > 0)
        {
            if ((balanceObj.transform.eulerAngles.z < 180 && balanceObj.transform.eulerAngles.z > loseRate) ||
                (balanceObj.transform.eulerAngles.z < 360 - loseRate && balanceObj.transform.eulerAngles.z > 180)
                && winAble)
            {
                SoundManagerScript.PlaySound("BalanceLose");
                timeLeft = 0;
                win = false;               
                winAble = false;
                GameManager.GetComponent<MiniGameInstantiate>().NotDone();
            }
        }else if(timeLeft<0 && winAble==true)
        {
            SoundManagerScript.PlaySound("BalanceWin");
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
