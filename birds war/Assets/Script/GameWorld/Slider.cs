using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public float TimeCount;
    public float MaxNumber;
    public float number;
    public Image bar;
    public float FinishTime;
    public bool GameOver=false;
    public GameObject gameoverbox;
    public GameObject TopTips;
    public GameObject[] birds;
    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 0;
        MaxNumber = 840;
        number = 0;
        gameoverbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(TimeCount>=1.5&& TimeCount<=3)
        {
            TopTips.SetActive(true);
        }
       if(TimeCount>6 && TimeCount<7)
        {
            TopTips.transform.GetChild(0).GetComponent<Text>().text = "敌人即将来袭！保护好森林!";
            TopTips.SetActive(true);
        }
        if (number == MaxNumber)
        {
            GameOver = true;
        }
        TimeCount = TimeCount+Time.deltaTime;
        bar.fillAmount = number / MaxNumber;
        if(GameOver)
        {
            Time.timeScale = 0;
            gameoverbox.SetActive(true);
        }
        else if (TimeCount> FinishTime)
        {
            Time.timeScale = 0;
            gameoverbox.SetActive(true);
            gameoverbox.transform.GetChild(0).GetComponent<Text>().text = "游戏胜利！你保卫了森林！";

        }
        
        
    }

}
