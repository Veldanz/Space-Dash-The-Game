using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyRec : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public HB healthBar;

    void Start()
    {
        currentHealth = maxHealth; //Make the currentHealth has a value the same as maxHealth.
    }

    void OnTriggerEnter2D(Collider2D other) //Check the collision.
    {
        if (other.CompareTag("PlayerBullet")) //If it hits with player's bullet.
        {
            TakeDamage(10); //Do a TakeDamage function.

            Destroy(other.gameObject); //Destroy game object.
        }
    }

    void TakeDamage(int damage) //Create TakeDamage function.
    {
        currentHealth -= damage;  //Decrease the currentHealth by "damage".

        if (healthBar != null)  //If there is a Health Bar script attached to.
        {
        healthBar.Health -= damage; //Show the health bar and decrease its size according to damage.
        }
        if (currentHealth <= 0) //If currentHealth becomes 0 or less, then do:
        {
            Die(); //Call Die function.
        }
    }

    void Die() //Create Die function.
    {
        Destroy(gameObject); //Destroy game object.
    }
}
