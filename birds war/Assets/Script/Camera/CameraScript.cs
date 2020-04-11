using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MoveSpeed;


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
            transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * -1, 0, 0), Space.World);
        }
        if (Input.mousePosition.x > Screen.width - 10)
        {
            transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * 1, 0, 0), Space.World);
        }
        if (Input.mousePosition.y < 10)
        {
            transform.Translate(new Vector3(0, MoveSpeed * 5 * Time.deltaTime * -1, 0), Space.World);
        }
        if (Input.mousePosition.y > Screen.height - 10)
        {
            transform.Translate(new Vector3(0, MoveSpeed * 5 * Time.deltaTime * 1, 0), Space.World);
        }

    }
}
