using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsTip : MonoBehaviour
{
    public float ShowCD;


    public GameObject BirdsHome;
    public GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        BirdsHome = GameObject.FindGameObjectWithTag("BirdsHome");
    }

    // Update is called once per frame
    void Update()
    {
        if(BirdsHome.GetComponent<BirdsMaker>().Selection==true && BirdsHome.GetComponent<BirdsMaker>().state==0 && bg.activeInHierarchy)
        {
            gameObject.GetComponent<Text>().text = "选择要进行繁殖的鸟类";
        }
        else if(BirdsHome.GetComponent<BirdsMaker>().state == 1)
        {
            gameObject.GetComponent<Text>().text = "繁殖中";
        }
        else if(BirdsHome.GetComponent<BirdsMaker>().state == 2)
        {
            gameObject.GetComponent<Text>().text = "繁殖完毕";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "";
        }
    }

}
