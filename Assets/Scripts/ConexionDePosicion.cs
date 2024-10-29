using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConexionDePosicion : MonoBehaviour
{
    public Transform snapPoint; // Punto donde la pieza debe encajar
    public float snapDistance = 0.5f; // Distancia mínima para encajar
    private bool isAttached = false; // Indica si la pieza ya está encajada

    void Update()
    {
        // Si la pieza está cerca y no está aún encajada
        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            SnapToPlace(); // Encajar la pieza en el lugar correcto
            Debug.Log("encajar pieza");
        }
        Debug.Log("Estas lejos");
    }

    private void OnMouseUp() // Detecta cuando se suelta la pieza
    {
        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            SnapToPlace();
        }
    }

    private void SnapToPlace()
    {
        transform.position = snapPoint.position; // Coloca la pieza en la posición exacta
        transform.rotation = snapPoint.rotation; // Ajusta la rotación de la pieza
        isAttached = true; // Marca la pieza como encajada

        // Opcional: Desactiva el Rigidbody si ya no es necesario
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log(gameObject.name + " encajado correctamente en su posición.");
    }
}
