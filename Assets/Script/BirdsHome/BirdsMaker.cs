﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsMaker : MonoBehaviour
{
    public GameObject world;
    public bool Selection;
    public GameObject bg;
    public GameObject birds1;
    public GameObject birds2;
    public GameObject birds3;
    public GameObject birds4;

    public int state = 0; //0:free,1:busy,2:finished
    public int product; //正在生产（0，1，2，3）

    public float timeMax; //生产最长周期s;

    private float timeCount = 0;
    private float timeCount1 = 0;
    

    void Start()
    {
        world = GameObject.FindGameObjectWithTag("GameWorld");
    }

    void Update()
    {
        Selection = gameObject.GetComponent<IsSelection>().Selection;
        if (gameObject.GetComponent<IsSelection>().Selection==false && state==0)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                gameObject.GetComponent<IsSelection>().Selection = true;
            }
        }
        if(state==2)
        {
            timeCount1 += Time.deltaTime;
            if(timeCount1>=1.5)
            {
                state = 0;
                timeCount1 = 0;
            } 
        }
        if (state == 3)
        {
            if (world.GetComponent<Mouse>().birds.Count < 10)
            {
                state = 0;
            }
        }
        OnClick();  //点击效果
        Making(product);    //生产鸟类
    }

    void OnClick()
    {
        if (Selection && state==0)
        {
            if(world.GetComponent<Mouse>().birds.Count>=10)
            {
                state = 3;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Outline", 15);
                bg.SetActive(true);
            }
                  
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Outline", 0);
            bg.SetActive(false);   
        }

    }
    void Making(int product)
    {
        if (state == 1)
        {
            timeCount = timeCount + (float)Time.deltaTime;
            switch (product)
            {
                case 0:
                    if (timeCount >= timeMax / 2)
                    {
                        Instantiate(birds1, transform.position + new Vector3(1, 1, 0), transform.rotation);
                        Instantiate(birds1, transform.position + new Vector3(-1, -1, 0), transform.rotation);
                        Instantiate(birds1, transform.position + new Vector3(-1, 1, 0), transform.rotation);
                        state = 2;
                        timeCount = 0;
                    }
                    break;
                case 1:
                    if (timeCount >= timeMax / 2)
                    {
                        Instantiate(birds2, transform.position + new Vector3(1, 1, 0), transform.rotation);
                        Instantiate(birds2, transform.position + new Vector3(-1, -1, 0), transform.rotation);
                       
                        state = 2;
                        timeCount = 0;
                    }
                    break;
                case 2:
                    if (timeCount >= timeMax / 3)
                    {
                        Instantiate(birds3, transform.position + new Vector3(1, 1, 0), transform.rotation);
                        Instantiate(birds3, transform.position + new Vector3(-1, -1, 0), transform.rotation);
                        Instantiate(birds3, transform.position + new Vector3(1, 1, 0), transform.rotation);
                        Instantiate(birds3, transform.position + new Vector3(-1, -1, 0), transform.rotation);
                        Instantiate(birds3, transform.position + new Vector3(0, 0, 0), transform.rotation);

                        state = 2;
                        timeCount = 0;
                    }
                    break;
                case 3:
                    if (timeCount >= timeMax)
                    {
                        Instantiate(birds4, transform.position + new Vector3(0, 0, 0), transform.rotation);

                        state = 2;
                        timeCount = 0;
                    }
                    break;
            }
        } 
        
    }
}