using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZoneFacade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        /*Renderer snapZone = GetComponent<Renderer>();
        snapZone.material.color = Color.red;*/

    }

    private void OnTriggerEnter(Collider other)
    {
        /*Renderer snapZone = GetComponent<Renderer>();
        snapZone.material.color = new Color(0, 1, 0, 0.2f);*/
    }

    private void OnTriggerExit(Collider other)
    {
        /*Renderer snapZone = GetComponent<Renderer>();
        snapZone.material.color = new Color(1, 0, 0, 0.2f);*/
    }
}
