using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private RaycastHit raycastHit;

    void Update()
    {
        // Desactiva el resaltado del objeto anterior
        if (highlight != null && highlight.gameObject.GetComponent<Outline>() != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        // Raycast desde la posición del ratón
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;

            // Verifica si el objeto es seleccionable y tiene el componente Outline
            if (highlight.CompareTag("ParteBicicleta"))
            {
                Outline outline = highlight.gameObject.GetComponent<Outline>();

                if (outline != null)
                {
                    Debug.Log("Objeto con Outline encontrado: " + highlight.name);
                    outline.enabled = true;
                }
                else
                {
                    // Agrega el componente Outline si no está presente
                    Debug.Log("Agregando Outline a: " + highlight.name);
                    outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    outline.OutlineColor = Color.magenta;
                    outline.OutlineWidth = 9.0f;
                }
            }
            else
            {
                Debug.Log("El objeto no tiene la etiqueta 'ParteBicicleta'");
                highlight = null;
            }
        }
    }
}
