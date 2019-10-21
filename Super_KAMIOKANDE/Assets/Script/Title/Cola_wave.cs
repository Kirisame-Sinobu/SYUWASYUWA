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
    float wave_time = 2.0f;

    // Update is called once per frame
    void Update()
    {
        now_time += Time.deltaTime;
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Mathf.Sin(now_time / wave_time * Mathf.PI));
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (now_time >= wave_time)
        {
            now_time = 0;
        }
    }
}
