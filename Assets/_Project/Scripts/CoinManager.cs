using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public event Action<int> OnCoinsChanged;

    public int Coins { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;

       
        OnCoinsChanged?.Invoke(Coins);
    }
}