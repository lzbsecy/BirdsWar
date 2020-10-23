using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSelection : MonoBehaviour
{
    public bool Selection = false;

    private int state=0;
    private bool lastState;
    private void Start()
    {
        Selection = false;
        state = 0;
    }
    private void Update()
    {
        if(Selection!=lastState && Selection==true)
        {
            state = 1;
        }
        if(state==1)
        {
            gameObject.GetComponent<AudioSource>().Play();
            state = 0;
        }
        lastState = Selection;
    }

}
