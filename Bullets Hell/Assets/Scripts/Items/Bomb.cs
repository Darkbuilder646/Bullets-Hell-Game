using UnityEngine;

public class Bomb : Item
{
    [Space, Header("Bomb Attributs")]
    [SerializeField] private int pointValue = 50;
    [SerializeField] private int bombToAdd = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            StatsOfPlayer.AddBomb(bombToAdd);

            GameManager.ScoreManager.AddScore(pointValue);
            Destroy(gameObject);
        }
    }
}
