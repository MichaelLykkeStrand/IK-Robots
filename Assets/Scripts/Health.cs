using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth, currentHealth;
    private const int MIN_HEALTH = 0;

    //Events
    public event EventHandler OnHit;
    public event EventHandler OnDeath;
    public event EventHandler OnHeal;

    private bool isHit;
    private bool isDead;

    private void Awake()
    {
        if (this.currentHealth > this.maxHealth)
        {
            this.currentHealth = maxHealth;
        }
    }

    public bool IsHit()
    {
        return this.isHit;
    }

    public void SetIsHit(bool isHit)
    {
        this.isHit = isHit;
    }

    /// <returns>A boolean of the current deathstate.</returns>
    public bool IsDead()
    {
        return this.isDead;
    }

    /// <returns>A int representing the current health.</returns>
    public int GetHealth()
    {
        return this.currentHealth;
    }

    /// <param name="value">the new max health amount.</param>
    public void SetMaxHealth(int value)
    {
        if (this.currentHealth > value)
        {
            this.currentHealth = value;
        }
        this.maxHealth = value;
    }

    /// <returns>A int representing the max health.</returns>
    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

    /// <param name="damage">the damage amount.</param>
    public void Damage(int damage)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damage, MIN_HEALTH, this.maxHealth);
        if (currentHealth <= MIN_HEALTH)
        {
            this.isDead = true;
            this.currentHealth = MIN_HEALTH;
            OnDeath.Invoke(this, EventArgs.Empty);

        }
        OnHit.Invoke(this, EventArgs.Empty);
    }

    /// <param name="_heal">the heal amount.</param>
    public void Heal(int heal)
    {
        if (currentHealth != MIN_HEALTH && !isDead)
        {
            this.currentHealth = Mathf.Clamp(currentHealth + heal, MIN_HEALTH, this.maxHealth);
            OnHeal.Invoke(this, EventArgs.Empty);
        }
    }


    /// <param name="_heal">the heal amount.</param>
    /// <param name="_revive">Defines if the heal should be able to revive.</param>
    public void Heal(int heal, bool revive)
    {
        this.currentHealth = Mathf.Clamp(currentHealth + heal, MIN_HEALTH, this.maxHealth);
        if (currentHealth != MIN_HEALTH && revive)
        {
            this.isDead = false;
            OnHeal.Invoke(this, EventArgs.Empty);
        }
    }
}