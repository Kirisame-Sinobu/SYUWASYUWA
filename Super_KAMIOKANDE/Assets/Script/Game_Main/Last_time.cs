using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Last_time : MonoBehaviour
{
    float last_time = 6.0f;
    [SerializeField]
    private GameObject Shake_pawer;
    Shake_pawer pawar_getter;

    // Start is called before the first frame update
    void Start()
    {
        pawar_getter = Shake_pawer.GetComponent<Shake_pawer>();
    }

    // Update is called once per frame
    void Update()
    {
        last_time -= Time.deltaTime;
        this.GetComponent<Text>().text = "のこり:" + Mathf.Clamp(((int)last_time),0.0f,5.0f).ToString("f0");
        //Debug.Log(Mathf.Clamp(((int)last_time), 0.0f, 5.0f));
        if(last_time <= 0)
        {
            end_shake();
        }
    }

    void end_shake()
    {
        Debug.Log(pawar_getter.Get_pawer);
       　FlyBottle.shakePow = pawar_getter.Get_pawer;
        Destroy(pawar_getter);
    }
}
