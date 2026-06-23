using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float invincibleTime = 1f;

    // UI Hati
    public HealthUI healthUI;

    // Panel Game Over
    public GameObject gameOverPanel;

    private int currentHealth;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool isInvincible;

    public bool IsDead { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsDead || isInvincible)
            return;

        currentHealth -= damage;

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }

        Debug.Log("Player HP: " + currentHealth);

        StartCoroutine(DamageFlash());

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invincibility());
        }
        else
        {
            Die();
        }
    }

    IEnumerator DamageFlash()
    {
        for (int i = 0; i < 3; i++)
        {
            sr.color = Color.red;

            yield return new WaitForSeconds(0.08f);

            sr.color = Color.white;

            yield return new WaitForSeconds(0.08f);
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
    }

    IEnumerator ShowGameOver()
    {
        // tunggu animasi mati selesai
        yield return new WaitForSecondsRealtime(1.0f);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    void Die()
    {
        if (IsDead)
            return;

        IsDead = true;

        rb.linearVelocity =
            new Vector2(0f, rb.linearVelocity.y);

        anim.SetFloat("Speed", 0);

        if (healthUI != null)
        {
            healthUI.UpdateHearts(0);
        }

        // Paksa langsung masuk animasi mati
        anim.Play("playerdeath", 0, 0f);

        StartCoroutine(ShowGameOver());

        Debug.Log("Player Mati");
    }
}