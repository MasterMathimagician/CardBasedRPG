using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInformation : MonoBehaviour
{

	public Text DisplayText;
	public Text EnemyStatsText;
	public Text HeroHealthText;
	public Text HeroManaText;
	public Text OptionDescriptionText;
	private string[] DisplayTextLines;
	public PersistentData data;
	private CharacterStats hero;
	private BattleController battle;

	// Use this for initialization
	void Awake()
	{
		DisplayTextLines = new string[5];
		for (int i = 0; i < DisplayTextLines.Length; i++)
		{
			DisplayTextLines[i] = "";
		}
		//displayText = GetComponentInChildren<Text> ();
		//hero = data.GetHeroObject();
		//battle = FindObjectOfType<BattleController> ();
		//UpdateHeroHealthText();
		//UpdateHeroManaText();
		//ChangeDisplayText("");
		//ChangeEnemyStatsText("");
		//ChangeOptionDescriptionText("");
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//if value changed change text else don't, string concat produces garbage to be collected each time it is run
	}

	public void ChangeDisplayText(string inputString)
	{
		string temp = "";
		for (int i = DisplayTextLines.Length - 1; i > 0; --i)
		{
			DisplayTextLines[i] = DisplayTextLines[i - 1];
		}
		DisplayTextLines[0] = inputString;
		for (int i = 0; i < DisplayTextLines.Length; i++)
		{
			temp += DisplayTextLines[i] + "\n";
		}
		DisplayText.text = temp;
	}

	public void ChangeEnemyStatsText(string inputString)
	{
		EnemyStatsText.text = inputString;
	}

	public void ChangeOptionDescriptionText(string inputString)
	{
		OptionDescriptionText.text = inputString;
	}

	public void UpdateHeroHealthText()
	{
		//		HeroHealthText.text = hero.Health.ToString();
	}

	public void UpdateHeroManaText()
	{
		//		HeroManaText.text = hero.Mana.ToString();
	}
}