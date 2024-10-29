using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgarrarMasPosicion : MonoBehaviour
{
    public Camera playerCamera; // C�mara PlayerCamera
    public Transform snapPoint; // Punto donde el objeto debe encajar
    public Vector3 offset = new Vector3(0, -0.5f, 1.0f); // Posici�n relativa para colocar el objeto
    public float snapDistance = 0.5f; // Distancia m�nima para encajar
    public float moveSpeed = 5f; // Velocidad de movimiento del objeto

    private GameObject selectedObject = null; // Objeto actualmente seleccionado
    private bool isObjectAttached = false; // Indica si el objeto est� "agarrado"
    private bool isAttached = false; // Indica si el objeto est� "encajado"

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detectar clic izquierdo
        {
            // Si el objeto est� agarrado, soltarlo
            if (isObjectAttached)
            {
                ReleaseObject();
                return;
            }

            // Lanza un rayo desde la c�mara hacia el mouse para seleccionar el objeto
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("ParteBicicleta"))
                {
                    GrabObject(hit.collider.gameObject);
                }
            }
        }

        // Mover el objeto mientras est� agarrado
        if (isObjectAttached && selectedObject != null)
        {
            MoveObject();
        }
    }

    private void GrabObject(GameObject obj)
    {
        selectedObject = obj;
        isObjectAttached = true;

        // Desactivar la f�sica del objeto para que no se vea afectado por la gravedad
        Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        Collider coll = selectedObject.GetComponent<Collider>();
        if (coll != null)
        {
            coll.enabled = false;
        }
    }

    private void ReleaseObject()
    {
        if (selectedObject != null)
        {
            // Verificar si est� dentro del rango de encaje y, si es as�, encajarlo
            if (Vector3.Distance(selectedObject.transform.position, snapPoint.position) < snapDistance)
            {
                SnapToPlace();
            }
            else
            {
                // Rehabilitar la f�sica si no est� dentro del rango
                Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
                Collider coll = selectedObject.GetComponent<Collider>();
                if (coll != null)
                {
                    coll.enabled = true;
                }
            }
            selectedObject = null; // Limpiar la referencia
            isObjectAttached = false; // Cambiar el estado a no agarrado
        }
    }

    private void MoveObject()
    {
        Vector3 targetPosition = playerCamera.transform.position
                                 + playerCamera.transform.forward * offset.z
                                 + playerCamera.transform.up * offset.y
                                 + playerCamera.transform.right * offset.x;

        selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, targetPosition, Time.deltaTime * moveSpeed);
        selectedObject.transform.LookAt(playerCamera.transform.position);
    }

    private void SnapToPlace()
    {
        selectedObject.transform.position = snapPoint.position;
        selectedObject.transform.rotation = snapPoint.rotation;
        isAttached = true;

        // Desactivar la f�sica despu�s de encajar
        Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log(selectedObject.name + " encajado correctamente en su posici�n.");
    }
}
