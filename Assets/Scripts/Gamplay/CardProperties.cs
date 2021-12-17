using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* CardProperties is a container to hold information of the behaviour of a given card, this includes the number of targets this affects, 
 *  damage, healing, functionality, etc. 
 * I will try to make this have as broad functionality as possible but some less basic cards will need their functionality added 
 * individually but this should still be added so that if an effect is to be repeated in another card the code can be reused
 * 
 * Need to use events: https://docs.microsoft.com/en-us/dotnet/standard/events/
 * 
 * What do cards do?
 * 					Damage a target/multiple targets (add bonuses later)
 * 					Status Change a target/multiple targets
 * 					restore health to target/multiple targets
 * 					Summon a minion
 * 					revive a minion (later, requires use of a graveyard)
 * 					alter hero stats temporarily (max mana, mana generation, max health, add health buffer)
 * 					transform a summon
 * 					
*/

public class CardProperties : MonoBehaviour
{

	public int CardNo;
	public int ManaCost;
	private string[] CardTypeStrings = { "Stack Instant", "Queue Instant", "Sorcery", "Summon", "Ring", "Weapon" };
	public enum CardType { stackInstant, queueInstant, sorcery, summon, ring, weapon };
	public CardType ThisCardsType = 0;

	public Text CardNameText;
	public Text CardTypeText;
	public Text CardDescriptionText;
	public Text ManaCostText;
	public Sprite CardImage;

	public Image CardDisplayArea;


	public virtual void Start()
	{

		//Debug.Log ("CardProperties Started"+this.transform.parent.gameObject.ToString ());
	}

	public virtual void Awake()
	{
		//Debug.Log ("CardProperties Awakened");
	}

	// can be Action or Func, Func must return the last type in the list of parameters
	//public event Action<CardProperties, CharacterStats> OnCast;

	// Use this for initialization
	public void DuplicateProperties(CardData card, Sprite image)
	{
		CardNo = card.CardNo;
		ThisCardsType = SelectType(card.CardTypeText);
		ManaCost = card.ManaCost;


		CardNameText.text = card.CardNameText;
		CardDescriptionText.text = card.GetDescriptionText();
		ManaCostText.text = card.ManaCostText;
		CardImage = image;

		UpdateAppearance();
	}

	public void UpdateAppearance()
	{
		CardTypeText.text = CardTypeStrings[(int)ThisCardsType];
		ManaCostText.text = ManaCost.ToString();
		CardDisplayArea.sprite = CardImage;
	}

	public CardType GetCardType()
	{
		return ThisCardsType;
	}

	private CardType SelectType(string type)
	{
		if ("Stack Instant" == type)
		{
			return CardType.stackInstant;
		}
		if ("Queue Instant" == type)
		{
			return CardType.queueInstant;
		}
		if ("Sorcery" == type)
		{
			return CardType.sorcery;
		}
		if ("Summon" == type)
		{
			return CardType.summon;
		}
		if ("Ring" == type)
		{
			return CardType.ring;
		}
		if ("Weapon" == type)
		{
			return CardType.weapon;
		}

		Debug.Log("CardType not found!");
		return CardType.sorcery;
	}

    //public void PlayCard(Hero hero, CharacterStats enemy) {
    //}
    // looking at the CardProperties and the Character stats, will need each card to call a targeting function for targeted effects
    //public event Action<CardProperties, CharacterStats> playCard;
}
