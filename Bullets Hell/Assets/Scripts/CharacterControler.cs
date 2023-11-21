using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    private InputManager inputManager;
    private Vector2 direction = Vector2.zero;
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    public Vector2 Direction { get => direction; set => direction = value; }


    private void Awake()
    {
        inputManager = InputManager.GetInstance();

        rb2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        direction = inputManager.OnMove();
        velocity = movementSpeed * Time.fixedDeltaTime * direction;
        transform.position += (Vector3)velocity;
    }

}
