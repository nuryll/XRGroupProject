using UnityEngine;
using System.Collections;

public class PortalPlayerTrigger : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject portal360video; // 360 video sphere
    [SerializeField] private GameObject skybox;       //Skybox sphere
    [SerializeField] private GameObject firsEnvironment;          // Floor to deactivate
    [SerializeField] private GameObject modelPortal;          // Final portal model to deactivate at the end

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // Prevent multiple triggers

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Deactivate the floor immediately
            if (firsEnvironment != null)
                firsEnvironment.SetActive(false);

            StartCoroutine(SwitchSequence());
        }
    }

    private IEnumerator SwitchSequence()
    {
        // Activate first video sphere
        if (portal360video != null)
            portal360video.SetActive(true);

        // Wait for 5 seconds while first video plays
        yield return new WaitForSeconds(5f);

        // Activate second video sphere
        if (skybox != null)
            skybox.SetActive(true);

        // Wait one frame to ensure XR camera renders the new sphere
        yield return null;

        // Deactivate first video sphere
        if (portal360video != null)
            portal360video.SetActive(false);

        // Finally deactivate the portal model after everything
        if (modelPortal != null)
            modelPortal.SetActive(false);
    }
}
