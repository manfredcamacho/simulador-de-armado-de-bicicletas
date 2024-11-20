
/*
 * Nombre del Script: EscenaFinal.cs
 
 * 
 * Autores:
 * - Africa Aular
 * - Braian Arguello
 * - Brenda Lugo
 * - Manfred Camacho
 * - Jorge Aguilar
 * 

 */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    public TextMeshProUGUI lastTime;
    public TextMeshProUGUI Errores;
    public TextMeshProUGUI Devolucion;
    void Start()
    {
        mostrarPunteroMouse();
        recuperarUltimoTiempo();
        recuperarErrores();
        calcularPuntaje();
    }
    public void recuperarErrores()
    {
       Errores.text = StaticData.cantidadErrores.ToString();
    }
    public void calcularPuntaje()
    {
        if (StaticData.cantidadErrores == 0)
        {
            Devolucion.text = "Excelente";
        }
        else if(StaticData.cantidadErrores > 0 && StaticData.cantidadErrores <3)
        {
            Devolucion.text = "Muy Bien";
        }
        else if(StaticData.cantidadErrores > 3 && StaticData.cantidadErrores < 5)
        {
            Devolucion.text = "Bien";
        }
        else 
        {
            Devolucion.text = "Intentanlo de nuevo";
        }
    }
    public void SalirDelSimulador()
    {
        Application.Quit();
    }

    public void VolverAlInicio()
    {
        SceneManager.LoadScene("UI-INTERFACES");
    }

    private void recuperarUltimoTiempo()
    {
        lastTime.text = StaticData.lastTime[0].ToString("00") + ":" +
            StaticData.lastTime[1].ToString("00") + ":" +
            StaticData.lastTime[2].ToString("00");
    }

    private void mostrarPunteroMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}



/*
 * Nombre del Script: EscenaFinal.cs
 
 * 
 * Autores:
 * - Africa Aular
 * - Braian Arguello
 * - Brenda Lugo
 * - Manfred Camacho
 * - Jorge Aguilar
 * 

 */