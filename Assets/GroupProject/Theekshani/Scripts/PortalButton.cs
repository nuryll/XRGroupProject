using UnityEngine;

public class PortalButton : MonoBehaviour
{
    public GameObject nextPortal;
    public AudioSource clickSound;

    private Vector3 startPos;
    private bool isPressed = false;

    void Start()
    {
        startPos = transform.localPosition;

        if (nextPortal != null)
        {
            nextPortal.SetActive(false);
        }
    }

    public void PressButton()
    {
        if (isPressed) return;
        isPressed = true;

        transform.localPosition = startPos + new Vector3(0f, -0.01f, 0f);

        if (clickSound != null)
        {
            clickSound.Play();
        }

        if (nextPortal != null)
        {
            nextPortal.SetActive(true);
        }

        Debug.Log("Portal button pressed. Next portal opened.");
    }
}