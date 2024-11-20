using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public Camera playerCamera; // Cámara PlayerCamera dentro de FirstPersonController
    public Vector3 offset = new Vector3(0, -0.5f, 1.0f); // Posición relativa para colocar el objeto
    public float moveSpeed = 5f; // Velocidad de movimiento del objeto
    private int piezasIncorrectas = 0;  // Contador de piezas incorrectas
    private GameObject selectedObject = null; // Objeto que será seleccionado al hacer clic
    private bool isObjectAttached = false; // Indica si el objeto está "agarrado"

    void Update()
    {
        // Proyectar un rayo desde la cámara hacia el mouse
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Si hay un objeto seleccionado, lo soltamos
            if (isObjectAttached)
            {
                // Soltar el objeto
                ReleaseObject();
                return; // Salimos del método
            }

            // Verificar si el rayo ha tocado un objeto con el tag "ParteBicicleta"
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("ParteBicicleta"))
                {
                    // Agarrar el nuevo objeto
                    GrabObject(hit.collider.gameObject);
                }
            }
        }

        // Si un objeto está "agarrado", moverlo con la cámara
        if (isObjectAttached && selectedObject != null)
        {
            MoveObject();
        }
    }
    public void IncrementarError()
    {
        piezasIncorrectas++;
        StaticData.cantidadErrores++;
        Debug.Log($"Cantidad de errores {piezasIncorrectas}");
    }

    private void GrabObject(GameObject obj)
    {
        gameObject.GetComponent<Timer>().startTimer();
        selectedObject = obj;
        isObjectAttached = true;
        OrdenDeArmadoBicicleta ordenDeArmado = obj.GetComponentInParent<OrdenDeArmadoBicicleta>();
        // Desactivar la física del objeto para que no se vea afectado por la gravedad
        Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
        if (obj != ordenDeArmado.PiezaSiguiente())
        {
            IncrementarError();
        }
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Desactivar el collider del objeto
        Collider coll = selectedObject.GetComponent<Collider>();
        if (coll != null)
        {
            coll.enabled = false;
        }

    }

    public void ReleaseObject()
    {   

        if (selectedObject != null)
        {
            // Rehabilitar la física del objeto
            Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            // Reactivar el collider del objeto
            Collider coll = selectedObject.GetComponent<Collider>();
            if (coll != null)
            {
                coll.enabled = true;
            }
            selectedObject = null; // Limpiar la referencia del objeto seleccionado
            isObjectAttached = false; // Cambiar el estado a no agarrado
        }

    }

    private void MoveObject()
    {
        // Calcular la nueva posición del objeto en relación con la cámara
        Vector3 targetPosition = playerCamera.transform.position
                                 + playerCamera.transform.forward * offset.z
                                 + playerCamera.transform.up * offset.y
                                 + playerCamera.transform.right * offset.x;

        // Interpolar suavemente la posición del objeto hacia la nueva posición
        selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, targetPosition, Time.deltaTime * moveSpeed);

        // Hacer que el objeto siempre mire hacia la cámara
        selectedObject.transform.LookAt(playerCamera.transform.position);
    }
}
/*1 Cuerpo
2 Cruz
3 Rueda Delante
4 Rueda Trasera
5 Pedalera
6 Pedal Derecho
7 Pedal Izquierdo 
Este orden va porque va de mas facil a mas dificil*/