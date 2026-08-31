using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    { //Comprobamos si el objeto que tocó la moneda es el jugador.
      if (other.CompareTag("Player")) { 
            // La moneda desaparece al ser recogida.
       Destroy(gameObject); } }



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
