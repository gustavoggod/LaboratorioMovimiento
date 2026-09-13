

using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        if (CoinManager.Instance == null)
        {
            Debug.LogError("No existe un CoinManager en la escena.");
            return;
        }

        // Mostrar valor inicial
        UpdateCoinText(CoinManager.Instance.Coins);

        // Suscribirse al evento
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
