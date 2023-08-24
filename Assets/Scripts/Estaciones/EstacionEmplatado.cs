using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacionEmplatado : MonoBehaviour
{
    public string[] tagsIngredientesListos;
    public GameObject Nuevo;
    public Image imagenPedidoListo;
    public Sprite spritePedidoCompleto;

    private List<string> ingredientesAgregados = new List<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ArrayContainsTag(tagsIngredientesListos, other.tag))
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
        if (TodosIngredientesAgregados())
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
        if (imagenPedidoListo != null && spritePedidoCompleto != null)
        {
            imagenPedidoListo.sprite = spritePedidoCompleto;
            Nuevo.tag = "HuevosConTocino";
        }
    }
}
