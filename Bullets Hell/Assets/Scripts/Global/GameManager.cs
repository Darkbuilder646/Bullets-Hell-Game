using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static InputManager InputManager { get; private set; }
    public static RespawnManager RespawnManager { get; private set; }
    private static GameManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        InputManager = GetComponent<InputManager>();
        RespawnManager = GetComponent<RespawnManager>();
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }
}
