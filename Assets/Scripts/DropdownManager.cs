using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropdownManager : MonoBehaviour
{
    public SeleccionarPedido seleccionarPedido; 
    public Dropdown dropdown; 

    private void Start()
    {
        dropdown.ClearOptions(); 

        
        var opciones = new List<string>();
        foreach (Adicion adicion in seleccionarPedido.adicionesDisponibles)
        {
            opciones.Add(adicion.nombre);
        }

        
        dropdown.AddOptions(opciones);
    }

    public void OnDropdownValueChanged(int index)
    {
        var adicionSeleccionada = seleccionarPedido.adicionesDisponibles[index];
        seleccionarPedido.AgregarAdicion(adicionSeleccionada.nombre, adicionSeleccionada.costo);
    }
}
