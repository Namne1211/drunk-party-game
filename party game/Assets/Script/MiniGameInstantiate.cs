using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInstantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Minigame> card = new List<Minigame>();
    public GameObject Holder;
    public GameObject UICam;
    public GameObject ARCam;
    public GameObject PenaltyScreen;
    public GameObject currentScreen;
    public GameObject cardScreen;
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
    }

    public void Done()
    {
        scoreManager.turnCycle += 1;
        scoreManager.UpdateIcon();
        scoreManager.PointUpdate();
        runCycle();
    }
    public void NotDone()
    {
        scoreManager.turnCycle += 1;
        scoreManager.UpdateIcon();
        runCycle();  
    }
    public void ARON()
    {       
        UICam.SetActive(false);
        ARCam.SetActive(true);
    }
    public void AROff()
    {
        UICam.SetActive(true);
        ARCam.SetActive(false);
        scoreManager.PlayerIcon.SetActive(true);
        cardScreen.SetActive(false);
        PenaltyScreen.SetActive(false);
        currentScreen.SetActive(true);
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
        prevActive = randomChild;
        if(randomChild.GetComponent<Minigame>() != null)
        {
            //Debug.Log("normal");
        }
        randomChild.SetActive(true);
    }
    void casePenalty()
    {
        if (scoreManager.penalty)
        {
            scoreManager .PlayerIcon.SetActive(false);
            currentScreen.SetActive(false);
            PenaltyScreen.SetActive(true);
            scoreManager.turnCycle = 1;
            scoreManager.penalty = false;
        }
    }
}
