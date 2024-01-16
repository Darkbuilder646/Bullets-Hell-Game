using UnityEngine;

public class FullPower : Item
{
    [Space, Header("Full Power Attributs")]
    [SerializeField] private int pointValue = 50;
    [SerializeField] private bool activeFullPower = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            StatsOfPlayer.ActiveFullPowerMod(activeFullPower);

            GameManager.ScoreManager.AddScore(pointValue);
            Destroy(gameObject);
        }
    }
}
