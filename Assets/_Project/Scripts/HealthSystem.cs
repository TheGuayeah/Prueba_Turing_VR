using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
   public event EventHandler OnDead;
   public event EventHandler OnTakeDamage;
   public event EventHandler OnHeal;

   [SerializeField]
   private AudioSource healSound;
   [SerializeField]
   private int maxHealth = 100;

   private int health = 100;

   private void Awake()
   {
      health = maxHealth;
   }

   public void TakeDamage(int damage)
   {
      health -= damage;

      if (health <= 0)
      {
         health = 0;
         Die();
      }
      OnTakeDamage?.Invoke(this, EventArgs.Empty);
   }

   public void Heal(int healAmount)
   {
      if(health < maxHealth)
         healSound.Play();

      health += healAmount;

      if (health > maxHealth)
      {
         health = maxHealth;
      }
      OnHeal?.Invoke(this, EventArgs.Empty);
   }

   public float GetHealthNormalized()
   {
      return (float)health / maxHealth;
   }

   private void Die()
   {
      OnDead?.Invoke(this, EventArgs.Empty);
   }
}
