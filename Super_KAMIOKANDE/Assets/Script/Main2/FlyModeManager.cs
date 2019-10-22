using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyModeManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float pow;
    void Start()
    {
        pow = FlyBottle.shakePow;
        slider.value = pow/2000f;
        
    }

    void FixedUpdate()
    {
        slider.value -= 0.000325f;
        FlyBottle.shakePow -= 0.65f;
        
    }
}
