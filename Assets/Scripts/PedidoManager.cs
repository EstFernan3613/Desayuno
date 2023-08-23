using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedidoManager : MonoBehaviour
{
    public Text resumenText; // Referencia al objeto de texto donde se mostrará el resumen del pedido
    private static PedidoManager instancia;

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    private string pedidoResumen = "";
    private int totalPedido = 0;

    public static void AgregarPlato(string nombrePlato, int costoPlato)
    {
        instancia.pedidoResumen += nombrePlato + "\n";
        instancia.totalPedido += costoPlato;
        instancia.ActualizarResumen();
    }

    public static void RemoverPlato(string nombrePlato)
    {
        instancia.pedidoResumen = instancia.pedidoResumen.Replace(nombrePlato + "\n", "");
        instancia.totalPedido -= ObtenerCostoPlato(nombrePlato);
        instancia.ActualizarResumen();
    }

    private static int ObtenerCostoPlato(string nombrePlato)
    {
        switch (nombrePlato)
        {
            case "Plato A":
                return 10;
            case "Plato B":
                return 15;
            case "Plato C":
                return 20;
            default:
                return 0;
        }
    }

    private void ActualizarResumen()
    {
        resumenText.text = "Resumen del Pedido:\n" + pedidoResumen + "\nTotal: $" + totalPedido;
    }
}
