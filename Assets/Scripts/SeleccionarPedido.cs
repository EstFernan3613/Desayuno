using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarPedido : MonoBehaviour
{
    public string nombreDelPlato; 
    public int costoDelPlato; 

    public List<Adicion> adicionesDisponibles = new List<Adicion>(); 

    private List<Adicion> adicionesSeleccionadas = new List<Adicion>(); 

    private bool seleccionado = false; 

    private PedidoManager instanciaPedidoManager; 

    private void Start()
    {
        instanciaPedidoManager = FindObjectOfType<PedidoManager>();
    }

    public void OnClick()
    {
        if (!seleccionado)
        {
            seleccionado = true;
            PedidoManager.AgregarPlato(nombreDelPlato, costoDelPlato); 

            foreach (Adicion adicion in adicionesSeleccionadas)
            {
                instanciaPedidoManager.AgregarAdicion(adicion.nombre, adicion.costo);
            }
        }
        else
        {
            seleccionado = false;
            PedidoManager.RemoverPlato(nombreDelPlato); 

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
