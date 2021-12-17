
/// container class for card data
/// ****** possible redundant class *********** (see card properties
/// need to decide whether using a monobehaviour script or a regular script will be better, currently I believe 
/// I should avoid monobehaviour for this, making this the proper use class
/// 
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

public class CardData
{

	public int CardNo = 0;

	//private string[] CardTypeStrings = { "Stack Instant", "Queue Instant", "Sorcery", "Summon", "Ring", "Weapon"};
	public enum CardType { stackInstant, queueInstant, sorcery, summon, ring, weapon };

	public CardType ThisCardsType = 0;
	public string TargetType = "";


	public string CardNameText;
	public string CardTypeText;
	public string[] CardDescriptionText;
	public string ManaCostText;

	public int CardDamage = 0;
	public int CardHeal = 0;

	public bool StatChange;

	public int AttackChange;
	public int DefenseChange;
	public int RegenChange;
	public int ManaChange;
	public int ManaCost;

	public string SummonName;
	public string StatusChange;

	public CardData()
	{
		int manaCost = 0;
		string name = "";
		string description = "";
		string cardType = "sorcery";
		ThisCardsType = SelectType(cardType);


		CardNameText = name;
		CardTypeText = cardType;
		CardDescriptionText[0] = description;
		ManaCostText = manaCost.ToString();

		StatChange = false;

		AttackChange = 0;
		DefenseChange = 0;
		RegenChange = 0;
		ManaChange = 0;
		ManaCost = manaCost;
		CardDamage = 0;
		CardHeal = 0;

		SummonName = "";
		StatusChange = "";
	}

	public CardData(int cardNo, string name, string cardType, string description, int manaCost)
	{
		CardNo = cardNo;
		ThisCardsType = SelectType(cardType);

		CardNameText = name;
		CardTypeText = cardType;
		CardDescriptionText = new string[1];
		CardDescriptionText[0] = description;
		ManaCostText = manaCost.ToString();

		StatChange = false;

		AttackChange = 0;
		DefenseChange = 0;
		RegenChange = 0;
		ManaChange = 0;
		ManaChange = 0;
		ManaCost = manaCost;
		CardDamage = 0;
		CardHeal = 0;

		SummonName = "";
		StatusChange = "";
	}

	public void SetBasicValues(int cardDamage, int cardHeal)
	{
		CardDamage = cardDamage;
		CardHeal = cardHeal;
	}

	public void SetTargetType(string type)
	{
		TargetType = type;
	}

	public void SetStatusValues(bool statChange, int attackChange, int defenseChange, int regenChange, int manaChange, string summonName, string statusChange)
	{
		StatChange = statChange;

		AttackChange = attackChange;
		DefenseChange = defenseChange;
		RegenChange = regenChange;
		ManaChange = manaChange;

		SummonName = summonName;
		StatusChange = statusChange;
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
		return CardType.sorcery;
	}

	public string GetDescriptionText()
	{
		string temp = "";
		for (int i = 0; i < CardDescriptionText.Length; i++)
		{
			temp += CardDescriptionText[i];
		}
		return temp;
	}

}
