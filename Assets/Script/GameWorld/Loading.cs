using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;
    public Text text;

    private float loadNumber;
    private AsyncOperation async;
    // Start is called before the first frame update
    void Start()
    {
        loadNumber = 0;
        async = SceneManager.LoadSceneAsync("Game");
        async.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        loadNumber = Mathf.Lerp(loadNumber, async.progress, Time.deltaTime);
        slider.value = loadNumber / 9 * 10;
        text.text = ((int)(loadNumber / 9 * 10*100)).ToString() + "%";
        if (loadNumber / 9 * 10 > 0.995) 
        {
            loadNumber = 1;
            slider.value = 1;
            text.text = "100%";
            async.allowSceneActivation = true;
        }
    }
}
