using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gettan : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 start_pos;
    void Start()
    {
        start_pos = this.transform.position;
    }

    float minAngle = 0f, maxAngle = 180.0f;
    float now_time;
    float wave_time = 1.0f;
    bool is_wave = true;

    // Update is called once per frame
    void Update()
    {
        now_time += Time.deltaTime * Random.Range(0, 100.0f);
        float angle = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Sin((now_time / wave_time) * Mathf.PI)) / 2.0f);
        transform.eulerAngles = new Vector3(0, 0, angle);
        transform.position = new Vector3(0, angle * 0.02f, 0) + start_pos;
    }
}
