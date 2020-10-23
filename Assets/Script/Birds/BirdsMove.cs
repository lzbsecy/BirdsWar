using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsMove : MonoBehaviour
{
    
    public Vector3 NextPosition;
    public float Speed;
    public float MaxDistance;
    public GameObject Battlefield;

    private Vector2 direction;
    private float angle;
   

    // Start is called before the first frame update
    void Start()
    {
        NextPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Speed = gameObject.GetComponent<Birds>().speed;
        Move();
    }

    void Move()
    {      
        if(transform.position!= NextPosition)
        {
            direction = NextPosition - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        }
        transform.position = Vector2.MoveTowards(transform.position, NextPosition, Time.deltaTime * Speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.collider.tag)
        {
            case "Birds1":
                if (Vector2.Distance(transform.position, NextPosition) < MaxDistance)
                {
                    NextPosition = transform.position;
                }
                if (collision.collider.transform.position == collision.collider.GetComponent<BirdsMove>().NextPosition)
                {
                    NextPosition = transform.position;
                }   
                break;
            case "Birds2":
                if (Vector2.Distance(transform.position, NextPosition) < MaxDistance)
                {
                    NextPosition = transform.position;
                }
                if (collision.collider.transform.position == collision.collider.GetComponent<BirdsMove>().NextPosition)
                {
                    NextPosition = transform.position;
                }
                break;
            case "Birds3":
                if (Vector2.Distance(transform.position, NextPosition) < MaxDistance)
                {
                    NextPosition = transform.position;
                }

                if (collision.collider.transform.position == collision.collider.GetComponent<BirdsMove>().NextPosition)
                {
                    NextPosition = transform.position;
                }
                break;
            case "Birds4":
                if (Vector2.Distance(transform.position, NextPosition) < MaxDistance)
                {
                    NextPosition = transform.position;
                }

                if (collision.collider.transform.position == collision.collider.GetComponent<BirdsMove>().NextPosition)
                {
                    NextPosition = transform.position;
                }
                break;
            case "Timberjack":
                if(collision.collider.GetComponent<Timberjack>().state==2)
                {
                    collision.collider.GetComponent<Timberjack>().nextTree.GetComponent<TreeState>().State = 0;
                }
                GameObject field = Instantiate(Battlefield, collision.collider.transform.position, collision.collider.transform.rotation);
                field.GetComponent<Battlefield>().Birds.Add(gameObject);
                field.GetComponent<Battlefield>().Timberjack = collision.collider.gameObject;
                collision.collider.GetComponent<Timberjack>().state = 3;
                gameObject.transform.position = collision.collider.transform.position;
                if(collision.collider.GetComponent<Timberjack>().nextTree != null)
                {
                    collision.collider.GetComponent<Timberjack>().nextTree.GetComponent<TreeState>().IsFree=true;
                    collision.collider.GetComponent<Timberjack>().nextTree = null;
                }
                gameObject.SetActive(false);
                collision.collider.gameObject.SetActive(false);
                break;
            case "Hunter":
                GameObject field1 = Instantiate(Battlefield, collision.collider.transform.position, collision.collider.transform.rotation);
                field1.GetComponent<Battlefield>().Birds.Add(gameObject);
                field1.GetComponent<Battlefield>().Hunter = collision.collider.gameObject;

                collision.collider.GetComponent<Hunter>().state = 3;
                gameObject.transform.position = collision.collider.transform.position;
                gameObject.SetActive(false);
                collision.collider.gameObject.SetActive(false);

                break;
            case "Battlefield":
                collision.collider.GetComponent<Battlefield>().Birds.Add(gameObject);

                gameObject.SetActive(false);
                gameObject.transform.position = collision.collider.transform.position;
                break;
            default:
                break;
        }
    }

}
