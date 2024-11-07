using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfazControl : MonoBehaviour
{
    public TextMeshProUGUI instruccionesText; // Texto de instrucciones
    public TextMeshProUGUI mensajeBienHechoText; // Texto de "Bien Hecho"
    public Slider barraProgreso; // Slider de progreso
    public Button botonIncrementar; // Bot�n para incrementar el progreso
    public Camera camaraFirstPerson; // C�mara en primera persona
    public Camera camaraInterfaz; // C�mara fija para la interfaz final
    public Slider progressSlider;  // Slider de progreso
    public Button increaseButton;  // Bot�n para incrementar el progreso
    private float progresoActual = 0f; // Progreso inicial

    void Start()
    {
        // Configurar UI y c�maras
        instruccionesText.gameObject.SetActive(false); // Ocultar instrucciones al inicio
        mensajeBienHechoText.gameObject.SetActive(false);
        barraProgreso.gameObject.SetActive(false);
        botonIncrementar.gameObject.SetActive(false);
        camaraInterfaz.gameObject.SetActive(false);

        // Asignar el bot�n a su evento
        botonIncrementar.onClick.AddListener(IncrementarProgreso);
    }

    public void MostrarInterfazFinal()
    {
        // Cambiar la c�mara a la interfaz
        camaraFirstPerson.gameObject.SetActive(false);  // Desactiva la c�mara de primera persona
        camaraInterfaz.gameObject.SetActive(true);    // Activa la c�mara de interfaz

        // Muestra un mensaje de "Bien hecho!" en la interfaz
        GameObject mensajeFinal = GameObject.Find("InstruccionesText"); // Aseg�rate de que este nombre coincida con el objeto de texto en tu escena
        if (mensajeFinal != null)
        {
            mensajeFinal.GetComponent<UnityEngine.UI.Text>().text = "�Bien hecho! Has completado el armado de la bicicleta.";
        }

        // Asumimos que el Slider y el Button ya est�n referenciados en el Inspector.
        // Si no est�n, asigna las referencias manualmente o mediante c�digo.

        progressSlider.value = 0;  // Inicializa el slider en 0
        increaseButton.onClick.AddListener(IncrementarSlider);  // Asocia el m�todo de incremento al bot�n

        Debug.Log("Armado de la bicicleta completado, mostrando interfaz final.");
    }

    private void IncrementarSlider()
    {
        // Incrementa el valor del slider con un paso (puedes ajustar el incremento seg�n sea necesario)
        if (progressSlider.value < progressSlider.maxValue)
        {
            progressSlider.value += 10;  // Aumenta el valor en 10 unidades por clic (ajustable)
            Debug.Log("Progreso incrementado: " + progressSlider.value);
        }
        else
        {
            Debug.Log("El progreso est� completo.");
        }
    }


    private void IncrementarProgreso()
    {
        progresoActual += 0.1f;
        barraProgreso.value = progresoActual;

        if (progresoActual >= 1f)
        {
            instruccionesText.text = "�Progreso completado!";
        }
    }
}
