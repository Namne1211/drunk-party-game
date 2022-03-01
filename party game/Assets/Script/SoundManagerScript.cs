using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip addPlayer,menuClick,takeDrink;
    static AudioSource audioSrc;
    void Start()
    {
        addPlayer = Resources.Load<AudioClip>("Audio/addPlayer");
        menuClick = Resources.Load<AudioClip>("Audio/menuClick");
        takeDrink = Resources.Load<AudioClip>("Audio/take drink");
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
                break;
            case "menuclick":
                audioSrc.PlayOneShot(menuClick);
                break;
            case "drink":
                audioSrc.PlayOneShot(takeDrink);
                break;

        }
    }
}
