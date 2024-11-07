using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfazControl : MonoBehaviour
{
    public TextMeshProUGUI instruccionesText; // Texto de instrucciones
    public TextMeshProUGUI mensajeBienHechoText; // Texto de "Bien Hecho"
    public Slider barraProgreso; // Slider de progreso
    public Button botonIncrementar; // Botón para incrementar el progreso
    public Camera camaraFirstPerson; // Cámara en primera persona
    public Camera camaraInterfaz; // Cámara fija para la interfaz final
    public Slider progressSlider;  // Slider de progreso
    public Button increaseButton;  // Botón para incrementar el progreso
    private float progresoActual = 0f; // Progreso inicial

    void Start()
    {
        // Configurar UI y cámaras
        instruccionesText.gameObject.SetActive(false); // Ocultar instrucciones al inicio
        mensajeBienHechoText.gameObject.SetActive(false);
        barraProgreso.gameObject.SetActive(false);
        botonIncrementar.gameObject.SetActive(false);
        camaraInterfaz.gameObject.SetActive(false);

        // Asignar el botón a su evento
        botonIncrementar.onClick.AddListener(IncrementarProgreso);
    }

    public void MostrarInterfazFinal()
    {
        // Cambiar la cámara a la interfaz
        camaraFirstPerson.gameObject.SetActive(false);  // Desactiva la cámara de primera persona
        camaraInterfaz.gameObject.SetActive(true);    // Activa la cámara de interfaz

        // Muestra un mensaje de "Bien hecho!" en la interfaz
        GameObject mensajeFinal = GameObject.Find("InstruccionesText"); // Asegúrate de que este nombre coincida con el objeto de texto en tu escena
        if (mensajeFinal != null)
        {
            mensajeFinal.GetComponent<UnityEngine.UI.Text>().text = "¡Bien hecho! Has completado el armado de la bicicleta.";
        }

        // Asumimos que el Slider y el Button ya están referenciados en el Inspector.
        // Si no están, asigna las referencias manualmente o mediante código.

        progressSlider.value = 0;  // Inicializa el slider en 0
        increaseButton.onClick.AddListener(IncrementarSlider);  // Asocia el método de incremento al botón

        Debug.Log("Armado de la bicicleta completado, mostrando interfaz final.");
    }

    private void IncrementarSlider()
    {
        // Incrementa el valor del slider con un paso (puedes ajustar el incremento según sea necesario)
        if (progressSlider.value < progressSlider.maxValue)
        {
            progressSlider.value += 10;  // Aumenta el valor en 10 unidades por clic (ajustable)
            Debug.Log("Progreso incrementado: " + progressSlider.value);
        }
        else
        {
            Debug.Log("El progreso está completo.");
        }
    }


    private void IncrementarProgreso()
    {
        progresoActual += 0.1f;
        barraProgreso.value = progresoActual;

        if (progresoActual >= 1f)
        {
            instruccionesText.text = "¡Progreso completado!";
        }
    }
}
