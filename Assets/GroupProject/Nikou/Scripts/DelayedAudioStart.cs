using UnityEngine;
using System.Collections;

public class DelayedAudioStart : MonoBehaviour
{
    public AudioSource welcomeAudio;
    public float delay = 6f;

    void Start()
    {
        StartCoroutine(PlayAudioAfterDelay());
    }

    IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (welcomeAudio != null)
        {
            welcomeAudio.Play();
        }
    }
}