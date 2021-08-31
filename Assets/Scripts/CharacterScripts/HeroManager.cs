using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This is the hero Manager
/// It needs to be able to support a characterStats object for the player or else inherit from the CharacterStats script
/// probably load it with the current hero stats, I think I prefer splitting it, the battle scene will have two
/// CharacterStats Objects with a larger number of familiar objects but this will focus on the overworld and the carry over
/// of health/magic/status/exp etc.
///
/// Possible futures: possibly the main character can obtain permanent familiars rather than card summonable familiars
/// they should have levels and abilities but when knocked out are out for the entire battle (barring resurection
/// cards/abilities) card summons don't worry about that
/// 

public class HeroManager : MonoBehaviour
{
    public int Level;
    protected int LevelStart = 1;
    protected int Experience;
    protected int ExperienceStart = 0;



    // Start is called before the first frame update
    void Start()
    {
        Level = LevelStart;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// using the the pokemon version of level up where total experience needed for next level = L^3
    /// this keeps early level gain pretty quick and and later level gain slower
    public bool CheckLevel()
    {
        int temp = (int)Mathf.Pow((float)Level, 3);
        if (temp < Experience)
        {
            Level++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetLevel(int levelIn)
    {
        Level = levelIn;
        Experience = (int)Mathf.Pow((float)(Level - 1), 3);
    }


    /// This method produces the character stats object and the card list to be passed to the battlescene
	/// and passes it
    public void StartBattle()
    {

    }
}
