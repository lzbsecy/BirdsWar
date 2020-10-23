using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdsReady : MonoBehaviour
{
    GameObject BirdsHome;
    // Start is called before the first frame update
    void Start()
    {
        BirdsHome = GameObject.FindGameObjectWithTag("BirdsHome");
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        BirdsHome.GetComponent<BirdsMaker>().state = 1;
        outPutName();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void outPutName()
    {
        switch(gameObject.name)
        {
            case "birds1":
                BirdsHome.GetComponent<BirdsMaker>().product = 0;
                break;
            case "birds2":
                BirdsHome.GetComponent<BirdsMaker>().product = 1;
                break;
            case "birds3":
                BirdsHome.GetComponent<BirdsMaker>().product = 2;
                break;
            case "birds4":
                BirdsHome.GetComponent<BirdsMaker>().product = 3;
                break;
        }
    }
}
