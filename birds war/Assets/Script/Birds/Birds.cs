using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public bool Selection;
    public int Life;
    public int ACK;
    public GameObject world;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        world=GameObject.FindGameObjectWithTag("GameWorld");

        switch (gameObject.tag)
        {
            case "Birds1":
                Life = 2;
                ACK = 2;
                break;
            case "Birds2":
                Life = 4;
                ACK = 2;
                break;
            case "Birds3":
                Life = 1;
                ACK = 1;
                break;
            case "Birds4":
                Life = 10;
                ACK = 10;
                break;
            default:
                break;
        }
        Selection = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(Life<=0)
        {
            Selection = false;
            escape(); 
        }
        else
        {
            Selection = gameObject.GetComponent<IsSelection>().Selection;
        }

        if (Selection == false && Life > 0 && gameObject.tag == "Birds1") 
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                gameObject.GetComponent<IsSelection>().Selection = true;
            }
        }
        if (Selection == false && Life > 0 && gameObject.tag == "Birds2")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                gameObject.GetComponent<IsSelection>().Selection = true;
            }
        }
        if (Selection == false && Life > 0 && gameObject.tag == "Birds3")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<IsSelection>().Selection = true;
            }
        }
        if (Selection == false && Life > 0 && gameObject.tag == "Birds4")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.GetComponent<IsSelection>().Selection = true;
            }
        }


        Light();
    }

    void Light()
    {
        if (Selection)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Outline", 30);
            
        }
        else
        {
            if(gameObject.GetComponent<BirdsMove>().NextPosition==transform.position)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Outline", 0);
       

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
        Destroy(gameObject.GetComponent<BirdsMove>());

        if (gameObject.transform.position == NextPosition)
        {
            world.GetComponent<EnemyMaker>().timberjackDeadNumber += 1;
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, NextPosition, Time.deltaTime * speed * 5);
        }
    }
}
