using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenSelect : MonoBehaviour
{
    
    public GameObject SelectionBox;

    private AudioSource ac;
    void Start()
    {
        ac = gameObject.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ac.Play();
        if (SelectionBox.activeSelf == true)
        {
            Time.timeScale = 1;
            SelectionBox.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            SelectionBox.SetActive(true);
        }
        
    }
    void Update()
    {

    }
}
