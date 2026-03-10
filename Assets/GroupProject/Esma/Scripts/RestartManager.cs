using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartManager : MonoBehaviour
{
    public static RestartManager Instance;

    private void Awake()
    {
        // Singleton pattern so it can be called from anywhere
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional if you want it to persist
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Public method to restart the scene
    public void RestartScene()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        // Wait a frame to allow any pre-restart tasks
        yield return null;

        // Reload the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        // Wait another frame so the scene loads
        yield return null;

        // Reset XR Origin after scene loads
        ResetXROrigin();
    }

    private void ResetXROrigin()
    {
        GameObject xrOrigin = GameObject.FindWithTag("Player");
        if (xrOrigin != null)
        {
            xrOrigin.transform.position = Vector3.zero;
            xrOrigin.transform.rotation = Quaternion.identity;

            // Reset child objects (controllers) if needed
            foreach (Transform child in xrOrigin.transform)
            {
                child.localPosition = Vector3.zero;
                child.localRotation = Quaternion.identity;
            }
        }
    }
}
