using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 start_pos;
    void Start()
    {
        now_time = 0;
        start_pos = this.transform.position;
    }

    float minAngle = -5.0f, maxAngle = 5.0f;
    float now_time;
    float wave_time = 0.3f;
    bool is_wave = true;

    // Update is called once per frame
    void Update()
    {

        now_time += Time.deltaTime;

        float angle = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Sin((now_time / wave_time) * Mathf.PI)) / 2.0f);
        transform.eulerAngles = new Vector3(0, 0, angle);
        transform.position = new Vector3(0, angle * 0.01f, 0) + start_pos;

    }
}
