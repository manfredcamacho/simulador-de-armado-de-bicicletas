using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrdenDeArmadoBicicleta : MonoBehaviour
{
    public List<GameObject> ordenDeArmado;
    public Material materialResaltado; // Material para resaltar el siguiente punto de encaje
    private int indiceActual = 0; // �ndice de la pieza actual a colocar
    public GameObject scripts;

    void Start()
    {
        if (ordenDeArmado.Count > 0)
        {
            ResaltarPieza(indiceActual); // Resaltar el primer punto de encaje
        }
    }

    public bool PuedeColocarPieza(GameObject pieza)
    {
        // Verifica si la pieza es igual con el siguiente en la secuencia
        return ordenDeArmado[indiceActual] == pieza;
    }
    public GameObject PiezaSiguiente()
    {
        return ordenDeArmado[indiceActual];
     
    }
    public void ResaltarSiguientePieza()
    {
        indiceActual++; 

        // Si quedan m�s piezas, resalta el siguiente punto
        if (indiceActual < ordenDeArmado.Count)
        {
            Debug.Log("Hay mas partes, resaltando parte " + ordenDeArmado[indiceActual].name);
            ResaltarPieza(indiceActual);
        }
        else
        {
            Debug.Log("Bicicleta armada correctamente.");
            scripts.GetComponent<Timer>().stopTimer();
            scripts.GetComponent<Timer>().saveTime();
            SceneManager.LoadScene("Final");
        }
    }

    private void ResaltarPieza(int indice)
    {
        //Obtiene la pieza virtual a resaltar enlazado a traves del script ConexionDePosicion
        Renderer renderer = ordenDeArmado[indice].GetComponent<ConexionDePosicion>().snapPoint.GetComponent<Renderer>();
        //Resaltar la pieza virtual a traves de materialResaltado
        renderer.materials = Enumerable.Repeat(materialResaltado, renderer.materials.Length).ToArray();
    }
}
