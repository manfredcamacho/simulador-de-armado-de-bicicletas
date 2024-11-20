using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistController : MonoBehaviour
{
    [SerializeField] private List<Toggle> checklistItems;  // Lista de toggles para el checklist
    [SerializeField] private List<GameObject> piecesToPlace;  // Piezas que deben colocarse en su lugar
    private int currentIndex = 0;  // Indice del checklist (controla el orden)

    // M�todo que debe ser llamado cuando una pieza est� colocada correctamente
    public void MarkPieceAsPlaced(GameObject placedPiece)
    {
        // Verifica si la pieza colocada corresponde al �ndice actual
        if (piecesToPlace[currentIndex] == placedPiece)
        {
            // Marca el �tem en el checklist
            checklistItems[currentIndex].isOn = true;
            currentIndex++;  // Avanza al siguiente �tem del checklist

            // Opcional: Puedes mostrar un mensaje aqu�, por ejemplo:
            Debug.Log($"Pieza {placedPiece.name} colocada correctamente. Ahora sigue con la siguiente.");
        }
    }

    // M�todo para inicializar la UI
    void Start()
    {
        // Inicializar los toggles, desmarc�ndolos al inicio
        foreach (var toggle in checklistItems)
        {
            toggle.isOn = false;
        }
    }
}
