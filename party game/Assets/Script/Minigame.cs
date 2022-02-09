using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame : MonoBehaviour
{
    TextMeshPro tmp;
    public GameObject textContainer;
    public string text;


    public void ChangeContent(string content)
    {
        tmp = textContainer.GetComponent<TextMeshPro>();
        text = content;
        tmp.text = content;
    }



}
