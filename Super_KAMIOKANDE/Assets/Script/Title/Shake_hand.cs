using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shake_hand : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 befor_shake;
    Vector3 after_shake;

    Vector3 is_shake;

    void Start()
    {
        after_shake = Input.acceleration;
        befor_shake = after_shake;
    }

    // Update is called once per frame
    void Update()
    {
        after_shake = Input.acceleration;

        is_shake = after_shake - befor_shake;
        if(is_shake.magnitude >= 1)
        {
            SceneManager.LoadScene("Main");
        }

        befor_shake = after_shake;

    }
}
