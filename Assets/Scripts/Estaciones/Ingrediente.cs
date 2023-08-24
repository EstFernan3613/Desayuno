using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingrediente : MonoBehaviour
{
    private bool cocido = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.tag);

        if (other.CompareTag("EstacionSarten") && !cocido)
        {
            // Iniciar el proceso de cocción en la estación de sartén
            StartCoroutine(CocinarIngrediente());
        }
    }

    private IEnumerator CocinarIngrediente()
    {
        cocido = true;
        // Implementa aquí la lógica para el proceso de cocción específico del ingrediente
        // ...
        yield return null;
    }
}
