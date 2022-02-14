using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class acceleratorTest : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public GameObject button;
    public GameObject beer;
    //public GameObject NormalButton;
    //public GameObject textholder;
    float timeLeft;
    bool winAble;
    bool win;
    public float CountDownTime = 3f;
    bool startCountDown=false;
    // Start is called before the first frame update
    void Start()
    {
        //GameStart();
    }

    private void OnEnable()
    {
        CountDownTime = 3f;
        startCountDown = false;
        timeLeft = 5f;
        winAble=true;
        win=false;
        button.SetActive(true);
        //NormalButton.SetActive(false);
    }

    private void OnDisable()
    {
        beer.SetActive(false);
        //NormalButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {


        
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
        }
        
        swingGame();
        //shakeGame();
    }

    public void GameStart()
    {

        button.SetActive(false);
        startCountDown = true;
        win = false;
        winAble = true;
        timeLeft =5f;
    }

    void swingGame()
    {
        if (CountDownTime < 0)
        {
            if (timeLeft > 0)
            {
                if (Input.acceleration.sqrMagnitude > 80f && winAble)
                {
                    
                    win = true;
                    beer.SetActive(true);
                }
            }
            else if (win == false)
            {
                tmp.text = "lose";
                winAble = false;
                //lose
                //Debug.Log("lose");
            }
        }

        if (win)
        {
            tmp.text = "win";
        }

    }

    void shakeGame()
    {
        if (CountDownTime < 0)
        {
            if (timeLeft > 0)
            {
                if (Input.acceleration.sqrMagnitude < 1f)
                {
                    win = false;
                    //lose
                    tmp.text = "lose";
                    winAble = false;
                }

            }
            else if (timeLeft < 0 && winAble == true)
            {
                win = true;
                tmp.text = "win";
                beer.SetActive(true);
            }
        }
        //Debug.Log(Input.acceleration.sqrMagnitude);
    }
}
