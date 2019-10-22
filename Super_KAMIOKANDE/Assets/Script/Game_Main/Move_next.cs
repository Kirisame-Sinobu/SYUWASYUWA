using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_next : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float next_time = 0;

    // Update is called once per frame
    void Update()
    {
        next_time += Time.deltaTime;
        if(next_time>= 3.0f)
        {
            SceneManager.LoadScene("Main2");
        }
    }
}
