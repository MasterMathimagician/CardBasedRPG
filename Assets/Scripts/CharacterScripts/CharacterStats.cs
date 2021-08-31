using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This is a holder for the stats of a general character, either enemy or player. While either
/// could have stats or abilities the other doesn't they will all be built with this frame
/// 

public class CharacterStats
{

    public int Health;
    public int MaxHealth;
    protected int HealthStart = 1;
    protected int MaxHealthStart = 1;
    public int VictoryExperience = 0;

    public int Attack;
    public int MagicAttack;
    public int Defense;
    protected int BaseAttack = 0;
    protected int BaseMagicAttack = 0;
    protected int BaseDefense = 0;
    protected int BaseMagicDefense = 0;
    public int Level;


    public int StartingHandSize;
    public int DefaultStartingHandSize = 2;
    public int CurrentMana;
    public int MaxMana = 20;
    public int BaseMana = 20;
    public int ManaRegenerationRate = 7;
    public int ManaRegenerationFrequency = 4;

    public bool Dead = false;

    protected virtual void NewCharacterStats()
    {
        Health = HealthStart;
        MaxHealth = MaxHealthStart;

        Attack = BaseAttack;
        MagicAttack = BaseMagicAttack;
        Defense = BaseDefense;

        StartingHandSize = DefaultStartingHandSize;
        CurrentMana = MaxMana;
        //ManaRegenerationRate = ManaRegenerationRate;
        //ManaRegenerationFrequency = ManaRegenerationFrequency;
    }

    public int DamageCharacter(int damageAmount)
    {
        //Debug.Log ("Damaged by " + damageAmount);
        int temp = Mathf.Max((damageAmount - Defense), 0);
        Health -= temp;
        if (Health <= 0)
        {
            Die();
        }
        return temp;
    }

    public void Die()
    {
        Dead = true;
    }

    public int HealCharacter(int healAmount)
    {
        Health += healAmount;
        int temp = healAmount;
        if (Health > MaxHealth)
        {
            healAmount = healAmount - (Health - MaxHealth);
            Health = MaxHealth;
        }
        return temp;
    }

    public void fullHeal()
    {
        Health = MaxHealth;
    }

}
