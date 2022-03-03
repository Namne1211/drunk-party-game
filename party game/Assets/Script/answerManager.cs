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
                    answer.text = "World Wide Web";
                    break;
                case 2:
                    answer.text = "Asia, Africa, North America, South America, Antarctica, Europe and Australia";
                    break;
                case 3:
                    answer.text = "Nile";
                    break;
                case 4:
                    answer.text = "Coca-Cola";
                    break;
                case 5:
                    answer.text = "Vatican";
                    break;
                case 6:
                    answer.text = "Honey";
                    break;
                case 7:
                    answer.text = "Venus";
                    break;
                case 8:
                    answer.text = "Alfred";
                    break;
                case 9:
                    answer.text = "Vodka";
                    break;
                case 10:
                    answer.text = "National Aeronautics and Space Administration";
                    break;
            }
        }
        else
        {
            answer.text = "";
        }
    }
}
