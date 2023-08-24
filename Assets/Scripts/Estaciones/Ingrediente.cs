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
            
            StartCoroutine(CocinarIngrediente());
        }
    }

    private IEnumerator CocinarIngrediente()
    {
        cocido = true;
       
        yield return null;
    }
}
