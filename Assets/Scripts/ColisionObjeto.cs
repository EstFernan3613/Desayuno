using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionObjeto : MonoBehaviour
{
    public float countdownTime = 5f;
    private bool isInteractable = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInteractable)
        {
            // Verificar si el objeto que colisionó es el "Player"
            if (other.CompareTag("Micro"))
            {
                isInteractable = false; // Bloquear el objeto

                // Realizar acciones cuando el objeto interactuable está disponible para interacción
                gameObject.SetActive(false);
                Invoke(nameof(ChangeAppearance), countdownTime);
            }
        }
    }

    private void ChangeAppearance()
    {
        // Cambiar propiedades del objeto, como el sprite o el color
        // Cambiar la etiqueta del objeto con gameObject.tag = "NuevaEtiqueta";

        isInteractable = true; // Desbloquear el objeto después de la interacción
    }

    public bool IsObjectInteractable()
    {
        return isInteractable;
    }
}