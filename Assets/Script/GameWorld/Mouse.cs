using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouse : MonoBehaviour
{
    public GameObject birdsHome;
    public GameObject bottomImage;
    public List<GameObject> birds;

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

        getsBirds();
        MousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        OnClick();
        MultipleSelection();
    }
    private int temp = 0;
    public void getsBirds()
    {
        birds1 = GameObject.FindGameObjectsWithTag("Birds1");
        birds2 = GameObject.FindGameObjectsWithTag("Birds2");
        birds3 = GameObject.FindGameObjectsWithTag("Birds3");
        birds4 = GameObject.FindGameObjectsWithTag("Birds4");
        foreach(GameObject obj in birds1)
        {
            temp = 0;
            foreach (GameObject obj1 in birds)
            {
                if(obj==obj1)
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                birds.Add(obj);
            }
        }
        foreach (GameObject obj in birds2)
        {
            temp = 0;
            foreach (GameObject obj1 in birds)
            {
                if (obj == obj1)
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                birds.Add(obj);
            }
        }
        foreach (GameObject obj in birds3)
        {
            temp = 0;
            foreach (GameObject obj1 in birds)
            {
                if (obj == obj1)
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                birds.Add(obj);
            }
        }
        foreach (GameObject obj in birds4)
        {
            temp = 0;
            foreach (GameObject obj1 in birds)
            {
                if (obj == obj1)
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                birds.Add(obj);
            }
        }
        foreach (GameObject obj in birds)
        {
            if(obj==null)
            {
                birds.Remove(obj);
            }
        }
    }

    //单选
    void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition.x > bottomImage.GetComponent<Collider2D>().bounds.size.x || Input.mousePosition.y > bottomImage.GetComponent<Collider2D>().bounds.size.y)
            {
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

                    for (int i = 0; i < birds.Count; i++)
                    {
                        if(birds[i]!=null)
                        {
                            birds[i].GetComponent<IsSelection>().Selection = false;

                        }
                    }
                }

            }


        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(birds[0]!=null)
            {
                birds[0].GetComponent<AudioSource>().clip = birds[0].GetComponent<Birds>().clips[Random.Range(0, 3)];
                if (!birds[0].GetComponent<AudioSource>().isPlaying)
                {
                    birds[0].GetComponent<AudioSource>().Play();
                }
            }
            for (int i = 0; i < birds.Count; i++)
            {
                if (birds[i] != null)
                {
                    if (birds[i].GetComponent<IsSelection>().Selection)
                    {
                        birds[i].GetComponent<BirdsMove>().NextPosition = ClickPosition;                      
                    }
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
            IsStartDraw = true;//开始绘制

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
            if(bird!=null)
            {
                if (startPosition.x < endPosition.x && startPosition.y < endPosition.y)
                {
                    if (bird.transform.position.x > startPosition.x && bird.transform.position.y > startPosition.y
                        && bird.transform.position.x < endPosition.x && bird.transform.position.y < endPosition.y)
                    {
                        bird.GetComponent<IsSelection>().Selection = true;
                    }

                }
                if (startPosition.x < endPosition.x && startPosition.y > endPosition.y)
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


