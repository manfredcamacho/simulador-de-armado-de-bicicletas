using UnityEngine;
using TMPro; // Para mostrar el texto de las estad�sticas

public class EstadisticasArmado : MonoBehaviour
{
    public TextMeshProUGUI estadisticasText;  // UI para mostrar las estad�sticas al final
    public Timer timerScript;  // Para acceder al tiempo final
    private int piezasCorrectas = 0;  // Contador de piezas correctas
    private int piezasIncorrectas = 0;  // Contador de piezas incorrectas

    // M�todo para incrementar el contador de piezas correctas
    public void IncrementarAcierto()
    {
        piezasCorrectas++;
        Debug.Log(piezasCorrectas);
    }

    // M�todo para incrementar el contador de piezas incorrectas
    public void IncrementarError()
    {
        piezasIncorrectas++;
        Debug.Log(piezasCorrectas);
    }

    // M�todo para mostrar las estad�sticas al finalizar
    public void MostrarEstadisticas()
    {
        // Obtener el tiempo final de la simulaci�n
        int horas = Mathf.FloorToInt(timerScript.timer / 3600);
        int minutos = Mathf.FloorToInt((timerScript.timer / 60) % 60);
        int segundos = Mathf.FloorToInt(timerScript.timer % 60);

        string tiempoFinal = $"{horas:00}:{minutos:00}:{segundos:00}";

        // Mostrar las estad�sticas
        estadisticasText.text = $"Tiempo Final: {tiempoFinal}\n" +
                                $"Piezas Correctas: {piezasCorrectas}\n" +
                                $"Piezas Incorrectas: {piezasIncorrectas}";
    }
}
