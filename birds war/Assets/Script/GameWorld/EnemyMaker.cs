using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMaker : MonoBehaviour
{
    public GameObject Hunter;
    public GameObject Timberjack;

    public float preparationTime;
    public float TimberjackMakeCD;
    public GameObject[] grass;
    public List<GameObject> freeGrass;

    public float timberjackNumber;
    public float hunterNumber;
    public float timberjackDeadNumber;

    public GameObject TopTips;

    private float GameTimeCount;
    public float TimeCount;
    private Vector2 NextPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameTimeCount = 0;
        TimeCount = 0;
    }
    
    // Update is called once per frame
    void Update()
    {

        GameTimeCount += Time.deltaTime;
        if (GameTimeCount >= preparationTime)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount >= TimberjackMakeCD)
            {
                Debug.Log("刷新伐木工");
                timberjackMake();
                TimeCount = 0;
            }
            if (timberjackDeadNumber == 5)
            {

                Debug.Log("刷新猎人");
                TopTips.transform.GetChild(0).GetComponent<Text>().text = "猎人来袭！";
                TopTips.SetActive(true);
                hunterMake();
                timberjackDeadNumber = -99;
            }
            
        }  
        
    }

    void timberjackMake()
    {
        Instantiate(Timberjack, freeGrass[Random.Range(0, freeGrass.Count + 1)].transform.position, transform.rotation);
        timberjackNumber++;
    }
    void hunterMake()
    {
        Instantiate(Hunter, freeGrass[Random.Range(0, freeGrass.Count + 1)].transform.position, transform.rotation);
        hunterNumber++;
    }
}
