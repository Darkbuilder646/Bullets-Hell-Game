using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Space, Header("Stats")]
    [SerializeField] private float attack = 1;
    [SerializeField] private float maxAttack = 10;
    [SerializeField] private bool fullPowerMod = false;
    [Space]
    [SerializeField] private int life = 3;
    [SerializeField] private int maxLife = 6;
    [SerializeField] private int bomb = 2;
    [SerializeField] private int maxBomb = 6;

    public float Attack { get => attack; }
    public float MaxAttack { get => maxAttack; }
    public bool FullPowerMod { get => fullPowerMod; }
    public int Life { get => life; }
    public int MaxLife { get => maxLife; }
    public int Bomb { get => bomb; }
    public int MaxBomb { get => maxBomb; }

    public void IncreaseAttack(float value)
    {
        if(fullPowerMod) { return; }
        attack += value;
        if(attack >= maxAttack) {fullPowerMod = true; }
    }

    public void ActiveFullPowerMod(bool powerMod)
    {
        fullPowerMod = powerMod;
        Debug.Log("Full Power Mod activate");
    }

    public void AddLife(int value = 1)
    {
        if(life == maxLife) { return; }
        life += value;
    }

    public void RemoveLife(int value = 1)
    {
        life -= value;
        if(life <= 0)
        {
            Debug.Log("End Game");
        }
    }

    public void AddBomb(int value = 1)
    {
        if(bomb == maxBomb) { return; }
        bomb += value;
    }

    public void RemoveBomb(int value = 1)
    {
        if(bomb == 0) { return; }
        bomb -= value;
    }
}
