using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartManager : MonoBehaviour
{
    public static RestartManager Instance;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            // Remove DontDestroyOnLoad to ensure full reset
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
        // Reset static variables or global data
        ResetStaticData();

        // Wait a frame
        yield return null;

        // Reload the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        // Wait another frame to ensure objects initialize
        yield return null;

        // XR Origin and all objects will start fresh as in scene setup
    }

    private void ResetStaticData()
    {
        // Reset any static variables or singletons
        // Example:
        // GameManager.score = 0;
        // GameManager.level = 1;
    }
}