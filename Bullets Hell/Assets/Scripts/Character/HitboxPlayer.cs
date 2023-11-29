using UnityEngine;

public class HitboxPlayer : MonoBehaviour
{
    private CharacterControler characterControler;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        characterControler = GetComponentInParent<CharacterControler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        spriteRenderer.enabled = characterControler.InputManager.OnFocus() == 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            characterControler.IsDead = true;
            GameManager.RespawnManager.RespawnPlayer(characterControler);
        }
    }
}
