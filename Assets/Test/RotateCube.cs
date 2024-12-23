using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class RotateCube : MonoBehaviour
{
    public GameObject cube;
    public Slider slider;
    bool isRotatoin = false;
    public int speed;
    public int angle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRotatoin) 
        {
            Vector3 rotationsPreupdate = new Vector3(0, slider.value, 0);
            cube.transform.Rotate(rotationsPreupdate * Time.deltaTime);
        }
    }
    public void StopRotation()
    {
        isRotatoin = !isRotatoin;
    }

}
