using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timberjack : MonoBehaviour
{
    public GameObject world;
    public float Speed;
    public float CutTreeTime;
    public int Life;
    public GameObject Smoke;
    public int state;  //0,1,2,3  //刚出生，前往下一个地点，砍树，战斗
    public GameObject nextTree;
    float TimeCount;

    private Vector2 direction;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 0;
        state = 0;
        Life = 10;
      
        world = GameObject.FindGameObjectWithTag("GameWorld");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            state = 4;
        }

        switch (state)
        {
            case 0:
                //寻找下一个树
                nextTree = NextTree();
                if(nextTree!=null)
                {
                    state = 1;
                }
                else
                {
                    state = 3;
                }
             
                break;
            case 1:
                //前往下一个树
                if(nextTree==null)
                {
                    state = 0;
                }
                else
                {
                    move(nextTree.transform.position);
                    if(transform.position==nextTree.transform.position)
                    {
                        state = 2;
                    }
                }
               
                break;
            case 2:
                //开始砍伐
                //砍伐完毕，destory树，nextTree=null；
                if (nextTree != null)
                {
                    GameObject tree = nextTree;
                    CutDownTree(nextTree);
                }
                else
                {
                    nextTree = null;
                    state = 0;
                }
              
                break;
            case 3:
                //战斗

                //如果战败，进入状态4
                break;
            case 4:
                //死亡状态
                escape();
                break;
            default:
                break;
        }

    }

    GameObject NextTree()
    {
        float min = 9999f;
        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
        
        foreach(GameObject obj in tree)
        {
            if(min>Vector2.Distance(obj.transform.position,transform.position) && obj.GetComponent<TreeState>().IsFree==true)
            {
                min = Vector2.Distance(obj.transform.position, transform.position);
                nextTree = obj;
            }
        }
        if (nextTree == null)
        {
            state = 3;
        }
        else
        {
            nextTree.GetComponent<TreeState>().IsFree = false;
        }

        return nextTree;
    }

    void move(Vector3 position)
    {
        if (transform.position != position)
        {
            direction = position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        transform.position = Vector2.MoveTowards(transform.position, position, Time.deltaTime * Speed);
    }

    void CutDownTree(GameObject nextTree)
    {
        nextTree.GetComponent<TreeState>().State = 1;
        TimeCount += Time.deltaTime;
        if(TimeCount>= CutTreeTime)
        {
            nextTree.GetComponent<TreeState>().State = 0;
            DestroyImmediate(nextTree);
            world.GetComponent<slider>().number++;
            TimeCount = 0;
            nextTree = null;
            state = 0;
        }
    }

    void escape()
    {
        
        Vector3 NextPosition=new Vector2(0,0);
        float min=9999;
        for(int i =0;i< world.GetComponent<EnemyMaker>().freeGrass.Count; i++)
        {
            if(min>Vector3.Distance(world.GetComponent<EnemyMaker>().freeGrass[i].transform.position,transform.position))
            {
                min = Vector3.Distance(world.GetComponent<EnemyMaker>().freeGrass[i].transform.position, transform.position);
                NextPosition = world.GetComponent<EnemyMaker>().freeGrass[i].transform.position;
            }
        }
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        if(gameObject.transform.position==NextPosition)
        {
            world.GetComponent<EnemyMaker>().timberjackDeadNumber += 1;
            world.GetComponent<EnemyMaker>().timberjackNumber -= 1;
            Destroy(gameObject);
        }
        else
        {
            if (transform.position != NextPosition)
            {
                direction = NextPosition - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
            transform.position = Vector2.MoveTowards(transform.position, NextPosition, Time.deltaTime * Speed*5);
        } 
    }
}
