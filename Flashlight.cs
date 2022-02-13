using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public bool IsOn;
    public GameObject FlashlightObject;

    public TMP_Text BatteryLevelText;

    public float Power;

    void Start()
    {
        IsOn = false;
        FlashlightObject.SetActive(false);

        Power = 100;
    }

    void Update()
    {
        BatteryLevelText.text = "Battery: " + Mathf.Round(Power) + "%";

        if (Input.GetMouseButtonDown(1))
        {
            if (IsOn == false && Power > 0)
            {
                IsOn = true;
                FlashlightObject.SetActive(true);
            }
            else
            {
                IsOn = false;
                FlashlightObject.SetActive(false);
            }
        }

        if (IsOn)
        {
            Power -= 1 * Time.deltaTime;
            Power = Mathf.Clamp(Power, 0, 100);

            if (Power == 0)
            {
                IsOn = false;
                FlashlightObject.SetActive(false);
            }
        }
    }
}