using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; // Agregar namespace para usar en runtime

public class NewBehaviourScript : MonoBehaviour // Clase que hereda de MonoBehaviour
{
    // Documento de UI (archivo UXML)
    private UIDocument menu;

    // Variables botones men� principal
    private Button showInstructions;
    private Button startBtn; // mismo nombre del elemento para evitar error 

    private void OnEnable()
    {
        // Obtener el UIDocument y el elemento ra�z del archivo UXML:visualElement
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement; 

        // Asignaci�n de los botones utilizando sus ID en UXML
        showInstructions = root.Q<Button>("instructionsBtn"); // usar el mismo name del UXML
        startBtn = root.Q<Button>("startBtn");

        // Eventos 
        showInstructions.clicked += ShowInstructionsMethod;
        startBtn.clicked += StartGameMethod; // chequear name
    }

    // M�todo mostrar las instrucciones
    private void ShowInstructionsMethod()
    {
        Debug.Log("Mostrando instrucciones...");
        // FUNCIONA
    }

    // M�todo para empezar el juego
    private void StartGameMethod()
    {
        Debug.Log("Empezando el juego...");
        // FUNCIONA
    }
}
