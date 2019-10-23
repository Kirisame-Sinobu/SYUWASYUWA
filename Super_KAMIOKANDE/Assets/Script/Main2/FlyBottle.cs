using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBottle : MonoBehaviour
{

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float speed;
    [SerializeField] private float riseSpeed;
    [SerializeField] private GameObject flymodemanager;
    public static float shakePow = 100f;
    public static bool isStart;
    private FlyModeManager _flyModeManager;
    //public float ShakePow { get { return shakePow;} set { shakePow = value;}

    Vector3 dir;

    private void Start()
    {
        Debug.Log("acceleration.x.start : " + Input.acceleration.x);
        isStart = false;
        _flyModeManager = flymodemanager.GetComponent<FlyModeManager>();
        dir.x = 0.0f;
    }

    void Update()
    {
        if (!isStart)
        {
            return;
        }
        //Debug.Log(shakePow);
        if (shakePow >= 0f)
        {
            Rise();
        }
        else
        {
            Finish();
        }
        //Vector3 dir = Vector3.zero;
        //dir.x = Input.acceleration.x;

        //if (dir.sqrMagnitude > 1) {
        //    dir.Normalize();
        //}


        //dir *= Time.deltaTime;
        //transform.Translate(dir * speed);
        //transform.Rotate(new Vector3(0f, 0f, -dir.x * speed * 40));
        //Debug.Log(dir);

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,leftLimit,
            rightLimit), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            return;
        }
        dir = Vector3.zero;
        if (Input.acceleration.x >= 0.1f || Input.acceleration.x <= -0.1f)
        {
            dir.x = Input.acceleration.x;
        }
        Debug.Log("dir.x1 : " + dir.x);

        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }


        dir *= Time.deltaTime;
        //Debug.Log(dir);
        // 入力情報
        float turn = -dir.x * speed * 5;
        // 現在の回転角度を0～360から-180～180に変換
        float rotateZ = (transform.eulerAngles.z > 180) ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
        // 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
        float angleZ = Mathf.Clamp(rotateZ + turn * speed, -80, 80);
        // 回転角度を-180～180から0～360に変換
        angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;
        // 回転角度をオブジェクトに適用
        transform.rotation = Quaternion.Euler(0, 0, angleZ);
        Debug.Log("angleZ : " + angleZ);
        Debug.Log("turn : " + turn);
        Debug.Log("dir.x2 : " + dir.x);
        Debug.Log("acceleration.x : " + Input.acceleration.x);
    }

    public void Rise() {
        this.transform.Translate(0, riseSpeed, 0);
        //transform.position += transform.forward * (-riseSpeed);


    }

    public void Finish()
    {
        _flyModeManager.FinishText();
    }
    

}
