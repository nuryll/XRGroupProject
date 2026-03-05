using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonHoverColor : MonoBehaviour
{
    public Renderer buttonRenderer;

    Color originalColor;

    void Start()
    {
        originalColor = buttonRenderer.material.color;

        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.hoverEntered.AddListener(_ => HoverOn());
        interactable.hoverExited.AddListener(_ => HoverOff());
    }

    void HoverOn()
    {
        buttonRenderer.material.color = new Color(0.4f, 0.2f, 0.1f);
    }

    void HoverOff()
    {
        buttonRenderer.material.color = originalColor;
    }
}
