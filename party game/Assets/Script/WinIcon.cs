using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinIcon : MonoBehaviour
{
    public GameObject GameManager;
    ScoreManager sm;
    bool active;
    public GameObject Holder;
    GameObject prevIcon;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameManager.GetComponent<ScoreManager>();
    }


    private void OnEnable()
    {
        active=true; 
    }
    // Update is called once per frame
    private void Update()
    {
        switch (sm.CurrentPlayer)
        {
            case 2:
                if(active)
                for (int i = 0; i < 2; i++)
                {
                    if (sm.place1 == i)
                    {
                        if (prevIcon != null)
                            prevIcon.SetActive(false);
                        Holder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = Holder.transform.GetChild(i).gameObject;
                            active = false;
                    }
                }
                break;
            case 3:
                if (active)
                    for (int i = 0; i < 3; i++)
                {
                    if (sm.place1 == i)
                    {
                        if (prevIcon != null)
                            prevIcon.SetActive(false);
                        Holder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = Holder.transform.GetChild(i).gameObject;
                            active = false;
                        }
                }
                break;
            case 4:
                if (active)
                    for (int i = 0; i < 4; i++)
                {
                    if (sm.place1 == i)
                    {
                        if (prevIcon != null)
                            prevIcon.SetActive(false);
                        Holder.transform.GetChild(i).gameObject.SetActive(true);
                        prevIcon = Holder.transform.GetChild(i).gameObject;
                            active = false;
                        }
                }
                break;
        }
    }
}
