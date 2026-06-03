using UnityEngine;

public class HideTextAfterDelay : MonoBehaviour
{
    public float delay = 7f;

    void Start()
    {
        Invoke(nameof(Hide), delay);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}