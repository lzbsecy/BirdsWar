using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunter : MonoBehaviour
{
    public GameObject birdsHome;
    public GameObject world;
    public int state;
    public float Speed;
    public int Life;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        Life = 30;
        birdsHome = GameObject.FindGameObjectWithTag("BirdsHome");
        world = GameObject.FindGameObjectWithTag("GameWorld");

    }

    // Update is called once per frame
    void Update()
    {
        if(Life<=0)
        {
            state = 4;
        }
        switch(state)
        {
            case 0:
                state = 1;
                break;
            case 1:
                move();
                break;
            case 2:
                Destroy(gameObject);
                break;
            case 3:
                //fight
                //战败，进入状态4
                break;
            case 4:
                //死亡状态
                escape();
                break;
            default:
                break;
        }
        
    }

    void move()
    {
        if (transform.position == birdsHome.transform.position)
        {
            state = 3;
            world.GetComponent<Slider>().GameOver = true;
            world.GetComponent<Slider>().gameoverbox.transform.GetChild(0).GetComponent<Text>().text = "游戏结束！猎人摧毁了家园！";
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, birdsHome.transform.position, Time.deltaTime * Speed);
        }
    }

    void escape()
    {
        Vector3 NextPosition = new Vector2(0, 0);
        float min = 9999;
        for (int i = 0; i < world.GetComponent<EnemyMaker>().freeGrass.Count; i++)
        {
            if (min > Vector3.Distance(world.GetComponent<EnemyMaker>().freeGrass[i].transform.position, transform.position))
            {
                min = Vector3.Distance(world.GetComponent<EnemyMaker>().freeGrass[i].transform.position, transform.position);
                NextPosition = world.GetComponent<EnemyMaker>().freeGrass[i].transform.position;
            }
        }
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        if (gameObject.transform.position == NextPosition)
        {
            world.GetComponent<EnemyMaker>().timberjackDeadNumber = 0;
            world.GetComponent<EnemyMaker>().timberjackDeadNumber += 1;
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, NextPosition, Time.deltaTime * Speed * 5);
        }
    }
}
