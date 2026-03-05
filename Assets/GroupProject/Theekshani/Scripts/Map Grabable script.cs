using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MapGrabableScript : MonoBehaviour
{
    public GameObject portal1900; // drag PortalGate_Past_1900 here

    void Start()
    {
        if (portal1900 != null)
            portal1900.SetActive(false); // keep hidden at start
    }

    public void Open1900Portal()
    {
        if (portal1900 != null)
            portal1900.SetActive(true);
    }
}
