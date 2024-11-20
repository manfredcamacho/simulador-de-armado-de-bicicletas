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

    // Método para volver al inicio
    public void VolverAlInicio()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true;
        SceneManager.LoadScene("UI-INTERFACES");// Reemplaza "Inicio" con el nombre de tu escena de inicio
    }

    // Método para cerrar el programa
    public void CerrarPrograma()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // Para detener el modo Play en Unity
        Application.Quit(); // Para cerrar el programa en una build

    }
}
