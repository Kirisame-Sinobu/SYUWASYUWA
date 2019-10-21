using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_pawer : MonoBehaviour
{

    Vector3 start_pos;
    void Start()
    {
        start_pos = this.transform.position;
        after_shake = Input.acceleration;
        befor_shake = after_shake;
        bubble_time = criate_time;
    }

    float minAngle = -30.0f, maxAngle = 30.0f;
    Vector3 befor_shake;
    Vector3 after_shake;

    float now_pawer;
    float pawer;

    float now_time;
    float wave_time = 1.0f;

    public GameObject bubble;

    float bubble_time = 0.0f;
    float criate_time = 1.0f;

    // Update is called once per frame
    void Update()
    {
        after_shake = Input.acceleration;
        now_pawer = (after_shake - befor_shake).magnitude;
        pawer += now_pawer;

        now_time += Time.deltaTime;

        float angle = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Sin(now_pawer * (now_time / wave_time) * Mathf.PI)) / 2.0f);
        transform.eulerAngles = new Vector3(0, 0, angle);
        float pos = Mathf.LerpAngle(minAngle, maxAngle, (1 + Mathf.Cos(now_pawer * (now_time / wave_time) * Mathf.PI)) / 2.0f);
        transform.position = new Vector3(0, pos * 0.02f, 0) + start_pos;
        befor_shake = after_shake;
    }

    void criate_bubble()
    {
        bubble_time += Time.deltaTime;
        GameObject temp;
        if (bubble_time > (criate_time - now_pawer))
        {
            temp = Instantiate(bubble, new Vector3(Random.Range(-3.0f, 3.0f), -6, 0), Quaternion.identity);
            float temp_size = Random.Range(0.03f, 0.1f);
            temp.transform.localScale = new Vector3(temp_size, temp_size, temp_size);
            Material temp_mate;
            temp_mate = temp.GetComponent<Renderer>().material;
            temp_mate.SetFloat("_Wave", Random.Range(0.1f, 1.5f));
            temp_mate.SetFloat("_Speed", Random.Range(5.0f, 15.0f));
            //Debug.Log(temp_mate.GetFloat("_Speed"));
            temp_mate.SetFloat("_Speed", Random.Range(0.1f, 3.0f));
            temp.GetComponent<Renderer>().material = temp_mate;
            bubble_time = 0;
        }
    }

    public float Get_pawer { get { return pawer;} }
}
