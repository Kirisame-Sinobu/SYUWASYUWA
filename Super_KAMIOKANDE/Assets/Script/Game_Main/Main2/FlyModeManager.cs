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
        slider.value = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value -= 0.00001f;
        
    }
}
