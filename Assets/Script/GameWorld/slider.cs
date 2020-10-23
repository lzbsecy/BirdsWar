using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public float TimeCount;
    public float MaxNumber;
    public float number;
    public Slider s;

    public float FinishTime;
    public bool GameOver=false;
    public GameObject gameoverbox;
    public GameObject TopTips;
    public GameObject[] birds;


    public AudioClip[] BGM;
    public int bgmNum = 0;
    
    public AudioSource ac;

    // Start is called before the first frame update
    void Start()
    {
  
        ac = gameObject.GetComponent<AudioSource>();
        ac.clip = BGM[bgmNum];
        ac.Play();
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
            bgmNum = 2;
            ac.clip = BGM[bgmNum];
            ac.Play();
            TopTips.SetActive(true);
        }
        if(TimeCount >= FinishTime *3/25 && gameObject.GetComponent<EnemyMaker>().attackLever == 0)//60s
        {
            gameObject.GetComponent<EnemyMaker>().attackLever = 1;
        }
        if (TimeCount >= FinishTime / 5 && gameObject.GetComponent<EnemyMaker>().attackLever == 1) //100s
        {
            gameObject.GetComponent<EnemyMaker>().attackLever = 2;
        }
        if(TimeCount >= FinishTime * 2 / 5 && gameObject.GetComponent<EnemyMaker>().attackLever == 2) //200s
        {
            gameObject.GetComponent<EnemyMaker>().attackLever = 3;
        }
        if (TimeCount >= FinishTime * 3 / 5 && gameObject.GetComponent<EnemyMaker>().attackLever == 3) //300s
        {
            gameObject.GetComponent<EnemyMaker>().attackLever = 4;
        }
        if (TimeCount >= FinishTime * 4 / 5 && gameObject.GetComponent<EnemyMaker>().attackLever == 4) //400s
        {
            gameObject.GetComponent<EnemyMaker>().attackLever = 5;
            TopTips.transform.GetChild(0).GetComponent<Text>().text = "游戏即将胜利！坚持住！";
            TopTips.SetActive(true);
        }

        if (number == MaxNumber)
        {
            GameOver = true;
        }
        TimeCount = TimeCount+Time.deltaTime;
        s.value = number / MaxNumber;



        if (GameOver)
        {
            Time.timeScale = 0;
            gameoverbox.SetActive(true);
            GameOver = false;
        }
        else if (TimeCount> FinishTime)
        {
            Time.timeScale = 0;
            gameoverbox.SetActive(true);
            gameoverbox.transform.GetChild(0).GetComponent<Text>().text = "游戏胜利！你保卫了森林！";
            bgmNum = 4;
            gameoverbox.GetComponent<AudioSource>().clip = gameObject.GetComponent<slider>().BGM[bgmNum];
            gameoverbox.GetComponent<AudioSource>().loop = true;
            if(!gameoverbox.GetComponent<AudioSource>().isPlaying)
            {
                gameoverbox.GetComponent<AudioSource>().Play();
            }
        }
        
        
    }

}
