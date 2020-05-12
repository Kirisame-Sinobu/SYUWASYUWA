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

    bool isLock;
    float lockTime;

    void Start()
    {
        lockTime = 0f;
        isLock = true;
        //after_shake = Input.acceleration;
        after_shake = Vector3.zero;
        //befor_shake = after_shake;
        befor_shake = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLock)
        {
            lockTime += Time.deltaTime;
            if(lockTime >= 2.0f)
            {
                isLock = false;
            }
            return;
        }
        after_shake = Input.acceleration;

        is_shake = after_shake - befor_shake;
        //Debug.Log(is_shake.magnitude);
        if(is_shake.magnitude >= 3)
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                SceneManager.LoadScene("Main");
            }else if(SceneManager.GetActiveScene().name == "Result")
            {
                SceneManager.LoadScene("Title");
            }
        }

        befor_shake = after_shake;

    }
}
