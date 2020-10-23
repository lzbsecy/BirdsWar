using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{

    public GameObject BirdsHome;
    public GameObject Tree;
    public GameObject Grass;
    public float ForestRadius;

    private Vector2 zeroPosition;
    public GameObject[] grass;
  
    // Start is called before the first frame update
    void Start()
    {
       
        BirdsHome = GameObject.FindGameObjectWithTag("BirdsHome");
        zeroPosition = BirdsHome.transform.position;
        GrassCreat();
        ForestCreat();
        freeGrass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrassCreat()
    {
        Vector2 NextPosition1;
        Vector2 NextPosition2;
        Vector2 NextPosition3;
        Vector2 NextPosition4;

        float  i = 0, j = 0;
    
        while (i < ForestRadius) 
        {
            NextPosition1.x = 0;
            NextPosition1.y = -100;
            NextPosition2.x = 0;
            NextPosition2.y = -100;
            NextPosition3.x = 0;
            NextPosition3.y = -100;
            NextPosition4.x = 0;
            NextPosition4.y = -100;

            NextPosition1.y = -100 + (i + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.y;
            NextPosition2.y = -100 + (i + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.y;
            NextPosition3.y = -100 - (i + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.y;
            NextPosition4.y = -100 - (i + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.y;

            while (j < ForestRadius ) 
            {
                NextPosition1.x = (j + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.x;
                NextPosition2.x = (j + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.x * (-1f);
                NextPosition3.x = (j + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.x;
                NextPosition4.x = (j + 1) * Grass.GetComponent<SpriteRenderer>().bounds.size.x * (-1f);

                Instantiate(Grass, NextPosition1, transform.rotation);
                Instantiate(Grass, NextPosition2, transform.rotation);
                Instantiate(Grass, NextPosition3, transform.rotation);
                Instantiate(Grass, NextPosition4, transform.rotation);

                
                j = j + 1f;
            }
            j = 0;
            i = i + 1f;
        }
        i = 1;
        j = 1;
        NextPosition1.x = 0;
        NextPosition1.y = -100;
        NextPosition2.x = 0;
        NextPosition2.y = -100;
        NextPosition3.x = 0;
        NextPosition3.y = -100;
        NextPosition4.x = 0;
        NextPosition4.y = -100;
        while (i<ForestRadius+1)
        {
            NextPosition1.x = i * Grass.GetComponent<SpriteRenderer>().bounds.size.x;
            Instantiate(Grass, NextPosition1, transform.rotation);
            NextPosition2.x = i * Grass.GetComponent<SpriteRenderer>().bounds.size.x * (-1f);
            Instantiate(Grass, NextPosition2, transform.rotation);
            NextPosition3.y = -100 + i * Grass.GetComponent<SpriteRenderer>().bounds.size.y;
            Instantiate(Grass, NextPosition3, transform.rotation);
            NextPosition4.y = -100 - i * Grass.GetComponent<SpriteRenderer>().bounds.size.y;
            Instantiate(Grass, NextPosition4, transform.rotation);
            i = i + 1f;
        }

    }

    void ForestCreat()
    {
        grass = GameObject.FindGameObjectsWithTag("Grass");      
        foreach(GameObject obj in grass )
        {
            GameObject tree = Instantiate(Tree, obj.transform.position, obj.transform.rotation) as GameObject;
            tree.transform.parent = obj.transform;
        }      
        GameObject[] tree1 = GameObject.FindGameObjectsWithTag("Tree");
        foreach(GameObject obj in tree1)
        {
            if (obj.transform.parent.position.x == ForestRadius * Grass.GetComponent<SpriteRenderer>().bounds.size.x
                || obj.transform.parent.position.x == -ForestRadius * Grass.GetComponent<SpriteRenderer>().bounds.size.x
                || obj.transform.parent.position.y == -100f + ForestRadius * Grass.GetComponent<SpriteRenderer>().bounds.size.y
                || obj.transform.parent.position.y + 162.4 <= 0.1
                
                )
            {
            
                DestroyImmediate(obj);
            }
        }
        
        
        
        
    }
    void freeGrass()
    {
        grass = GameObject.FindGameObjectsWithTag("Grass");
        gameObject.GetComponent<EnemyMaker>().grass = grass;
        int i = 0;
       
  
        for (i = 0; i < grass.Length; i++)
        {
            if(grass[i].transform.childCount==0)
            {
                gameObject.GetComponent<EnemyMaker>().freeGrass.Add(grass[i]);
            }
        }
    }

}
