/* CardEffects is a container to hold the functionality of all the cards in one convenient place, it is still 
 * dependent on outside classes that allow it to modify character stats and in the future other things as well
 * What do cards do?
 * 					Damage a target/multiple targets (add bonuses later, add multiple targets later)
 * 					Status Change a target/multiple targets
 * 					restore health to target/multiple targets
 * 					Summon a minion
 * 					revive a minion (later, requires use of a graveyard)
 * 					alter hero stats temporarily (max mana, mana generation, max health, add health buffer)
 * 					transform a summon
 * 					
 * 	note: adding multiple "cards" to a single card can allow some flexibility in how I make the individual 
 * 		  cards work
*/

public class CardEffects
{

	/// This is to handle a list of effects that the card will do, and calls an outside class in order to do so
	/// 
	public delegate void CastEventHandler(CharacterStats user, CharacterStats target, CardData cardUsed);
	public event CastEventHandler OnCast;

	public CardEffects()
	{

	}

	public void Cast(ref CharacterStats user, ref CharacterStats target, ref CardData cardUsed)
	{
		OnCast(user, target, cardUsed);
	}

	// effect: Damage a target/multiple targets (add bonuses later, add multiple targets later)
	public static void OnCast_DamageTarget(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
		target.DamageCharacter(cardUsed.CardDamage);
	}

	// effect: restore health to target/multiple targets
	public static void OnCast_HealTarget(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
		target.DamageCharacter(cardUsed.CardDamage);
		user.HealCharacter(cardUsed.CardHeal);
	}

	// effect: restore health to target/multiple targets
	public static void OnCast_SiphonTarget(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
		target.HealCharacter(cardUsed.CardHeal);
	}

	// Effect: Status Change a target/multiple targets
	public static void OnCast_ChangeStatusTarget(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}

	// Effect: Summon a minion
	public static void OnCast_SummonMinion(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}

	// Effect: transform a target summon
	public static void OnCast_TransformTarget(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}

	// Effect: revive a minion (later, requires use of a graveyard)
	public static void OnCast_ReviveMinion(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}

	// Effect: alter hero or opponent stats temporarily (max mana, mana generation, max health, add health buffer)
	public static void OnCast_ChangeCharacterStats(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}

	// Effect: alter hero stats temporarily (max mana, mana generation, max health, add health buffer)
	public static void OnCast_ChangeMinionStats(CharacterStats user, CharacterStats target, CardData cardUsed)
	{
	}
}