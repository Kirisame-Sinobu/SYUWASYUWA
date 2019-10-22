using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyModeManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float pow;
    [SerializeField] private GameObject finish;
    void Start()
    {
        pow = FlyBottle.shakePow;
        slider.value = pow/2000f;
        
    }

    void FixedUpdate()
    {
        if (!FlyBottle.isStart)
        {
            return;
        }
        slider.value -= 0.000325f;
        FlyBottle.shakePow -= 0.65f;
        
    }

    public void FinishText()
    {
        Debug.LogError("きてるやで！");
        finish.SetActive(true);
        Invoke("ToResultScene", 2.0f);
    }

    private void ToResultScene()
    {
        Debug.Log("きて？");
        SceneManager.LoadScene("Result");
    }

}
