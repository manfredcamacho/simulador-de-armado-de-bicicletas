using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConexionDePosicion : MonoBehaviour
{
    public Transform snapPoint; 
    public float snapDistance = 0.5f; 
    private bool isAttached = false;
    public GameObject agarraScript;

    void Update()
    {
        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            OrdenDeArmadoBicicleta orden = gameObject.GetComponentInParent<OrdenDeArmadoBicicleta>();
            if (orden.PuedeColocarPieza(gameObject))
            {
                AgarrarObjeto agarrar = agarraScript.GetComponent<AgarrarObjeto>();
                agarrar.ReleaseObject();
                SnapToPlace();
                orden.ResaltarSiguientePieza();
            }
            else
            {
                //cambiar color de la pieza?
                Debug.Log("No es la pieza correcta");
            }
        }
        
    }

    private void SnapToPlace()
    {
        transform.position = snapPoint.position; 
        transform.rotation = snapPoint.rotation;
        isAttached = true; 
        snapPoint.gameObject.SetActive(false);
        gameObject.tag = "Untagged";
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        
    }
}
