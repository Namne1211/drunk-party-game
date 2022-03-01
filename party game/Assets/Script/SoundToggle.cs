using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    GameObject []sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    public void MuteToggle(bool muted)
    {
        if(muted)
        {
            for (int i = 0; i < sound.Length; i++)
            {
                sound[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < sound.Length; i++)
            {
                sound[i].SetActive(false);
            }
        }

    }
    
    
    
}
