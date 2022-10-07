using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler_G : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip boing;
    [SerializeField] AudioClip fallIntoHole;
    [SerializeField] AudioClip teleport;
    [SerializeField] AudioClip gameFinished;
    [SerializeField] AudioClip wallBonk;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBoing()
    {
        audioSource.PlayOneShot(boing);
    }
    public void PlayFallIntoHole()
    {
        audioSource.PlayOneShot(fallIntoHole);
    }
    public void PlayTeleport()
    {
        audioSource.PlayOneShot(teleport);
    }
    public void PlayGameFinished()
    {
        audioSource.PlayOneShot(gameFinished);
    }
    public void PlayWallBonk()
    {
        audioSource.PlayOneShot(wallBonk);
    }
}
