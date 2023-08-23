using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarPedido : MonoBehaviour
{
    public string nombreDelPlato; // Nombre del plato asociado al botón
    public int costoDelPlato; // Costo del plato asociado al botón

    private bool seleccionado = false; // Indica si el plato ha sido seleccionado

    public void OnClick()
    {
        if (!seleccionado)
        {
            seleccionado = true;
            PedidoManager.AgregarPlato(nombreDelPlato, costoDelPlato); // Agrega el plato al pedido
        }
        else
        {
            seleccionado = false;
            PedidoManager.RemoverPlato(nombreDelPlato); // Remueve el plato del pedido
        }
    }
}
