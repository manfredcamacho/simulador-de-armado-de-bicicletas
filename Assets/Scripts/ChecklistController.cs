using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistController : MonoBehaviour
{
    [SerializeField] private List<Toggle> checklistItems;  // Lista de toggles para el checklist
    [SerializeField] private List<GameObject> piecesToPlace;  // Piezas que deben colocarse en su lugar
    private int currentIndex = 0;  // Indice del checklist (controla el orden)

    // Método que debe ser llamado cuando una pieza esté colocada correctamente
    public void MarkPieceAsPlaced(GameObject placedPiece)
    {
        // Verifica si la pieza colocada corresponde al índice actual
        if (piecesToPlace[currentIndex] == placedPiece)
        {
            // Marca el ítem en el checklist
            checklistItems[currentIndex].isOn = true;
            currentIndex++;  // Avanza al siguiente ítem del checklist

            // Opcional: Puedes mostrar un mensaje aquí, por ejemplo:
            Debug.Log($"Pieza {placedPiece.name} colocada correctamente. Ahora sigue con la siguiente.");
        }
    }

    // Método para inicializar la UI
    void Start()
    {
        // Inicializar los toggles, desmarcándolos al inicio
        foreach (var toggle in checklistItems)
        {
            toggle.isOn = false;
        }
    }
}
