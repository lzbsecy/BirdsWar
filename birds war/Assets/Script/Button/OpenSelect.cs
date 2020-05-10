using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenSelect : MonoBehaviour
{
    public AudioClip ac;
    public GameObject SelectionBox;

    void Start()
    {
    
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(ac, transform.position);
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
