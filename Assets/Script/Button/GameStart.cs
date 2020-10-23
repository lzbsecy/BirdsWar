using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject panel;

    private AudioSource ac;

    void Start()
    {
        ac = gameObject.GetComponent<AudioSource>();

        GetComponent<Button>().onClick.AddListener(OnClick);
        
    }

    void OnClick()
    {
        if (panel.activeSelf == false)
        {
            ac.Play();

            SceneManager.LoadScene("Load");

           // Time.timeScale = 1;
        }

    }
    void Update()
    {
        
    }


}
