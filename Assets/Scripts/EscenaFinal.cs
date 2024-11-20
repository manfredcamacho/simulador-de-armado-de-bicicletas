using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    public TextMeshProUGUI lastTime;

    void Start()
    {
        mostrarPunteroMouse();
        recuperarUltimoTiempo();
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
