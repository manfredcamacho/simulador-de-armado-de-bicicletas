using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar escenas

public class BotonesUI : MonoBehaviour
{
    void Update()
    {
        // Si el jugador presiona la tecla 'H', volver al inicio
        if (Input.GetKeyDown(KeyCode.H))
        {
            VolverAlInicio();
        }

        // Si el jugador presiona la tecla 'K', cerrar el programa
        if (Input.GetKeyDown(KeyCode.K))
        {
            CerrarPrograma();
        }
    }

    // M�todo para volver al inicio
    public void VolverAlInicio()
    {
        SceneManager.LoadScene("UI-INTERFACES");// Reemplaza "Inicio" con el nombre de tu escena de inicio
    }

    // M�todo para cerrar el programa
    public void CerrarPrograma()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // Para detener el modo Play en Unity
        Application.Quit(); // Para cerrar el programa en una build

    }
}
