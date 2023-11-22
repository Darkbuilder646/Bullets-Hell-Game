using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterControler characterControler;

    public PlayerInput GetInput()
    {
        return playerInput;
    }

    #region Methods
    public Vector2 OnMove()
    {
        return playerInput.actions.FindAction("move").ReadValue<Vector2>();
    }

    public float OnFocus() //? 0 => False / 1 => True
    {
        return playerInput.actions.FindAction("Focus").ReadValue<float>();
    }

    public float OnFire() //? 0 => False / 1 => True
    {
        return playerInput.actions.FindAction("Fire").ReadValue<float>();
    }
    #endregion
}
