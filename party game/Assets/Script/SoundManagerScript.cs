using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip addPlayer,menuClick,takeDrink,pop,shake,countDown;
    static AudioSource audioSrc;
    void Start()
    {
        addPlayer = Resources.Load<AudioClip>("Audio/addPlayer");
        menuClick = Resources.Load<AudioClip>("Audio/menuClick");
        takeDrink = Resources.Load<AudioClip>("Audio/take drink");
        pop = Resources.Load<AudioClip>("Audio/Pop");
        shake = Resources.Load<AudioClip>("Audio/Shake");
        countDown = Resources.Load<AudioClip>("Audio/countDown");
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
        }
    }
}
