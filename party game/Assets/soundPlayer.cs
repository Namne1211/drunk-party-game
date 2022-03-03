using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundPlayer : MonoBehaviour
{

    public static bool musicPlay;
    public static bool effectPlay;
    public GameObject musicSrc;
    public GameObject effectSrc;
    public GameObject musicButton;
    public GameObject effectButton;
    Toggle tgm;
    Toggle tge;
    // Start is called before the first frame update
    void Start()
    {
        if(musicButton != null&& effectButton != null)
        {
            tgm=musicButton.GetComponent<Toggle>();
            tge=effectButton.GetComponent<Toggle>();
        }
        AdjustMusic();
        AdjustEffect();

        if(musicSrc != null)
        if (musicPlay == false)
        {
            musicSrc.SetActive(false);
        }
        if(effectSrc != false)
        if(effectPlay == false)
        {
            effectSrc.SetActive(false);
        }
        Debug.Log(musicPlay);
    }

    public void AdjustMusic()
    {
        if (tgm != null)
        {
            if (tgm.isOn)
            {
                musicPlay = true;
            }
            else
            {
                musicPlay = false;
            }
        }
    }

    public void AdjustEffect()
    {
        if (tge != null)
        {
            if (tge.isOn)
            {
                effectPlay = true;
            }
            else
            {
                effectPlay = false;
            }
        }
    }
}
