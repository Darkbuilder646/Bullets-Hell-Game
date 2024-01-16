using UnityEngine;

public class OneUp : Item
{
    [Space, Header("Bomb Attributs")]
    [SerializeField] private int pointValue = 200;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            StatsOfPlayer.AddLife();

            GameManager.ScoreManager.AddScore(pointValue);
            Destroy(gameObject);
        }
    }
}
