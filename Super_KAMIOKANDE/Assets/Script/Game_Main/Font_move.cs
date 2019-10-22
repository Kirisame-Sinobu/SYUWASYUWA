using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font_move: MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 start_rotate;
    void Start()
    {
        now_time = 0;
        start_rotate = this.transform.eulerAngles;
    }

    float minAngle = -30.0f, maxAngle = 30.0f;
    float now_time;
    float wave_time = 0.6f;

    // Update is called once per frame
    void Update()
    {
        now_time += Time.deltaTime;

        float angle = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Sin((now_time / wave_time) * Mathf.PI)) / 2.0f);
        transform.eulerAngles = start_rotate + new Vector3(0, 0, angle);
    }
}
