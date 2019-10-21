using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criate_bubble : MonoBehaviour
{

    public GameObject bubble;

    float now_time = 0.0f;
    float criate_time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        now_time = criate_time;
    }

    // Update is called once per frame
    void Update()
    {
        now_time += Time.deltaTime;
        GameObject temp;
        if(now_time > criate_time)
        {
            temp = Instantiate(bubble, new Vector3(Random.Range(-10.0f,10.0f), -6, 0),Quaternion.identity);
            float temp_size = Random.Range(0.1f, 0.7f);
            temp.transform.localScale = new Vector3(temp_size,temp_size,temp_size);
            Material temp_mate;
            temp_mate = temp.GetComponent<Renderer>().material;
            temp_mate.SetFloat("_Wave", Random.Range(0.1f,1.5f));
            temp_mate.SetFloat("_Speed", Random.Range(5.0f, 15.0f));
            //Debug.Log(temp_mate.GetFloat("_Speed"));
            temp_mate.SetFloat("_Speed", Random.Range(0.1f, 3.0f));
            temp.GetComponent<Renderer>().material = temp_mate;
			now_time = 0;
		}
    }
}
