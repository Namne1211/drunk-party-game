using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwap : MonoBehaviour
{
    public GameObject PlayerIcon;
    public Sprite bgp1;
    public Sprite bgp2;
    public Sprite bgp3;
    public Sprite bgp4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIcon.transform.GetChild(0).gameObject.activeSelf)
        {
            print("gameobject is active");
            gameObject.GetComponent<Image>().sprite=bgp1;
        }
        if (PlayerIcon.transform.GetChild(1).gameObject.activeSelf)
        {
            print("gameobject is active");
            gameObject.GetComponent<Image>().sprite = bgp2;
        }
        if (PlayerIcon.transform.GetChild(2).gameObject.activeSelf)
        {
            print("gameobject is active");
            gameObject.GetComponent<Image>().sprite = bgp3;
        }
        if (PlayerIcon.transform.GetChild(3).gameObject.activeSelf)
        {
            print("gameobject is active");
            gameObject.GetComponent<Image>().sprite = bgp4;
        }
    }
}
