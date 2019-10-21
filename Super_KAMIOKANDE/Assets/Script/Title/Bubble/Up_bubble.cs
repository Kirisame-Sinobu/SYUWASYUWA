using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_bubble : MonoBehaviour
{

    float Up_speed;
    // Start is called before the first frame update
    void Start()
    {
        Up_speed = Random.Range(0.2f, 1.0f);
        //Debug.Log(Up_speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hoge = gameObject.transform.position;
        hoge.y += Up_speed * 0.05f;
        gameObject.transform.position = hoge;
        if (hoge.y > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
