using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    { 
      if (other.CompareTag("Player")) { 
           
       Destroy(gameObject); } }



     
        void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
