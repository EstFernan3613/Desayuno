using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingrediente : MonoBehaviour
{
    private bool cocido = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " + other.tag);

        if (other.CompareTag("EstacionSarten") && !cocido)
        {
            // Iniciar el proceso de cocci�n en la estaci�n de sart�n
            StartCoroutine(CocinarIngrediente());
        }
    }

    private IEnumerator CocinarIngrediente()
    {
        cocido = true;
        // Implementa aqu� la l�gica para el proceso de cocci�n espec�fico del ingrediente
        // ...
        yield return null;
    }
}
