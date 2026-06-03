using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryZone : MonoBehaviour
{
    public string nextSceneName;
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

            Invoke(nameof(LoadNextScene), 1.5f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}