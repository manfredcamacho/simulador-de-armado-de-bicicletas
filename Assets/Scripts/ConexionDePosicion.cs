//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ConexionDePosicion : MonoBehaviour
//{
//    public Transform snapPoint; // Punto donde la pieza debe encajar
//    public float snapDistance = 0.5f; // Distancia m�nima para encajar
//    private bool isAttached = false; // Indica si la pieza ya est� encajada

//    void Update()
//    {
//        // Si la pieza est� cerca y no est� a�n encajada
//        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
//        {
//            SnapToPlace(); // Encajar la pieza en el lugar correcto
//            Debug.Log("encajar pieza");
//        }
//        Debug.Log("Estas lejos");
//    }

//    private void OnMouseUp() // Detecta cuando se suelta la pieza
//    {
//        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
//        {
//            SnapToPlace();
//        }
//    }

//    private void SnapToPlace()
//    {
//        transform.position = snapPoint.position; // Coloca la pieza en la posici�n exacta
//        transform.rotation = snapPoint.rotation; // Ajusta la rotaci�n de la pieza
//        isAttached = true; // Marca la pieza como encajada

//        // Opcional: Desactiva el Rigidbody si ya no es necesario
//        Rigidbody rb = GetComponent<Rigidbody>();
//        if (rb != null)
//        {
//            rb.isKinematic = true;
//        }

//        Debug.Log(gameObject.name + " encajado correctamente en su posici�n.");
//    }
//}
using UnityEngine;

public class SnapToPosition : MonoBehaviour
{
    public Transform snapPoint; // Punto donde la pieza debe encajar
    public float snapDistance = 0.5f; // Distancia m�nima para encajar
    private bool isAttached = false; // Indica si la pieza ya est� encajada
    private bool isBeingHeld = false; // Indica si el objeto est� siendo sostenido

    private void Update()
    {
        // Si est� siendo sostenido, verificar la posici�n para encajar al soltar
        if (isBeingHeld && !isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            SnapToPlace(); // Encajar la pieza en el lugar correcto
        }
    }

    private void OnMouseDown() // Detecta cuando se comienza a sostener el objeto
    {
        if (!isAttached)
        {
            isBeingHeld = true; // Cambia el estado a sostenido
        }
    }

    private void OnMouseUp() // Detecta cuando se suelta la pieza
    {
        isBeingHeld = false; // Cambia el estado a no sostenido

        // Al soltar, verificar si est� cerca del snapPoint
        if (!isAttached && Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            SnapToPlace();
        }
    }

    private void SnapToPlace()
    {
        // Coloca la pieza en la posici�n exacta y alinea su rotaci�n
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;

        isAttached = true; // Marca la pieza como encajada
        isBeingHeld = false; // Cambia el estado a no sostenido para que se quede en su lugar

        // Opcional: Desactiva el Rigidbody si ya no es necesario
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log(gameObject.name + " encajado correctamente en su posici�n.");
    }
}
