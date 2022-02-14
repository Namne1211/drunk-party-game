using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInstantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Minigame> card = new List<Minigame>();
    public GameObject Holder;
    public GameObject UICam;
    GameObject prevActive;
    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        runCycle();
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

    void runCycle()
    {
        
        if (prevActive != null)
            prevActive.SetActive(false);
        int randomChildIdx = Random.Range(0, Holder.transform.childCount);
        GameObject randomChild = Holder.transform.GetChild(randomChildIdx).gameObject;
        prevActive = randomChild;
        randomChild.SetActive(true);
    }
}
