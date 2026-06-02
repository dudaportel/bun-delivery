using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public GameObject deliveryMessage;

    private bool delivered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (delivered)
            return;

        if (other.CompareTag("Player"))
        {
            delivered = true;

            if (deliveryMessage != null)
                deliveryMessage.SetActive(true);

            Debug.Log("DELIVERY SUCCESS!");
        }
    }
}