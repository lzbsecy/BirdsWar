using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState : MonoBehaviour
{
    public bool IsFree;
    public int State;
    public float range;
    public float speed;
    public Vector2 objPosition;
    public int  dir;
    // Start is called before the first frame update
    void Awake()
    {
        IsFree = true;
    }
    void Start()
    {
        State = 0;
        dir = 1;
        objPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(State==1)
        {
      
            switch(dir)
            {
                case 1:
                    transform.Translate(new Vector3(dir, 0, 0) * speed * Time.deltaTime);
                    if (transform.position.x > objPosition.x + range) 
                    {
                        dir = -1;
                    }
                    break;
                case -1:
                    transform.Translate(new Vector3(dir, 0, 0) * speed * Time.deltaTime);
                    if (transform.position.x < objPosition.x - range) 
                    {
                        dir = 1;
                    }
                    break;
                default:
                    break;
            }
        
        }

    }
}
