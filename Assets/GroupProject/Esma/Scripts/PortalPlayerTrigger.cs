using UnityEngine;

public class PortalPlayerTrigger : MonoBehaviour
{
    [Header("Objects to activate")]
    [SerializeField] private GameObject targetSphere; // The sphere to activate
    [SerializeField] private GameObject targetFloor;  // The floor to activate

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // Prevent multiple activations

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Activate the sphere
            if (targetSphere != null)
                targetSphere.SetActive(true);

            // InActivate the floor
            if (targetFloor != null)
                targetFloor.SetActive(false);
        }
    }
}
