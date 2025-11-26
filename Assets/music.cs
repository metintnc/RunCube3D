using UnityEngine;

public class music : MonoBehaviour
{
    public static music instance;
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Update()
    {
        
    }
}
