using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReiniciarIngredientesButton : MonoBehaviour
{
    public List<GameObject> ingredientes; // Lista de ingredientes a reiniciar

    private void Start()
    {
        // Aseg�rate de asignar los ingredientes en el Inspector del bot�n
    }

    public void ReiniciarIngredientes()
    {
        foreach (GameObject ingrediente in ingredientes)
        {
            ResetearIngrediente(ingrediente);
        }
    }

    private void ResetearIngrediente(GameObject ingrediente)
    {
        Image ingredienteImage = ingrediente.GetComponent<Image>();

        if (ingredienteImage != null)
        {
            ingredienteImage.color = Color.white; // Cambia el color a blanco (color original)
            // Aqu� puedes realizar otras acciones de reinicio si es necesario
        }
    }
}
