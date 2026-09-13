

using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        if (CoinManager.Instance == null)
        {
            Debug.LogError("Agregar CoinManager");
            return;
        }


        UpdateCoinText(CoinManager.Instance.Coins);


        CoinManager.Instance.OnCoinsChanged += UpdateCoinText;
    }

    private void OnDisable()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.OnCoinsChanged -= UpdateCoinText;
        }
    }

    private void UpdateCoinText(int coins)
    {
        coinText.text = "Coins: " + coins;
    }
}
