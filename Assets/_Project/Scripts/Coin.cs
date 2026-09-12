using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valor = 1;
    [SerializeField] private AudioClip pickupSound;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected)
            return;

        if (!collision.CompareTag("Player"))
            return;

        collected = true;

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        CoinManager.Instance.AddCoins(valor);

        Destroy(gameObject);
    }
}