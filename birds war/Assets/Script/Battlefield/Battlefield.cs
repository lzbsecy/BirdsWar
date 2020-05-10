using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{

    public List<GameObject> Birds;
    public GameObject Hunter;
    public GameObject Timberjack;
    public float TimeCount;

    private int timeCount;
    private int timecount;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 0;
        timeCount = 0;
        timecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        timeCount = (int)TimeCount;
       
        fight();

        TheEnd();
    }
    int FightingCapacity()
    {
        int SumAck=0;
        foreach(GameObject obj in Birds)
        {
            if(obj!=null)
            {
                SumAck = SumAck + obj.GetComponent<Birds>().ACK;
            }
        }
        return SumAck;
    }

    void fight()
    {
        if (timecount != timeCount)
        {
            timecount = timeCount;
            if(Hunter==null)
            {
                Timberjack.GetComponent<Timberjack>().Life = Timberjack.GetComponent<Timberjack>().Life - FightingCapacity();
                if(Timberjack.GetComponent<Timberjack>().Life<=0)
                {
                    Timberjack.SetActive(true);
                    Timberjack = null;
                }  
                foreach(GameObject obj in Birds)
                {
                    obj.GetComponent<IsSelection>().Selection = false;
                }
            }
            else
            {
                Hunter.GetComponent<Hunter>().Life = Hunter.GetComponent<Hunter>().Life - FightingCapacity();
                if (Hunter.GetComponent<Hunter>().Life <= 0)
                {
                    Hunter.SetActive(true);
                    Hunter = null;
                }
                
                Birds[0].GetComponent<Birds>().Life = Birds[0].GetComponent<Birds>().Life - 1;

                if (Birds[0].GetComponent<Birds>().Life<=0)
                {
                    Debug.Log(Birds[0].GetComponent<Birds>().Life + "qweqwe");
                    Birds[0].SetActive(true);
                    Birds.Remove(Birds[0]);
                }
                
            }

            
        }
            
    }

    //判断结束
    void TheEnd()
    {
        if (Birds.Count == 0)//敌人胜利
        {
            
            if(Timberjack!=null)
            {
                Timberjack.SetActive(true);
                Timberjack.GetComponent<Timberjack>().state = 0;
            }
            if(Hunter!=null)
            {
                Hunter.SetActive(true);
                Hunter.GetComponent<Hunter>().state = 0;
            }
                    
            destory();
        }
        else if(Hunter==null && Timberjack==null) //🐥胜利
        {
            foreach(GameObject obj in Birds)
            {
                obj.SetActive(true);    
            }
            
            destory();
        }
    }

    //销毁
    void destory()
    {
        Destroy(gameObject);
    }
}
