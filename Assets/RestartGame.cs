using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public CanvasGroup fadeblackscreen;
    public float fadespeed = 2f;

    private bool isfading = false;
    private bool death = false;

    void Update()
    {
        if (isfading && fadeblackscreen.alpha < 1)
        {
            fadeblackscreen.alpha += fadespeed * Time.deltaTime;
        }
    }
    public void FadeAndRestart()
    {
        isfading = true;
        Invoke("RestartScene", 1f);
        if (olumsayac.Instance != null)
        {
            olumsayac.Instance.AddDeath();
        }
    }

    void RestartScene()
    {
        if (olumsayac.Instance != null)
        {
            olumsayac.Instance.hasAdded = false; 
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
