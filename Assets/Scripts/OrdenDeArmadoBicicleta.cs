using System.Collections.Generic;
using UnityEngine;

public class OrdenDeArmadoBicicleta : MonoBehaviour
{
    public List<Transform> puntosDeEncaje; // Puntos de encaje en el orden correcto de armado
    public List<string> nombresDePiezas; // Nombres de las piezas en el orden correcto
    public Material materialResaltado; // Material rojo para resaltar el siguiente punto de encaje
    public Material materialNormal; // Material original para cuando la pieza está colocada

    private int indiceActual = 0; // Índice de la pieza actual a colocar

    void Start()
    {
        if (puntosDeEncaje.Count > 0)
        {
            ResaltarPunto(indiceActual); // Resaltar el primer punto de encaje
        }
    }

    public bool PuedeColocarPieza(GameObject pieza)
    {
        // Verifica si el nombre de la pieza coincide con el siguiente en la secuencia
        return nombresDePiezas[indiceActual] == pieza.name;
    }

    public void ColocarPieza(GameObject pieza)
    {
        if (!PuedeColocarPieza(pieza)) return;

        // Coloca la pieza en el punto de encaje actual y ajusta su posición y rotación
        pieza.transform.position = puntosDeEncaje[indiceActual].position;
        pieza.transform.rotation = puntosDeEncaje[indiceActual].rotation;

        // Cambia el material del punto de encaje para indicar que la pieza fue colocada
        puntosDeEncaje[indiceActual].GetComponent<Renderer>().material = materialNormal;

        indiceActual++; // Avanza al siguiente punto de encaje

        // Si quedan más piezas, resalta el siguiente punto
        if (indiceActual < puntosDeEncaje.Count)
        {
            ResaltarPunto(indiceActual);
        }
        else
        {
            Debug.Log("Bicicleta armada correctamente.");
        }
    }

    private void ResaltarPunto(int indice)
    {
        // Cambia el material del punto de encaje al color resaltado (rojo)
        puntosDeEncaje[indice].GetComponent<Renderer>().material = materialResaltado;
    }
}
