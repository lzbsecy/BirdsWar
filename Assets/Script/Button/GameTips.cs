using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTips : MonoBehaviour
{
    public GameObject panel;
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        ac=gameObject.GetComponent<AudioSource>();

        GetComponent<Button>().onClick.AddListener(OnClick);
        
    }
    void OnClick()
    {
        if (panel.activeSelf == false)
        {
            ac.Play();
            panel.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
