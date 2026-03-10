using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonPortal : MonoBehaviour
{
    [Header("Portal")]
    public GameObject portalBehindPlayer;

    [Header("Button Press Feedback")]
    public Vector3 pressOffset = new Vector3(0, -0.01f, 0);
    private Vector3 startPos;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Start()
    {
        startPos = transform.localPosition;

        if (portalBehindPlayer != null)
            portalBehindPlayer.SetActive(false);

        // Get the interactable component
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            // Add listener for activation (press/poke)
            interactable.activated.AddListener(OnButtonPressed);
        }
        else
        {
            Debug.LogWarning("No XRBaseInteractable found on the button!");
        }
    }

    private void OnButtonPressed(ActivateEventArgs args)
    {
        // Move button slightly to simulate press
        transform.localPosition = startPos + pressOffset;

        // Activate the portal
        if (portalBehindPlayer != null)
            portalBehindPlayer.SetActive(true);

        // Optional: play sound here
        // AudioSource.PlayClipAtPoint(yourAudioClip, transform.position);
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.activated.RemoveListener(OnButtonPressed);
        }
    }
}