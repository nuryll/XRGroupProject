using UnityEngine;

public class EraManager : MonoBehaviour
{
    public GameObject sphere1900;
    public GameObject sphere1950;

    public GameObject map1900;
    public GameObject object1950;

    public GameObject portal1900to1950;
    public GameObject portal1950toNext;

    void Start()
    {
        // Start in 1900
        GoTo1900();
    }

    public void GoTo1900()
    {
        sphere1900.SetActive(true);
        map1900.SetActive(true);

        sphere1950.SetActive(false);
        object1950.SetActive(false);

        portal1900to1950.SetActive(false);
        portal1950toNext.SetActive(false);
    }

    public void GoTo1950()
    {
        sphere1900.SetActive(false);
        map1900.SetActive(false);
        portal1900to1950.SetActive(false);

        sphere1950.SetActive(true);
        object1950.SetActive(true);

        portal1950toNext.SetActive(false);
    }
}
