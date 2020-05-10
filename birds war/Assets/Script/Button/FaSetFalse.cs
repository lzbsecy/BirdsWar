using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaSetFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        transform.parent.gameObject.SetActive(false);        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
