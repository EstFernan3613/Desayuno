using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EstacionCafetera : MonoBehaviour
{
    public float tiempoPreparacion = 5.0f;
    public Sprite spriteCafePreparado;

    private bool cafePreparado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cafe") && !cafePreparado)
        {
            StartCoroutine(PrepararCafe(other.gameObject));
        }
    }

    private IEnumerator PrepararCafe(GameObject cafe)
    {
        yield return new WaitForSeconds(5);

        cafePreparado = true;

        
        Image cafeImage = cafe.GetComponent<Image>();
        cafeImage.sprite = spriteCafePreparado;
        cafe.tag = "CafeListo";
        
    }

}
