using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBottle : MonoBehaviour
{

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float speed;
    [SerializeField] private float riseSpeed;
    public static float shakePow;
    //public float ShakePow { get { return shakePow;} set { shakePow = value;} }

    void Update()
    {
        Rise();
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1) {
            dir.Normalize();
        }

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,leftLimit,
            rightLimit), transform.position.y, transform.position.z);
    }

    public void Rise() {
        this.transform.Translate(0,riseSpeed,0);
        
    }
    

}
