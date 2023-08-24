using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PedidoManager : MonoBehaviour
{
    private static PedidoManager instancia;
    public Text resumenTextEnOtroObjeto; 

    private string pedidoResumen = "";
    private int totalPedido = 0;

    private List<Adicion> adicionesEnPedido = new List<Adicion>(); 

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void AgregarPlato(string nombrePlato, int costoPlato)
    {
        instancia.pedidoResumen += nombrePlato + "\n";
        instancia.totalPedido += costoPlato;
        instancia.ActualizarResumen();
    }

    public void AgregarAdicion(string nombreAdicion, int costoAdicion)
    {
        Adicion nuevaAdicion = new Adicion(nombreAdicion, costoAdicion);
        adicionesEnPedido.Add(nuevaAdicion);
        instancia.ActualizarResumen();
    }

    public static void RemoverPlato(string nombrePlato)
    {
        instancia.pedidoResumen = instancia.pedidoResumen.Replace(nombrePlato + "\n", "");
        instancia.totalPedido -= ObtenerCostoPlato(nombrePlato);
        instancia.ActualizarResumen();
    }

    public void RemoverAdicion(string nombreAdicion)
    {
        Adicion adicionARemover = adicionesEnPedido.Find(adicion => adicion.nombre == nombreAdicion);
        if (adicionARemover != null)
        {
            adicionesEnPedido.Remove(adicionARemover);
            instancia.ActualizarResumen();
        }
    }

    private static int ObtenerCostoPlato(string nombrePlato)
    {
        switch (nombrePlato)
        {
            case "Huevos con Tocino":
                return 7000;
            case "Sandwich de Peperoni":
                return 12000;
            case "Cafe":
                return 4500;
            default:
                return 0;
        }
    }

    private void ActualizarResumen()
    {
        string resumenAdiciones = "";
        int totalAdiciones = 0;

        foreach (Adicion adicion in adicionesEnPedido)
        {
            resumenAdiciones += adicion.nombre + "\n";
            totalAdiciones += adicion.costo;
        }

        resumenTextEnOtroObjeto.text = "Resumen del Pedido:\n" + pedidoResumen + resumenAdiciones + "\nTotal: $" + (totalPedido + totalAdiciones);
    }
}

[System.Serializable]
public class Adicion
{
    public string nombre;
    public int costo;

    public Adicion(string nombre, int costo)
    {
        this.nombre = nombre;
        this.costo = costo;
    }
}
