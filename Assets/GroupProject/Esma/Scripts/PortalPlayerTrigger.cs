using UnityEngine;
using System.Collections;

public class PortalPlayerTrigger : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject targetPortal360video; // First 360 video sphere
    [SerializeField] private GameObject future360video;       // Second 360 video sphere
    [SerializeField] private GameObject targetFloor;          // Floor to deactivate

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // Prevent multiple triggers

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Deactivate the floor immediately
            if (targetFloor != null)
                targetFloor.SetActive(false);

            StartCoroutine(SwitchSequence());
        }
    }

    private IEnumerator SwitchSequence()
    {
        // Activate first video sphere
        if (targetPortal360video != null)
            targetPortal360video.SetActive(true);

        // Wait for 5 seconds while first video plays
        yield return new WaitForSeconds(5f);

        // Activate second video sphere FIRST (important: prevents white flash)
        if (future360video != null)
            future360video.SetActive(true);

        // Wait one frame so the camera renders the new sphere
        yield return null;

        // Now safely deactivate the first sphere (no flash possible)
        if (targetPortal360video != null)
            targetPortal360video.SetActive(false);
    }
}
