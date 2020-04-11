using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject birdsHome;
    public GameObject bottomImage;

    void Start()
    {
      
    }


    void Update()
    {
        
        OnClick();
        //Debug.Log("x:" + Input.mousePosition.x + " y:" + Input.mousePosition.y+"  "+bottomImage.GetComponent<Collider2D>().bounds.size.x + "  " + bottomImage.GetComponent<Collider2D>().bounds.size.y);
       
    }

    void OnClick()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > bottomImage.GetComponent<Collider2D>().bounds.size.x || Input.mousePosition.y > bottomImage.GetComponent<Collider2D>().bounds.size.y)
            {
                RaycastHit2D hitWorld = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                //RaycastHit2D hitScreen = Physics2D.Raycast(Camera.main.WorldToScreenPoint(Input.mousePosition), Vector2.zero);

                if (hitWorld.collider!=null)
                {
                    if(hitWorld.collider.tag== "BirdsHome")
                    {
                        birdsHome.GetComponent<BirdsMaker>().Selection = true;
                        if(birdsHome.GetComponent<BirdsMaker>().state==0)
                        {
                           
                        }
                        else
                        {
                           
                        }

                    }
                    else
                    {
                       
                        birdsHome.GetComponent<BirdsMaker>().Selection = false;
                        birdsHome.GetComponent<BirdsMaker>().clickCount = 0;
                    }
                    
                }
                else
                {
                    birdsHome.GetComponent<BirdsMaker>().Selection = false;
                    birdsHome.GetComponent<BirdsMaker>().clickCount = 0;
                }

            }
           

        }
    }
}
