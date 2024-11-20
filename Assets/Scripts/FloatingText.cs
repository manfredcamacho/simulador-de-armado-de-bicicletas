using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;
    Transform unit;
    Transform canvaLabels;
    public Vector3 offset;
    public Transform mainObject;

    void Start()
    {
        mainCamera = Camera.main.transform;
        unit = transform.parent;
        canvaLabels = GameObject.Find("Canvas Labels").transform;
        transform.SetParent(canvaLabels);
    }


    void Update()
    {
        if (mainObject.tag != "ParteBicicleta")
        {
            
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
           transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position); //Look at the camera
           transform.position = unit.position + offset;
        }
    }

}
