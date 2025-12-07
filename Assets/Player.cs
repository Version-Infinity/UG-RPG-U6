using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rb;
    public string PlayerName = "Baller";
    public int Age = 45;
    public float MoveSpeed = 4.35f;
    public bool IsAlive = true;
    [SerializeField] private int score = 0;

    public int currentHp = 100;

    void Update()
    {
        Rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Rb.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp -= collision.gameObject.GetComponent<Damage>().GetDamage();
            if (currentHp <= 0)
            {
                IsAlive = false;
                Debug.Log($"{PlayerName} has died.");
            }
        }
    }

}