using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penaltyIcon : MonoBehaviour
{
    public GameObject GameManager;
    ScoreManager sm;
    public GameObject PenaltyHolder;
    GameObject prevIcon;

    // Start is called before the first frame update
    void Start()
    {
            sm = GameManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (sm.CurrentPlayer)
        {
            case 2:
                for (int i = 0; i<2; i++){
                    if (sm.place2 == i)
                    {
                        if(prevIcon != null)
                            prevIcon.SetActive(false);
                        PenaltyHolder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = PenaltyHolder.transform.GetChild(i).gameObject;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    if (sm.place3 == i)
                    {
                        if (prevIcon != null)
                            prevIcon.SetActive(false);
                        PenaltyHolder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = PenaltyHolder.transform.GetChild(i).gameObject;
                    }
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    if (sm.place4 == i)
                    {
                        if (prevIcon != null)
                            prevIcon.SetActive(false);
                        PenaltyHolder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = PenaltyHolder.transform.GetChild(i).gameObject;
                    }
                }
                break;
        }
    }
}
