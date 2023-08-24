using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropdownManager : MonoBehaviour
{
    public SeleccionarPedido seleccionarPedido; // Referencia al script SeleccionarPedido
    public Dropdown dropdown; // Referencia al Dropdown en el Inspector

    private void Start()
    {
        dropdown.ClearOptions(); // Borra las opciones por defecto

        // Crea una lista de nombres de adiciones
        var opciones = new List<string>();
        foreach (Adicion adicion in seleccionarPedido.adicionesDisponibles)
        {
            opciones.Add(adicion.nombre);
        }

        // Agrega las opciones a la lista desplegable
        dropdown.AddOptions(opciones);
    }

    public void OnDropdownValueChanged(int index)
    {
        var adicionSeleccionada = seleccionarPedido.adicionesDisponibles[index];
        seleccionarPedido.AgregarAdicion(adicionSeleccionada.nombre, adicionSeleccionada.costo);
    }
}
