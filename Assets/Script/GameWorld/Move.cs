using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed1;
    public float speed2;
    public bool upDown;
    public float dir1;
    public float dir2;
    public float MaxDistinceH;
    public float MaxDistinceV;
    public bool picdir;
    public float TimeCount;
    public float sleepTime;
    public GameObject birds;
    public GameObject child;
    public GameObject[] text;

    private float distince1;
    private float distince2;
    private int TimberjackState;
    private int HunterState;
    private float timecount;
    private int index;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        birds = GameObject.FindGameObjectWithTag("Birds");
        distince1 = 0;
        distince2 = 0;
        TimeCount = 0;
        TimberjackState = 0;
        HunterState = 0;
        timecount = 0;
        index = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        move();
    }

    void move()
    {
        if(upDown)
        {
            move1();
            move2();
        }
        else
        {
            move1();
        }

    }
    void move1()
    {
        
        

        if (gameObject.tag=="Timberjack")
        {
            transform.Translate(new Vector3(dir1 * speed1 * Time.deltaTime, 0, 0), Space.World);
            if (transform.position.x >= birds.transform.position.x - 2.5 && TimberjackState == 0 && birds.GetComponent<Move>().dir1 == -1)
            {
                dir1 = dir1 * -1;
                TimberjackState = 1;
                speed1 += 1;
                child.SetActive(true);
            }
            if(TimberjackState==1)
            {
                distince1 += speed1 * Time.deltaTime;
                if(distince1 > MaxDistinceH+Random.Range(0,2))
                {
                    dir1= dir1 * -1;
                    TimberjackState = 0;
                    distince1 = 0;
                    speed1 -= 1;
                    child.SetActive(false);
                }

            }
        }
        else if(gameObject.tag=="Hunter")
        { 
            if (HunterState == 0)
            {
                timecount += Time.deltaTime;
                distince1 += speed1 * Time.deltaTime;
                transform.Translate(new Vector3(dir1 * speed1 * Time.deltaTime, 0, 0), Space.World);
            }
            else
            {
                if(dir1==1)
                {
                    if(count <3)
                    {
                        text[count].SetActive(true);
                    }
                    else
                    {
                        text[index].SetActive(true);
                    }
                }
                sleepTime += Time.deltaTime;
                if (sleepTime > 2 + Random.Range(0, 3)) 
                {
                    if (count < 3)
                    {
                        text[count].SetActive(false);
                    }
                    else
                    {
                        text[index].SetActive(false);
                    }

                    HunterState = 0;
                    sleepTime = 0;
                }
            }
            if (distince1 > MaxDistinceH)
            {
                dir1 = dir1 * -1;
                distince1 = 0;
            }
            if(timecount> 5+Random.Range(0,3))
            {
                index = Random.Range(0, 3);
                count++;
                HunterState = 1;
                timecount = 0;
            }
            

        }
        else if(gameObject.tag=="Birds")
        {
            distince1 += speed1 * Time.deltaTime;
            transform.Translate(new Vector3(dir1 * speed1 * Time.deltaTime, 0, 0), Space.World);
            if (distince1 > MaxDistinceH)
            {
                dir1 = dir1 * -1;
                distince1 = 0;
            }
        }
        else if(gameObject.tag=="cloud")
        {
            transform.Translate(new Vector3(dir1 * speed1 * Time.deltaTime, 0, 0), Space.World);
            if(transform.position.x<=-19)
            {
                if(transform.position.y<-48)
                {
                    gameObject.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x + 38, gameObject.transform.position.y + Random.Range(0f, 2f), gameObject.transform.position.z);
                }
                else if(transform.position.y>-45.5)
                {
                    gameObject.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x + 38, gameObject.transform.position.y + Random.Range(-2f, 0f), gameObject.transform.position.z);
                }
                else
                {
                    gameObject.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x + 38, gameObject.transform.position.y + Random.Range(-1.5f, 1.5f), gameObject.transform.position.z);
                }
            }
        }

        if(picdir)
        {
            if (dir1 == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (dir1 == -1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            if (dir1 == 1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (dir1 == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
    }
    void move2()
    {
        transform.Translate(new Vector3(0, dir2 * speed2 * Time.deltaTime, 0), Space.World);
        distince2 += speed2 * Time.deltaTime;
        if (distince2 > MaxDistinceV)
        {
            dir2 = dir2 * -1;
            distince2 = 0;
        }
    }

}
