using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    Flashlight FlashlightManager;

    void Start()
    {
        FlashlightManager = GetComponent<Flashlight>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10))
        {
            if (hit.collider.CompareTag("Battery") && Input.GetMouseButtonDown(0))
            {
                Destroy(hit.transform.gameObject);
                FlashlightManager.Power += 50;
            }
        }
    }
}