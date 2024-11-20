using UnityEngine;
using TMPro; // Para mostrar el texto de las estadísticas

public class EstadisticasArmado : MonoBehaviour
{
    public TextMeshProUGUI estadisticasText;  // UI para mostrar las estadísticas al final
    public Timer timerScript;  // Para acceder al tiempo final
    private int piezasCorrectas = 0;  // Contador de piezas correctas
    private int piezasIncorrectas = 0;  // Contador de piezas incorrectas

    // Método para incrementar el contador de piezas correctas
    public void IncrementarAcierto()
    {
        piezasCorrectas++;
        Debug.Log(piezasCorrectas);
    }

    // Método para incrementar el contador de piezas incorrectas
    public void IncrementarError()
    {
        piezasIncorrectas++;
        Debug.Log(piezasCorrectas);
    }

    // Método para mostrar las estadísticas al finalizar
    public void MostrarEstadisticas()
    {
        // Obtener el tiempo final de la simulación
        int horas = Mathf.FloorToInt(timerScript.timer / 3600);
        int minutos = Mathf.FloorToInt((timerScript.timer / 60) % 60);
        int segundos = Mathf.FloorToInt(timerScript.timer % 60);

        string tiempoFinal = $"{horas:00}:{minutos:00}:{segundos:00}";

        // Mostrar las estadísticas
        estadisticasText.text = $"Tiempo Final: {tiempoFinal}\n" +
                                $"Piezas Correctas: {piezasCorrectas}\n" +
                                $"Piezas Incorrectas: {piezasIncorrectas}";
    }
}
