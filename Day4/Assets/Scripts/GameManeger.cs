using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance;
    GameObject wheel;
    private void Awake()
    {
        if (wheel != null) return;
        wheel = GameObject.Find("Wheel");
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Home")
        {
            wheel.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wheel.SetActive(true);
                SceneManager.LoadScene("Home");
                Destroy(gameObject);
            }
        }
    }
}
