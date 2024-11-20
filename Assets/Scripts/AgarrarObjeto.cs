using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public Camera playerCamera; // C�mara PlayerCamera dentro de FirstPersonController
    public Vector3 offset = new Vector3(0, -0.5f, 1.0f); // Posici�n relativa para colocar el objeto
    public float moveSpeed = 5f; // Velocidad de movimiento del objeto
    private int piezasIncorrectas = 0;  // Contador de piezas incorrectas
    private GameObject selectedObject = null; // Objeto que ser� seleccionado al hacer clic
    private bool isObjectAttached = false; // Indica si el objeto est� "agarrado"

    void Update()
    {
        // Proyectar un rayo desde la c�mara hacia el mouse
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
                return; // Salimos del m�todo
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

        // Si un objeto est� "agarrado", moverlo con la c�mara
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
        // Desactivar la f�sica del objeto para que no se vea afectado por la gravedad
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
            // Rehabilitar la f�sica del objeto
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
        // Calcular la nueva posici�n del objeto en relaci�n con la c�mara
        Vector3 targetPosition = playerCamera.transform.position
                                 + playerCamera.transform.forward * offset.z
                                 + playerCamera.transform.up * offset.y
                                 + playerCamera.transform.right * offset.x;

        // Interpolar suavemente la posici�n del objeto hacia la nueva posici�n
        selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, targetPosition, Time.deltaTime * moveSpeed);

        // Hacer que el objeto siempre mire hacia la c�mara
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