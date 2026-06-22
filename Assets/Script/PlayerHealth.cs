using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;
    private Animator anim;
    private Rigidbody2D rb;

    public bool IsDead { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if (IsDead)
            return;

        currentHealth -= damage;

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            Die();
        }
    }

void Die()
    {
        IsDead = true;

        // Jalankan animasi mati
        anim.SetBool("IsDead", true);

        // Hentikan gerakan horizontal
        if (rb != null)
        {
            rb.linearVelocity =
                new Vector2(0f, rb.linearVelocity.y);
        }

        Debug.Log("Player Mati");
    }
}