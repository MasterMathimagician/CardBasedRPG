using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// This is the BattleController and should manage:
/// 1) Game behaviour including who's turn it is
/// 2) What is currently allowed,
/// 3) Status of abilities (usable/on cooldown)
/// 4) deck contents and deck permissions
/// 5) refences to the card functionality
/// 6) What to do if a card is played (are targets valid, are creatures summoned, what zone does the card change to)
/// 7) Deck Shuffling:
///    for each position in deck
///     rand = Random(0, n-i)
/// 	switch(list[n - i], list[rand])
/// 8) load decks from both the NPC and Hero's Decklists
/// 

/* BattleController: Maintains the game board of the battle scene and calls functions of the various objects involved as needed
 * 
 * 
 * 
 * 
 * Some notes on game mechanics: There is no "cost" to running out of cards beyond being unable to draw a card
 * items may be used to renew the deck, cards may be used to find a card in the deck, shuffle cards back into
 * the deck and generally provide library manipulation
 * 
 * 
 * Will need to shuffle the list of cards in the "deck" using https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
 * for each i in list of size n
 * 	rand = Random(0, n-i)
 * 	switch(list[n-i], list[rand])
 * 
 * The graveyard, to be implemented, will be a list of all cast spells of the character, should cards cast in previous battles 
 * matter?
 * Add the functionality just in case
 * put deck sizes starting at 40 or 50, special abilities can allow a reduction of 5 cards from deck size
 * 
 * Starting deck is made up of "sizzle" - a minor spell, 1 mana deals 2 damage, only card with no number limit?
 * 										- don't set card limits for now, limit cards behind the scenes with invisible
 * 									 numbers or let each card have a max number in deck (modifiable with abilities)
 *                                   (The randomness takes into account how many of a certain card you have found?)
 * 
 * 
*/

public class BattleController : MonoBehaviour
{

	private PersistentData pd;
	private CharacterStats hero;
	private EnemyManager enemies;
	private CharacterStats opponent;

	public Text display;

	public GameObject RegularAttackButton;
	public GameObject SpecialPowerButton;
	public GameObject ItemButton;
	public GameObject RunButton;
	public GameObject EndTurnButton;
	public GameObject CardZone;
	public GameObject Card;
	public CardsManager cardManager;

	private float EnemyTurnDelay = 1.75f;
	private int TurnNumber = 1;

	private Queue<int> DeckInPlay;

	private bool HeroTurn = true;

	// Initialization before the game starts
	void Awake()
	{
		GameObject temp = GameObject.Find("PersistentData");
		if (temp == null)
		{
			Debug.Log("PersistentData missing!");
			return;
		}
		pd = temp.GetComponent<PersistentData>();
		if (pd == null)
		{
			Debug.Log("hero not found");
			return;
		}
		//pd.NewGame();
	}


	// Use this for initialization
	void Start()
	{
		/*
		opponent = gameObject.AddComponent<Opponent>();
		Hero tempHero = FindObjectOfType<Hero> ();
		if (tempHero == null) {
			hero = gameObject.AddComponent<Hero> ();
			hero.NewHero ();
		} else {
			hero = tempHero;
		}
		if (hero == null) {
			Debug.Log ("hero not found");
			return;
		}

		TurnNumber = 1;
		DeckInPlay = new Queue<int> ();
		int[] tempDeck = {30,6,6,4,4,2,2,2,2,1,1};
		ShuffleCards (tempDeck);
		// Load handsize
		for (int i = 0; i<hero.StartingHandSize; i++) 
		{
			DrawCardHero();
		}
		EnemyManager tempEnemies = FindObjectOfType<EnemyManager> ();
		if (tempEnemies == null) {
			enemies = gameObject.AddComponent<EnemyManager> ();
		} else {
			enemies = tempEnemies;
		}

		Opponent tempOpponent = FindObjectOfType<Opponent> ();
		if (tempOpponent == null) {
			opponent = gameObject.AddComponent<Opponent> ();
			opponent.NewOpponent ();
		} else {
			opponent = tempOpponent;
		}
		tempOpponent = enemies.GetOpponent(0);
		opponent.LoadOpponent (ref tempOpponent);
		if (opponent == null) {
			Debug.Log ("opponent not found");
			return;
		}
		display = FindObjectOfType<DisplayInformation> ();
		if (display==null) {
			Debug.Log ("display is null");
		}
		display.ChangeDisplayText ("An Enemy has appeared!");
		UpdateText ();
        */
	}

