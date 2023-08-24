using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EstacionSarten : MonoBehaviour
{
    public float tiempoCoccion = 5.0f;
    public Color colorCocido;

    private bool huevoCocido = false;
    private bool tocinoCocido = false;
    private bool peperoniCocido = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Huevo") && !huevoCocido)
        {
            StartCoroutine(CocinarHuevo(other.gameObject));
        }
        else if (other.CompareTag("Tocino") && !tocinoCocido)
        {
            StartCoroutine(CocinarTocino(other.gameObject));
        }
        else if (other.CompareTag("Peperoni") && !peperoniCocido)
        {
            StartCoroutine(CocinarPeperoni(other.gameObject));
        }
    }

    private IEnumerator CocinarHuevo(GameObject huevo)
    {
        huevoCocido = true;
        yield return new WaitForSeconds(5);
        Image huevoImage = huevo.GetComponent<Image>();
        huevoImage.color = colorCocido;


        
        huevo.tag = "HuevoListo";
    }

    private IEnumerator CocinarTocino(GameObject tocino)
    {
        tocinoCocido = true;
        yield return new WaitForSeconds(5);
        Image tocinoImage = tocino.GetComponent<Image>();
        tocinoImage.color = colorCocido;


        
        tocino.tag = "TocinoListo";
    }

    private IEnumerator CocinarPeperoni(GameObject peperoni)
    {
        peperoniCocido = true;
        yield return new WaitForSeconds(5);
        Image peperoniImage = peperoni.GetComponent<Image>();
        peperoniImage.color = colorCocido;


        
        peperoni.tag = "PeperoniListo";
    }
}