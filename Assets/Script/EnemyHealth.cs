using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
public int maxHealth = 3;

private int currentHealth;
private SpriteRenderer sr;

void Start()
{
    currentHealth = maxHealth;
    sr = GetComponent<SpriteRenderer>();
}

public void TakeDamage(int damage)
{
    currentHealth -= damage;

    StartCoroutine(FlashRed());

    Debug.Log(
        gameObject.name +
        " terkena damage " +
        damage +
        " | HP: " +
        currentHealth);

    if (currentHealth <= 0)
    {
        Die();
    }
}

IEnumerator FlashRed()
{
    sr.color = Color.red;

    yield return new WaitForSeconds(0.15f);

    sr.color = Color.white;
}

void Die()
{
    Debug.Log(
        gameObject.name +
        " mati");

    Destroy(gameObject);
}

}