	public void RegularAttack()
	{
		RegularAttackButton.GetComponent<Button>().interactable = false;

		int temp = opponent.DamageCharacter(hero.Attack);
		if (opponent.Dead)
		{
			//display.ChangeDisplayText("Enemy Defeated");
		}
		else
		{
			//display.ChangeDisplayText("Enemy hit for " + temp + " damage.");
		}
		UpdateText();
	}

	public void SpecialAttack()
	{
		SpecialPowerButton.GetComponent<Button>().interactable = false;
		//display.ChangeDisplayText("Special Power Used");
		UpdateText();
	}

	public void ChangeWeapon()
	{
		//display.ChangeDisplayText("Weapon Changed");
		UpdateText();
	}
	public void Item()
	{
		//display.ChangeDisplayText("Item Used");

	}
	public void Run()
	{
		//display.ChangeDisplayText("Run Away failed");
		RunButton.GetComponent<Button>().interactable = false;
	}

	public void EndTurn()
	{
		if (HeroTurn)
		{
			HeroTurn = false;
			TurnNumber++;
			RegularAttackButton.GetComponent<Button>().interactable = false;
			SpecialPowerButton.GetComponent<Button>().interactable = false;
			ItemButton.GetComponent<Button>().interactable = false;
			RunButton.GetComponent<Button>().interactable = false;
			EndTurnButton.GetComponent<Button>().interactable = false;
			StartCoroutine(EnemyTurn());
		}

	}

	public void EnemyFight()
	{
		int temp = hero.DamageCharacter(opponent.Attack);
		if (hero.Dead)
		{
			//display.ChangeDisplayText("You lose!!!!!");
		}
		else
		{
			//display.ChangeDisplayText("Hero hit for " + temp + " damage.");
		}
		UpdateText();
	}

	public IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(EnemyTurnDelay);
		EnemyFight();
		yield return new WaitForSeconds(EnemyTurnDelay / 2);
		RegularAttackButton.GetComponent<Button>().interactable = true;
		SpecialPowerButton.GetComponent<Button>().interactable = true;
		ItemButton.GetComponent<Button>().interactable = true;
		RunButton.GetComponent<Button>().interactable = true;
		EndTurnButton.GetComponent<Button>().interactable = true;
		HeroTurn = true;
		DrawCardHero();
	}

	public void DrawCardHero()
	{
		if (DeckInPlay.Count > 0)
		{
			GameObject card = Instantiate(Card);
			card.transform.SetParent(CardZone.transform, false);
			int cardNum = DeckInPlay.Dequeue();
			card.GetComponent<CardProperties>().DuplicateProperties(cardManager.GetCardData(cardNum), cardManager.GetCardImage(cardNum));
		}
	}

	public bool UseCard(CardProperties card)
	{
		/*
		if (card.ManaCost <= hero.Mana) 
		{
			hero.Mana = hero.Mana - card.ManaCost;
			cardManager.CastCard(card.CardNo, ref hero, ref opponent);
			display.ChangeDisplayText ("Hero cast " + card.CardNameText.text);
			UpdateText ();
			return true;
		} else 
		{
			UpdateText ();
			display.ChangeDisplayText ("Could not cast " + card.CardNameText.text);
			return false;
		}
		*/
		return false;
	}


	/// <summary> To complete later
	/// /////////
	/// </summary>
	/// <param name="deck">Deck.</param>
	public void ShuffleCards(int[] deck)
	{
		int[] temp = new int[deck[0]];
		int place = 0;
		for (int i = 1; i < deck.Length; i++)
		{
			for (int j = 0; j < deck[i]; j++)
			{
				temp[place] = i;
				place++;
			}
		}
		for (int i = temp.Length - 1; i >= 0; --i)
		{
			int rand = Random.Range(0, temp.Length - i);
			int t = temp[i];
			temp[i] = temp[rand];
			temp[rand] = t;
		}
		for (int i = 0; i < temp.Length; i++)
		{
			DeckInPlay.Enqueue(temp[i]);
		}
	}

	public void UpdateText()
	{
		//display.UpdateHeroManaText ();
		//display.UpdateHeroHealthText ();
		//display.ChangeEnemyStatsText(opponent.GetStats());
	}
}
