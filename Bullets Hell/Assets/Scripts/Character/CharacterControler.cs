using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private bool isDead = false;

    private InputManager inputManager;
    private Vector2 direction = Vector2.zero;
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    public Vector2 Direction { get => direction; set => direction = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        inputManager = GameManager.InputManager;
    }

    private void FixedUpdate()
    {
        if (isDead) 
        {
            gameObject.SetActive(false);
            return; 
        }
        ComputeMovement();
    }

    private void ComputeMovement()
    {
        direction = inputManager.OnMove();
        velocity = movementSpeed * Time.fixedDeltaTime * direction;
        rb2D.MovePosition(rb2D.position + velocity);
    }

}
