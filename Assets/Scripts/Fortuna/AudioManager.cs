using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip boing;
    [SerializeField] AudioClip hitDanger;
    [SerializeField] AudioClip collectedDrop;
    [SerializeField] AudioClip gameWon;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBoing()
    {
        audioSource.PlayOneShot(boing);
    }
    public void PlayHitDanger()
    {
        audioSource.PlayOneShot(hitDanger);
    }
    public void PlayCollectedDrop()
    {
        audioSource.PlayOneShot(collectedDrop);
    }
    public void PlayWin()
    {
        audioSource.PlayOneShot(gameWon);
    }
}
