using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        CoinManager.Instance.OnCoinsChanged += UpdateCoinText;
    }

    private void OnDisable()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.OnCoinsChanged -= UpdateCoinText;
        }
    }

    private void Start()
    {
        UpdateCoinText(CoinManager.Instance.Coins);
    }

    private void UpdateCoinText(int coins)
    {
        coinText.text = "Coins: " + coins;
    }
}