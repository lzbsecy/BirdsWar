using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaSetFalse : MonoBehaviour
{
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = gameObject.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ac.Play();
        transform.parent.gameObject.SetActive(false);        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
