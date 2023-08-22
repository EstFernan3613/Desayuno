using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionObjeto : MonoBehaviour
{
    public float countdownTime = 5f;
    private bool isInteractable = true; // Variable de estado para controlar la interaccion
    private bool collided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collided && isInteractable)
        {
            collided = true;
            isInteractable = false; // Bloquear el objeto
            gameObject.SetActive(false);
            Invoke(nameof(ChangeAppearance), countdownTime);
        }
    }

    private void ChangeAppearance()
    {
        // Cambiar propiedades del objeto, como el sprite o el color
        // Cambiar la etiqueta del objeto con gameObject.tag = "NuevaEtiqueta";

        isInteractable = true; // Desbloquear el objeto después de la interaccion
    }

    // Método para verificar si el objeto esta actualmente bloqueado
    public bool IsObjectInteractable()
    {
        return isInteractable;
    }
}