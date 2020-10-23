using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopTips : MonoBehaviour
{
    public float TimeCount;

    // Start is called before the first frame update

    void Start()
    {

        TimeCount = 0;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(gameObject.activeInHierarchy==true)
        {
            TimeCount = TimeCount + Time.deltaTime;
            if (TimeCount > 2)
            {
                TimeCount = 0;
                gameObject.SetActive(false);
            }
        }
        

     
       
       
        
    }

}
