using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float movementSpeedOnFocus = 5f;
    [SerializeField] private bool isDead = false;

    private InputManager inputManager;
    private PlayerBulletsSpawner playerBulletsSpawner;
    private Vector2 direction = Vector2.zero;
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    public InputManager InputManager { get => inputManager; }
    public Vector2 Direction { get => direction; set => direction = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerBulletsSpawner = GetComponent<PlayerBulletsSpawner>();
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
        HandleShooting();
    }

    private void ComputeMovement()
    {
        direction = inputManager.OnMove();
        float currentSpeed = (inputManager.OnFocus() == 1) ? movementSpeedOnFocus : movementSpeed;
        velocity = currentSpeed * Time.fixedDeltaTime * direction;
        rb2D.MovePosition(rb2D.position + velocity);
    }

    private void HandleShooting()
{
    if (inputManager.OnFire() == 1)
    {
        playerBulletsSpawner.Shoot();
    }
}

    //Todo : Invulnerability later

}
