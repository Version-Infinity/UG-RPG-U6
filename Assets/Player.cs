using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rb;
    void Update()
    {
        Rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Rb.linearVelocityY);
    }
}
