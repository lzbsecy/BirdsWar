using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MoveSpeed;
    public float MaxMoveDistance;
    public GameObject zero;


    void Start()
    {

    }


    void Update()
    {
        
        MouseDistanceTirgger();
    }

    void MouseDistanceTirgger()
    {
        if (Input.mousePosition.x < 10)
        {
            if(transform.position.x > -16)
            {
                transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * -1, 0, 0), Space.World);
            }
        }
        if (Input.mousePosition.x > Screen.width - 10)
        {
            if (transform.position.x < 16)
            {
                transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * 1, 0, 0), Space.World);
            }
        }
        if (Input.mousePosition.y < 10)
        {
            if(transform.position.y > -141)
            {
                transform.Translate(new Vector3(0, MoveSpeed * 5 * Time.deltaTime * -1, 0), Space.World);
            }

        }
        if (Input.mousePosition.y > Screen.height - 10)
        {
            if (transform.position.y < -59)
            {
                transform.Translate(new Vector3(0, MoveSpeed * 5 * Time.deltaTime * 1, 0), Space.World);
            }
        }

    }
}
