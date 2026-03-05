using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MapHoverColor : MonoBehaviour
{
    public Renderer mapRenderer;

    private Color originalColor;

    void Start()
    {
        originalColor = mapRenderer.material.color;

        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.hoverEntered.AddListener(_ => HoverOn());
        interactable.hoverExited.AddListener(_ => HoverOff());
    }

    void HoverOn()
    {
        mapRenderer.material.color = new Color(1f, 0.9f, 0.6f);
    }

    void HoverOff()
    {
        mapRenderer.material.color = originalColor;
    }
}
