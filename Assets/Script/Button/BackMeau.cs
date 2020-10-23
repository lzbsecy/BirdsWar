using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMeau : MonoBehaviour
{

    private AudioSource ac;
    void Start()
    {
        ac = gameObject.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ac.Play();
        SceneManager.LoadScene("MainMeau");
        Time.timeScale = 1;
    }
    void Update()
    {
      
    }
}
