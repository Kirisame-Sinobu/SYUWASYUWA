using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Last_time : MonoBehaviour
{
    float last_time = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        last_time -= Time.deltaTime;
        this.GetComponent<Text>().text = "のこり:" + Mathf.Clamp(((int)last_time),0.0f,last_time).ToString("f0");
        //Debug.Log(Mathf.Clamp(((int)last_time), 0.0f, 5.0f));

    }
}
