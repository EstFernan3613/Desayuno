using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rTransform;
    private Vector2 initialPosition;

    private AudioSource audioSource; // Agrega una referencia al AudioSource

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
        initialPosition = rTransform.anchoredPosition;

        // Encuentra el componente AudioSource en el GameObject o en un objeto hijo
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Reproduce el sonido cuando se agarra el objeto
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Realizar acciones necesarias al arrastrar el objeto
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // El objeto se soltó en otro lugar, regresa a la posición inicial
        DevolverABarra();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rTransform.anchoredPosition += eventData.delta;
    }

    public void DevolverABarra()
    {
        rTransform.anchoredPosition = initialPosition;
    }
}
