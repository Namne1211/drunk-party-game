using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip addPlayer,menuClick,takeDrink,pop,shake,countDown,BDrum,Bwin,Blose,breaks;
    public bool musicPlay;
    public bool effectPlay;
    static AudioSource audioSrc;
    public GameObject gameMusic;
    public GameObject gameEffect;
    void Start()
    {
        addPlayer = Resources.Load<AudioClip>("Audio/addPlayer");
        menuClick = Resources.Load<AudioClip>("Audio/menuClick");
        takeDrink = Resources.Load<AudioClip>("Audio/take drink");
        pop = Resources.Load<AudioClip>("Audio/Pop");
        shake = Resources.Load<AudioClip>("Audio/Shake");
        countDown = Resources.Load<AudioClip>("Audio/countDown");
        BDrum = Resources.Load<AudioClip>("Audio/BalanceDrum");
        Blose = Resources.Load<AudioClip>("Audio/BalanceWin");
        Bwin = Resources.Load<AudioClip>("Audio/BalanceLose");
        breaks = Resources.Load<AudioClip>("Audio/Breaks");
        audioSrc = GetComponent<AudioSource>();
        
    }
    
   


    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "addplayer":
                audioSrc.PlayOneShot(addPlayer);
                audioSrc.loop = false;
                break;
            case "menuclick":
                audioSrc.PlayOneShot(menuClick);
                audioSrc.loop = false;
                break;
            case "drink":
                audioSrc.PlayOneShot(takeDrink);
                audioSrc.loop = false;
                break;
            case "shake":
                audioSrc.PlayOneShot(shake);
                audioSrc.loop = true;
                break;
            case "pop":
                audioSrc.PlayOneShot(pop);
                audioSrc.loop = false;
                break;
            case "countDown":
                audioSrc.PlayOneShot(countDown);
                audioSrc.loop = false;
                break;
            case "BalanceDrum":
                audioSrc.PlayOneShot(BDrum);
                audioSrc.loop = true;
                break;
            case "BalanceWin":
                audioSrc.PlayOneShot(Bwin);
                audioSrc.loop = false;
                break;
            case "BalanceLose":
                audioSrc.PlayOneShot(Blose);
                audioSrc.loop = false;
                break;
            case "Breaks":
                audioSrc.PlayOneShot(breaks);
                audioSrc.loop = false;
                break;
        }
    }
}
