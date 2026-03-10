using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartManager : MonoBehaviour
{
    public static RestartManager Instance;

    private void Awake()
    {
        // Singleton so it can be called from anywhere
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persists across scene reloads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to restart the scene
    public void RestartScene()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        // Wait one frame
        yield return null;

        // Reload active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        // Wait another frame to allow objects to initialize
        yield return null;

        // Reset XR Origin position & rotation
        ResetXROrigin();
    }

    private void ResetXROrigin()
    {
        GameObject xrOrigin = GameObject.FindWithTag("Player");
        if (xrOrigin != null)
        {
            xrOrigin.transform.position = Vector3.zero;
            xrOrigin.transform.rotation = Quaternion.identity;

            // Reset child objects (controllers)
            foreach (Transform child in xrOrigin.transform)
            {
                child.localPosition = Vector3.zero;
                child.localRotation = Quaternion.identity;
            }
        }
    }

    // Optional: reset static variables or singletons here
    private void ResetStaticData()
    {
        // Example:
        // GameManager.score = 0;
        // GameManager.level = 1;
    }
}
