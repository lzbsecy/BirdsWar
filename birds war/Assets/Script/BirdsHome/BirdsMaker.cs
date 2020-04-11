using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsMaker : MonoBehaviour
{
    public bool Selection = false;
    public GameObject bg;
   
    public int clickCount=0;
    public int state = 0; //0:free,1:busy,2:finished
    public int product; //正在生产（0，1，2，3）

    public float timeMax; //生产最长周期s;

    private float timeCount = 0;
    private float timeCount1 = 0;
    void Start()
    {
        
        timeMax = 4;
    }

    void Update()
    {

        OnClick();

        Making(product);

        if(state==2)
        {
            timeCount1 += Time.deltaTime;
            if(timeCount1>=1.5)
            {
                state = 0;
                timeCount1 = 0;
                
            } 
        }
    }

    void OnClick()
    {
        if (Selection && state==0)
        {
            
            if (clickCount < 1)
            {
                clickCount++;
                bg.SetActive(true);
            }
        }
        else
        {           
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
                        Debug.Log("bird ready!"+"("+timeCount+")");
                        state = 2;
                        timeCount = 0;
                       
                    }
                    break;
                case 1:
                    if (timeCount >= timeMax / 2)
                    {
                        Debug.Log("bird ready!" + "(" + timeCount + ")");
                        state = 2;
                        timeCount = 0;
                    }
                    break;
                case 2:
                    if (timeCount >= timeMax / 3)
                    {
                        Debug.Log("bird ready!" + "(" + timeCount + ")");
                        state = 2;
                        timeCount = 0;
                    }
                    break;
                case 3:
                    if (timeCount >= timeMax)
                    {
                        Debug.Log("bird ready!" + "(" + timeCount + ")");
                        state = 2;
                        timeCount = 0;
                    }
                    break;
            }
        } 
        
    }
}
