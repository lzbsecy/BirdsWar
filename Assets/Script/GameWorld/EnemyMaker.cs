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
    public float timberjacklimit;
    public float hunterNumber;
    public float hunterlimit;
    public float timberjackDeadNumber;
    public float hunterDeadNumber;
    public float attackLever;

    public GameObject TopTips;

    private float GameTimeCount;
    public float TimeCount;
    private Vector2 NextPosition;
    private int count=0;
    // Start is called before the first frame update
    void Start()
    {
        timberjackDeadNumber = 0;
        hunterDeadNumber = 0;
        GameTimeCount = 0;
        TimeCount = 0;
        attackLever = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        AttackState();
        GameTimeCount += Time.deltaTime;
        if (GameTimeCount >= preparationTime)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount >= TimberjackMakeCD)
            {
                if(count==0)
                {
                    gameObject.GetComponent<slider>().bgmNum = 1;
                    gameObject.GetComponent<slider>().ac.clip= gameObject.GetComponent<slider>().BGM[gameObject.GetComponent<slider>().bgmNum];
                    gameObject.GetComponent<slider>().ac.Play();
                }
                if (count != 0 && gameObject.GetComponent<AudioSource>().isPlaying == false) 
                {
                    gameObject.GetComponent<slider>().bgmNum = 3;
                    gameObject.GetComponent<slider>().ac.clip = gameObject.GetComponent<slider>().BGM[gameObject.GetComponent<slider>().bgmNum];
                    gameObject.GetComponent<AudioSource>().loop = true;
                    gameObject.GetComponent<AudioSource>().volume = 1;
                    
                    gameObject.GetComponent<slider>().ac.Play();
                    TopTips.transform.GetChild(0).GetComponent<Text>().text = "森林正在遭受破坏！";
                    TopTips.SetActive(true);
                }
                if(timberjackNumber<=timberjacklimit)
                {
                    //Debug.Log("刷新伐木工");
                    timberjackMake();
                    TimeCount = 0;
                    count++;
                }
            }
            if (timberjackDeadNumber == 5)
            {

                //Debug.Log("刷新猎人");
                TopTips.transform.GetChild(0).GetComponent<Text>().text = "猎人正在搜索目标！";
                TopTips.SetActive(true);
                TopTips.GetComponent<AudioSource>().Play();
                hunterMake();
                timberjackDeadNumber = 0;
                hunterNumber++;
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
    void AttackState()
    {
        switch (attackLever)
        {
            case 0:
                timberjacklimit = 1;
                break;
            case 1:
                timberjacklimit = 2;
                break;
            case 2:
                timberjacklimit = 3;
                break;
            case 3:
                timberjacklimit = 4;
                break;
            case 4:
                timberjacklimit = 5;
                break;
            case 5:
                timberjacklimit = 6;
                break;
            default:
                timberjacklimit = 7;
                break;
        }

    }
}
