using UnityEngine;

public class BoxFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float tiltAmount = 25f;

    void Update()
    {
        transform.position =
            player.position + offset;

        float horizontal =
            Input.GetAxisRaw("Horizontal");

        float rotation =
            -horizontal * tiltAmount;

        transform.rotation =
            Quaternion.Euler(0, 0, rotation);
    }
}