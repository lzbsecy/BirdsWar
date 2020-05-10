using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouse : MonoBehaviour
{
    public GameObject birdsHome;
    public GameObject bottomImage;
    public GameObject[] birds;

    public GameObject record;
    private Vector2 ClickPosition;



    private GameObject[] birds1;
    private GameObject[] birds2;
    private GameObject[] birds3;
    private GameObject[] birds4;

    private Vector2 StartPosition;
    private Vector2 EndPosition;
    private Vector2 MousePositionWorld;


    private Material drawMaterial;

    public bool IsStartDraw;
    void Start()
    {

        record = GameObject.FindGameObjectWithTag("BirdsHome");
        

        drawMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        this.drawMaterial.hideFlags = HideFlags.HideAndDontSave;
        this.drawMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    void Update()
    {
        birds = GameObject.FindGameObjectsWithTag("Birds2");
        //getsBirds();
        MousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        OnClick();
        MultipleSelection();
        //Debug.Log(Camera.main.ScreenToWorldPoint(MousePositionWorld));
    }
    void getsBirds()
    {
        int i = 0;
        birds1 = GameObject.FindGameObjectsWithTag("Birds1");
        birds2 = GameObject.FindGameObjectsWithTag("Birds2");
        birds3 = GameObject.FindGameObjectsWithTag("Birds3");
        birds4 = GameObject.FindGameObjectsWithTag("Birds4");
        
    }

    //单选
    void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {

            if (Input.mousePosition.x > bottomImage.GetComponent<Collider2D>().bounds.size.x || Input.mousePosition.y > bottomImage.GetComponent<Collider2D>().bounds.size.y)
            {
                //Debug.Log("click:" + ClickPosition);
                if(record!=null)
                {
                    record.GetComponent<IsSelection>().Selection = false;

                }
                RaycastHit2D hitWorld = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hitWorld.collider != null)
                {
                    record = hitWorld.collider.gameObject;
                    switch (record.tag)
                    {
                        case "BirdsHome":
                            record.GetComponent<IsSelection>().Selection = true;
                            break;
                        case "Birds1":
                            record.GetComponent<IsSelection>().Selection = true;
                            break;
                        case "Birds2":
                            record.GetComponent<IsSelection>().Selection = true;
                            break;
                        case "Birds3":
                            record.GetComponent<IsSelection>().Selection = true;
                            break;
                        case "Birds4":
                            record.GetComponent<IsSelection>().Selection = true;
                            break;
                        default:

                            break;

                    }
                }
                else
                {
                    birdsHome.GetComponent<IsSelection>().Selection = false;

                    for (int i = 0; i < birds.Length; i++)
                    {
                        birds[i].GetComponent<IsSelection>().Selection = false;
                    }
                }

            }


        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < birds.Length; i++)
            {
                if (birds[i].GetComponent<IsSelection>().Selection)
                {
                    birds[i].GetComponent<BirdsMove>().NextPosition = ClickPosition;
                }
            }


        }
    }

    //框选
    void MultipleSelection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            IsStartDraw = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            IsStartDraw = false;
            EndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Select(StartPosition, EndPosition);
        }



    }

    void Select(Vector2 startPosition, Vector2 endPosition)
    {

        foreach(GameObject bird in birds)
        {
           if(startPosition.x < endPosition.x && startPosition.y < endPosition.y)
            {
                if(bird.transform.position.x>startPosition.x && bird.transform.position.y> startPosition.y 
                    && bird.transform.position.x<endPosition.x&& bird.transform.position.y < endPosition.y)
                {
                    bird.GetComponent<IsSelection>().Selection = true;
                }
                
            }
           if(startPosition.x < endPosition.x && startPosition.y > endPosition.y)
            {
                if (bird.transform.position.x > startPosition.x && bird.transform.position.y < startPosition.y
                     && bird.transform.position.x < endPosition.x && bird.transform.position.y > endPosition.y)
                {
                    bird.GetComponent<IsSelection>().Selection = true;
                }
            }
            if (startPosition.x > endPosition.x && startPosition.y > endPosition.y)
            {
                if (bird.transform.position.x < startPosition.x && bird.transform.position.y < startPosition.y
                     && bird.transform.position.x > endPosition.x && bird.transform.position.y > endPosition.y)
                {
                    bird.GetComponent<IsSelection>().Selection = true;
                }
            }
            if (startPosition.x > endPosition.x && startPosition.y < endPosition.y)
            {
                if (bird.transform.position.x < startPosition.x && bird.transform.position.y > startPosition.y
                     && bird.transform.position.x > endPosition.x && bird.transform.position.y < endPosition.y)
                {
                    bird.GetComponent<IsSelection>().Selection = true;
                }
            }


        }

    }

    private void OnGUI()
    {
        if (IsStartDraw)
        {

            drawMaterial.SetPass(0);
            GL.LoadOrtho();
            GL.LoadPixelMatrix();

            DrawRectLine();
        }
    }

    private void DrawRectLine()
    {
        GL.Begin(GL.LINES);
        
        GL.Color(Color.cyan);
        GL.Vertex3(Camera.main.WorldToScreenPoint(StartPosition).x, Camera.main.WorldToScreenPoint(StartPosition).y, 0);
        GL.Vertex3(Input.mousePosition.x, Camera.main.WorldToScreenPoint(StartPosition).y, 0);
        GL.Vertex3(Input.mousePosition.x, Camera.main.WorldToScreenPoint(StartPosition).y, 0);
        GL.Vertex3(Input.mousePosition.x, Input.mousePosition.y, 0);
        GL.Vertex3(Input.mousePosition.x, Input.mousePosition.y, 0);
        GL.Vertex3(Camera.main.WorldToScreenPoint(StartPosition).x, Input.mousePosition.y, 0);
        GL.Vertex3(Camera.main.WorldToScreenPoint(StartPosition).x, Input.mousePosition.y, 0);
        GL.Vertex3(Camera.main.WorldToScreenPoint(StartPosition).x, Camera.main.WorldToScreenPoint(StartPosition).y, 0);
        GL.End();
    }
}


