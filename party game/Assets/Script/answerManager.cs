using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class answerManager : MonoBehaviour
{

    public GameObject cardHolder;
    public GameObject gameManager;
    public TextMeshProUGUI answer;
    MiniGameInstantiate mi;
    // Start is called before the first frame update
    void Start()
    {
        if(gameManager != null)
        mi= gameManager.GetComponent<MiniGameInstantiate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mi.ingame == false)
        {
            switch (cardHolder.GetComponentInChildren<Minigame>().questionIndex)
            {
                case 0:
                    answer.text = "";
                    break;
                case 1:
                    answer.text = "";
                    break;
                case 2:
                    answer.text = "";
                    break;
                case 3:
                    answer.text = "";
                    break;
                case 4:
                    answer.text = "";
                    break;
                case 5:
                    answer.text = "";
                    break;
                case 6:
                    answer.text = "";
                    break;
                case 7:
                    answer.text = "";
                    break;
                case 8:
                    answer.text = "";
                    break;
                case 9:
                    answer.text = "";
                    break;
                case 10:
                    answer.text = "";
                    break;
            }
        }
        else
        {
            answer.text = "";
        }
    }
}
