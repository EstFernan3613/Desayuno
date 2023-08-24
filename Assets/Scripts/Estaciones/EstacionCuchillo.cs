using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EstacionCuchillo : MonoBehaviour
{
    public float tiempoCorte = 5.0f;
    public Color colorCortado;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tomate") || other.CompareTag("Lechuga"))
        {
            StartCoroutine(CortarIngrediente(other.gameObject));
        }
    }

    private IEnumerator CortarIngrediente(GameObject ingrediente)
    {
        Image ingredienteImage = ingrediente.GetComponent<Image>();

        if (ingredienteImage != null)
        {
            Color colorOriginal = ingredienteImage.color;
            ingredienteImage.color = colorOriginal;

            yield return new WaitForSeconds(5);

            // Cambiar la etiqueta del ingrediente cortado
            if (ingrediente.CompareTag("Tomate"))
            {
                ingrediente.tag = "TomateListo";
            }
            else if (ingrediente.CompareTag("Lechuga"))
            {
                ingrediente.tag = "LechugaListo";
            }

            // Realizar otras acciones con el ingrediente cortado

            ingredienteImage.color = colorCortado;
        }
    }
}
