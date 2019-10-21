using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola_wave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        now_time = 0;
    }

    float minAngle = -30.0f, maxAngle = 30.0f;
    float now_time;
    float wave_time = 1.0f;
    bool is_wave = true;

    // Update is called once per frame
    void Update()
    {
        //if (is_wave)
        //{
            now_time += Time.deltaTime;
        //}
        //else
        //{
        //    now_time -= Time.deltaTime;
        //}
        float angle = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Sin((now_time /wave_time) * Mathf.PI))/2.0f);
        transform.eulerAngles = new Vector3(0, 0, angle);
        //if (now_time >= wave_time)
        //{
        //    is_wave = false;
        //}
        //if(now_time <= 0)
        //{
        //    is_wave = true;
        //}
    }
}
