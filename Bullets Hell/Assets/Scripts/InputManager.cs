using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterControler characterControler;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public PlayerInput GetInput()
    {
        return playerInput;
    }

    public Vector2 OnMove()
    {
        return playerInput.actions.FindAction("move").ReadValue<Vector2>();
    }

}
