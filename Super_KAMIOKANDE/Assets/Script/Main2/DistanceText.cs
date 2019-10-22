using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
    [SerializeField] private GameObject Cola;

    public static float distance;
    string kyori;
    Text _text;

    // Start is called before the first frame update
    void Start()
    {
        kyori = "きょり：";
        _text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Cola.transform.position.y;
        _text.text = kyori + distance.ToString("F1");
    }
}
