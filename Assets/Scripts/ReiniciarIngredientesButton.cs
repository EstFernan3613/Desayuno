using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReiniciarIngredientesButton : MonoBehaviour
{
    public List<GameObject> ingredientes; 
    public GameObject objetoEmplatadoNO; 
    public Sprite spritePlato; 

    private void Start()
    {
        
    }

    public void ReiniciarIngredientes()
    {
        foreach (GameObject ingrediente in ingredientes)
        {
            ResetearIngrediente(ingrediente);
        }

        if (objetoEmplatadoNO != null)
        {
            ResetearObjeto(objetoEmplatadoNO);
        }
    }

    private void ResetearIngrediente(GameObject ingrediente)
    {
        Image ingredienteImage = ingrediente.GetComponent<Image>();

        if (ingredienteImage != null)
        {
            ingredienteImage.color = Color.white;
            
        }
    }

    private void ResetearObjeto(GameObject objeto)
    {
        Image objetoImage = objeto.GetComponent<Image>();

        if (objetoImage != null)
        {
            objetoImage.sprite = spritePlato; 
            
        }
    }
}
