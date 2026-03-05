using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject nextPortal;

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

        if (nextPortal != null)
            nextPortal.SetActive(true);
    }
}