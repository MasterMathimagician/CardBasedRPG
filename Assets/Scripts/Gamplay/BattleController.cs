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

public class BattleController : MonoBehaviour
{

    private PersistentData pd;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Checking if github works");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
