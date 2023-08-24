using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacionEmplatado : MonoBehaviour
{
    public string tagPan = "Pan";
    public string[] tagsIngredientesListos;
    public GameObject Nuevo;
    public Image imagenPedidoListo; // Asigna en el Inspector el objeto con la componente Image para la imagen del plato
    public Sprite spritePedidoCompleto; // Asigna en el Inspector el sprite del plato completo

    private bool panRecibido = false;
    private List<string> ingredientesAgregados = new List<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagPan) && !panRecibido)
        {
            panRecibido = true;
            VerificarPedidoListo();
        }
        else if (ArrayContainsTag(tagsIngredientesListos, other.tag))
        {
            ingredientesAgregados.Add(other.tag);
            VerificarPedidoListo();
        }
    }

    private bool ArrayContainsTag(string[] array, string tag)
    {
        foreach (string itemTag in array)
        {
            if (itemTag == tag)
            {
                return true;
            }
        }
        return false;
    }

    private void VerificarPedidoListo()
    {
        if (panRecibido && TodosIngredientesAgregados())
        {
            RealizarPedido();
        }
    }

    private bool TodosIngredientesAgregados()
    {
        foreach (string tag in tagsIngredientesListos)
        {
            if (!ingredientesAgregados.Contains(tag))
            {
                return false;
            }
        }
        return true;
    }

    private void RealizarPedido()
    {
        // Aquí puedes realizar la acción de completar el pedido y cambiar el sprite de la imagen del plato
        if (imagenPedidoListo != null && spritePedidoCompleto != null)
        {
            imagenPedidoListo.sprite = spritePedidoCompleto;
            Nuevo.tag = "HuevosConTocino";
        }
    }
}
