using UnityEngine;

public class HitboxPlayer : MonoBehaviour
{
    private CharacterControler characterControler;

    private void Awake()
    {
        characterControler = GetComponentInParent<CharacterControler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            characterControler.IsDead = true;
            GameManager.RespawnManager.RespawnPlayer(characterControler);
        }
    }
}
