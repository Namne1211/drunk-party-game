using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class penaltyScore : MonoBehaviour
{
    public List<TextMeshProUGUI> scoreText= new List<TextMeshProUGUI>();

    List<int> scoreList;


    // Start is called before the first frame update
    void Start()
    {
        scoreList = new List<int>();
        scoreList.Add(0);
        scoreList.Add(0);
        scoreList.Add(0);
        scoreList.Add(0);
    }

    private void OnEnable()
    {
        for(int i = 0; i < 4; i++)
        {
            scoreList[i] = 0;
        }
    }

    void Update()
    {
        if(scoreText.Count > 0)
        for (int i = 0; i < 4; i++)
        {
            scoreText[i].text = scoreList[i].ToString();
        }
    }

    public void plusPoint(int a)
    {
        scoreList[a] += 1;
    }
    public void minusPoint(int a)
    {
        scoreList[a] -= 1;
    }
}
