using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_time : MonoBehaviour
{
    float start_time = 4.0f;
    float start_pos = 1500.0f;
    float end_pos = 0.0f;

    [SerializeField]
    private GameObject last_time_text; 
    

    // Start is called before the first frame update
    void Start()
    {
        start_time = 4.0f;
        end_pos = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        start_time -= Time.deltaTime;

        if(start_time >= 3)
        {
            three_time();
        }else if(start_time >= 2)
        {
            two_time();
        }else if(start_time >= 1)
        {
            one_time();
        }else if(start_time >= 0)
        {
            if (!last_time_text.activeSelf)
            {
                last_time_text.SetActive(true);
            }
            zero_time();
        }
        else
        {
            fede_out();
        }
    }

    void three_time()
    {
        Vector3 pos = this.transform.localPosition;
        this.GetComponent<Text>().text = "3";
        if (start_time >= 3.5f)
        {
            pos.y = Mathf.Lerp(start_pos, end_pos, Mathf.Sin((4.0f - start_time) * Mathf.PI));
            //Debug.Log(Mathf.Sin((4.0f - start_time) * Mathf.PI));
            //Debug.Log(pos.y);
            this.transform.localPosition = pos;
        }
        else
        {
            pos.y = end_pos;
            this.transform.localPosition = pos;
        }

    }

    void two_time()
    {
        Vector3 pos = this.transform.localPosition;
        this.GetComponent<Text>().text = "2";
        if (start_time >= 2.5f)
        {
            pos.y = Mathf.Lerp(start_pos, end_pos, Mathf.Sin((3.0f - start_time) * Mathf.PI));
            this.transform.localPosition = pos;
        }
        else
        {
            pos.y = end_pos;
            this.transform.localPosition = pos;
        }
    }

    void one_time()
    {
        Vector3 pos = this.transform.localPosition;
        this.GetComponent<Text>().text = "1";
        if (start_time >= 1.5f)
        {
            pos.y = Mathf.Lerp(start_pos, end_pos, Mathf.Sin((2.0f - start_time) * Mathf.PI));
            this.transform.localPosition = pos;
        }
        else
        {
            pos.y = end_pos;
            this.transform.localPosition = pos;
        }
    }

    void zero_time()
    {
        Vector3 pos = this.transform.localPosition;
        this.GetComponent<Text>().text = "フレ！";
        if (start_time >= 0.5f)
        {
            pos.y = Mathf.Lerp(start_pos, end_pos, Mathf.Sin((1.0f - start_time) * Mathf.PI));
            this.transform.localPosition = pos;
        }
        else
        {
            pos.y = end_pos;
            this.transform.localPosition = pos;
        }
    }

    float fade;
    void fede_out()
    {
        this.GetComponent<Text>().color = new Color(1, 1, 1, Mathf.Clamp(1.0f-Mathf.Abs(start_time),0.0f,1.0f));
        if (start_time <= -1)
        {
            Destroy(this.gameObject);
        }
    }
}
