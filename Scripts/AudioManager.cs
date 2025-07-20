using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("_____________Audio Source____________")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("_____________SFX Source____________")]

    public AudioClip background;
    public AudioClip scorePlusEnemyCollison;
    public AudioClip scoreMinusEnemyCollison;
    public AudioClip healerCollison;
    public AudioClip losing;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
