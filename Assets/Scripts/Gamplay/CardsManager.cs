using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CardManager is a container to hold the functionality of all the cards in one convenient place, it is 
 * still dependent on outside classes that allow it to modify character stats and in the future other 
 * things as well
 * 
 * What do cards do?
 * 					Damage a target/multiple targets (add bonuses later, add multiple targets later)
 * 					Status Change a target/multiple targets
 * 					restore health to target/multiple targets
 * 					Summon a minion
 * 					revive a minion (later, requires use of a graveyard)
 * 					alter hero stats temporarily (max mana, mana generation, max health, add health buffer)
 * 					transform a summon
 * 			
 * 
 * 
 * If I use a free to play some cards that will be purchasable:
 * renew deck, -10 cards in deck, most efficient mana ramp, draw spells, minion removal etc
 * Abilities - +2 minion slots
 * 
 * 
*/


public class CardsManager : MonoBehaviour
{

	private CardProperties[] CardsProperties;
	private CardEffects[] CardsEffects;
	private CardData[] CardsData;
	public Sprite[] CardImages;

	// Use this for initialization
	public virtual void Awake()
	{
		//Debug.Log ("CardManager Awakened");
		CardsData = new CardData[10];
		CardsEffects = new CardEffects[10];
		//CardsProperties = new CardProperties[10];

		CardsData[0] = new CardData(0, "Fireball", "Stack Instant", "hurls a ball of fire dealing 3 damage", 1);
		CardsData[0].SetBasicValues(3, 0); // damage, heal
		CardsEffects[0] = new CardEffects();
		CardsEffects[0].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[1] = new CardData(1, "Quick Recover", "Stack Instant", "Heals 4 damage to target character", 1);
		CardsData[1].SetBasicValues(0, 4);
		CardsEffects[1] = new CardEffects();
		CardsEffects[1].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[2] = new CardData(2, "Siphon", "Stack Instant", "Deals 4 Damage to a target and heals the caster by 4", 3);
		CardsData[2].SetBasicValues(4, 4);
		CardsEffects[2] = new CardEffects();
		CardsEffects[2].OnCast += CardEffects.OnCast_DamageTarget;
		CardsEffects[2].OnCast += CardEffects.OnCast_HealTarget;

		CardsData[3] = new CardData(3, "Counterstrike", "Queue Instant", "Deals 5 damage to a target in response to an action", 1);
		CardsData[3].SetBasicValues(5, 0);
		CardsEffects[3] = new CardEffects();
		CardsEffects[3].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[4] = new CardData(4, "Meditate", "Sorcery", "Increases the rate of mana regeneration", 2);
		CardsData[4].SetBasicValues(0, 0);
		CardsEffects[4] = new CardEffects();
		CardsEffects[4].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[5] = new CardData(5, "Flamespeak", "Sorcery", "Deals 7 damage to a single target", 5);
		CardsData[5].SetBasicValues(7, 0);
		CardsEffects[5] = new CardEffects();
		CardsEffects[5].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[6] = new CardData(6, "Gremlin", "Summon", "Summons a 1/1 gremlin", 2);
		CardsData[6].SetBasicValues(0, 0);
		CardsEffects[6] = new CardEffects();
		CardsEffects[6].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[7] = new CardData(7, "Ring of Regeneration", "Ring", "Decreases the time between mana regenation events by 1 turn", 4);
		CardsData[7].SetBasicValues(0, 0);
		CardsEffects[7] = new CardEffects();
		CardsEffects[7].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[8] = new CardData(8, "Staff", "Weapon", "Switches your weapon to Staff", 5);
		CardsData[8].SetBasicValues(0, 0);
		CardsEffects[8] = new CardEffects();
		CardsEffects[8].OnCast += CardEffects.OnCast_DamageTarget;

		CardsData[9] = new CardData(9, "Sword", "Weapon", "Switches your weapon to Sword", 5);
		CardsData[9].SetBasicValues(0, 0);
		CardsEffects[9] = new CardEffects();
		CardsEffects[9].OnCast += CardEffects.OnCast_DamageTarget;
	}

	public virtual void Start()
	{
		//Debug.Log ("CardManager Started");
	}

	// Update is called once per frame
	void Update()
	{

	}

	public int GetTotalAvailableCards()
	{
		//Debug.Log ("num of cards " +CardsText.Length);
		return CardsData.Length;
	}

	public CardData GetCardData(int cardNum)
	{
		if ((cardNum <= CardsData.Length) && (cardNum > 0))
		{
			return CardsData[cardNum - 1];
		}
		else
		{
			return CardsData[0];
		}
	}

	public Sprite GetCardImage(int cardNum)
	{
		if (cardNum <= CardsData.Length)
		{
			return CardImages[cardNum];
		}
		else
		{
			return CardImages[0];
		}
	}

	public void CastCard(int card, ref CharacterStats user, ref CharacterStats target)
	{

		//CardsEffects [card].Cast(ref user, ref target, ref CardsData[card]);
	}
}
