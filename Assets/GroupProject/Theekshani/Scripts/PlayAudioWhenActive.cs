using UnityEngine;

public class PlayAudioWhenActive : MonoBehaviour
{
    public AudioSource audioSource;

    void OnEnable()
    {
        audioSource.Play();
    }
}