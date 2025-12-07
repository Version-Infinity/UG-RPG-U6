using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed = 5;

    // Counter to track FixedUpdate calls
    private int fixedUpdateCounter = 0;

    private void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Increment the FixedUpdate invocation counter
        fixedUpdateCounter++;

        // Only change moveSpeed on every 5th FixedUpdate
        if (fixedUpdateCounter % 5 == 0)
        {
            moveSpeed = Random.Range(-10, 10);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            GetComponent<Enemy>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            GetComponent<Enemy>().enabled = true;
        }

    }
}
