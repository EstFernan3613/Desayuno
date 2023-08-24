using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EstacionMicro : MonoBehaviour
{
    public float tiempoMicroondas = 5.0f;
    public Color colorCaliente;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Queso"))
        {
            StartCoroutine(CalentarQueso(other.gameObject));
        }
    }

    private IEnumerator CalentarQueso(GameObject queso)
    {
        Image quesoRenderer = queso.GetComponent<Image>();

        if (quesoRenderer != null)
        {
            Color colorOriginal = quesoRenderer.color;
            quesoRenderer.color = colorOriginal;

            yield return new WaitForSeconds(5);

            

            queso.tag = "QuesoListo";

            quesoRenderer.color = colorCaliente;
        }

    }
}

