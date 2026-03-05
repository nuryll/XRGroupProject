using UnityEngine;

public class Buttonpressed : MonoBehaviour
{
    public GameObject nextPortal;
    public AudioSource clickSound;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;

        if (nextPortal != null)
            nextPortal.SetActive(false);
    }

    public void PressButton()
    {
        transform.localPosition = startPos + new Vector3(0, -0.01f, 0);

        if (clickSound != null)
            clickSound.Play();

        if (nextPortal != null)
            nextPortal.SetActive(true);
    }
}