using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("DELIVERY SUCCESS!");
        }
    }
}