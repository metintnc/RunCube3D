using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class olumsayac : MonoBehaviour
{
    public static olumsayac Instance;
    public int count = 0;
    public TextMeshPro TextMeshPro;
    public bool hasAdded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       TextMeshPro = GameObject.FindWithTag("SayacText")?.GetComponent<TextMeshPro>();

        UpdateDeathText();
    }

    public void AddDeath()
    {
        if (hasAdded) return;
        count++;
        UpdateDeathText();
        hasAdded = true;
    }

    void UpdateDeathText()
    {
        if (TextMeshPro != null)
        {
            TextMeshPro.text = "Ölüm: " + count;
        }
    }
}
