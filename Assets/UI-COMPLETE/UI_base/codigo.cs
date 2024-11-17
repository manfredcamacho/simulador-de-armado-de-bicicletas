using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements; // Agregar namespace para usar en runtime

public class NewBehaviourScript : MonoBehaviour // Clase que hereda de MonoBehaviour
{
    // Documento de UI (archivo UXML)
    private UIDocument menu;

    // Variables botones menú principal
    private Button showInstructions;
    private Button startBtn; // mismo nombre del elemento para evitar error 
    private Button bicycle1;
    private Button backBtn;
    VisualElement leftContainer;
    VisualElement rightContainer;
    private void OnEnable()
    {
        // Obtener el UIDocument y el elemento raíz del archivo UXML:visualElement
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement; 

        // Asignación de los botones utilizando sus ID en UXML
        showInstructions = root.Q<Button>("instructionsBtn"); // usar el mismo name del UXML
        startBtn = root.Q<Button>("startBtn");
        bicycle1 = root.Q<Button>("bicycle1");
        backBtn = root.Q<Button>("backBtn");

        leftContainer = root.Q<VisualElement>("leftContainer");
        rightContainer = root.Q<VisualElement>("rightContainer");

        // Eventos 
        showInstructions.clicked += ShowInstructionsMethod;
        //startBtn.clicked += StartGameMethod; 
        startBtn.RegisterCallback<ClickEvent>(OpenGarage);
        bicycle1.clicked += StartGameMethod;
        backBtn.clicked += BackToMethod;
    }

    //Mostrar las instrucciones
    private void ShowInstructionsMethod()
    {
        Debug.Log("Mostrando instrucciones...");
        // FUNCIONA
    }

    //Abrir garage
    private void OpenGarage(ClickEvent evt)
    {
        leftContainer.AddToClassList("left-container-active");
        rightContainer.AddToClassList("right-container-active");
    }
    //Empezar el juego
    private void StartGameMethod()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //volver atrás
    private void BackToMethod()
    {
        leftContainer.RemoveFromClassList("left-container-active");
        rightContainer.RemoveFromClassList("right-container-active");
    }
}
    