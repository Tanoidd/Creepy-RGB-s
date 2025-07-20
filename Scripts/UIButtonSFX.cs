using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickDownSound;
    public AudioClip clickUpSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickDownSound != null && audioSource != null)
            audioSource.PlayOneShot(clickDownSound);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickUpSound != null && audioSource != null)
            audioSource.PlayOneShot(clickUpSound);
    }
}
