using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarPedido : MonoBehaviour
{
    public string nombreDelPlato; // Nombre del plato asociado al botón
    public int costoDelPlato; // Costo del plato asociado al botón

    public List<Adicion> adicionesDisponibles = new List<Adicion>(); // Lista de adiciones

    private List<Adicion> adicionesSeleccionadas = new List<Adicion>(); // Lista de adiciones seleccionadas

    private bool seleccionado = false; // Indica si el plato ha sido seleccionado

    private PedidoManager instanciaPedidoManager; // Referencia a la instancia de PedidoManager

    private void Start()
    {
        instanciaPedidoManager = FindObjectOfType<PedidoManager>();
    }

    public void OnClick()
    {
        if (!seleccionado)
        {
            seleccionado = true;
            PedidoManager.AgregarPlato(nombreDelPlato, costoDelPlato); // Agrega el plato al pedido

            foreach (Adicion adicion in adicionesSeleccionadas)
            {
                instanciaPedidoManager.AgregarAdicion(adicion.nombre, adicion.costo);
            }
        }
        else
        {
            seleccionado = false;
            PedidoManager.RemoverPlato(nombreDelPlato); // Remueve el plato del pedido

            foreach (Adicion adicion in adicionesSeleccionadas)
            {
                instanciaPedidoManager.RemoverAdicion(adicion.nombre);
            }

            adicionesSeleccionadas.Clear();
        }
    }

    public void AgregarAdicion(string nombreAdicion, int costoAdicion)
    {
        if (seleccionado)
        {
            Adicion nuevaAdicion = new Adicion(nombreAdicion, costoAdicion);
            adicionesSeleccionadas.Add(nuevaAdicion);
        }
    }
}
