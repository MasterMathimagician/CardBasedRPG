using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDeckManager
{

    public int LargestMaxDeckSize = 100;
    public int MaxDeckSize;
    public int MinDeckSize;
    public int[] DeckSize;
    private int MinDeckSizeStart = 40;
    private int MaxDeckSizeStart = 45;
    private int DeckSizeStart = 40;

    //private CardList CardRef;

    private int NumberOfDecks = 3;
    private int DeckInUse = 0;
    private int[,] Decks;
    private int[] CardCollection;
    private int NumberOfAvailableCards;
    private CardsManager cardManager;


    //public override void Start()
    //{
    //
    //Debug.Log ("Hero Started");
    //    cardManager = GameObject.Find("WorldController").GetComponent<CardManager>();
    //  if (cardManager != null)
    //  {
    //      NumberOfAvailableCards = cardManager.GetTotalAvailableCards();
    //  }
    //  else
    //  {
    //      Debug.Log("CardManager does not exist");
    //  }
    //  NewHero();
    //}

    public void NewHero()
    {

        DeckSize = new int[NumberOfDecks];
        for (int i = 1; i < NumberOfDecks; i++)
        {
            DeckSize[i] = DeckSizeStart;
        }

        MaxDeckSize = MaxDeckSizeStart;
        MinDeckSize = MinDeckSizeStart;

        CardCollection = new int[NumberOfAvailableCards];
        CardCollection = new int[7];
        // default card collection
        //int size = CardCollection.GetUpperBound(0);
        //size = 7;
        for (int i = 0; i < CardCollection.Length; i++)
        {
            CardCollection[i] = 0;
        }
        CardCollection[0] = MinDeckSizeStart;
        //Debug.Log ("card collection size is "+CardCollection[0] ); // gets first dimension
        Decks = new int[NumberOfDecks, LargestMaxDeckSize + 1];
        for (int i = 0; i < NumberOfDecks; i++)
        {
            Decks[i, 0] = DeckSizeStart;
            for (int j = 1; j < LargestMaxDeckSize + 1; j++)
            {
                Decks[i, j] = 0;
            }
        }
    }

    public void LoadHero()
    {
        //HeroLevel = HeroLevelStart;
        //Health = HealthStart;
        //MaxHealth = MaxHealthStart;
        //DeckSize = DeckSizeStart;

    }

    public int AddCardToCollection(int cardNum)
    {
        CardCollection[cardNum]++;
        return CardCollection[cardNum];
    }

    public int RemoveCardFromCollections(int cardNum)
    {
        if (CardCollection[cardNum] > 0)
        {
            --CardCollection[cardNum];
        }
        return CardCollection[cardNum];
    }

    public void GetDeck(ref int[] deck)
    {
        int size = Decks.GetUpperBound(1);
        for (int i = 0; i < size; i++)
        {
            deck[i] = Decks[DeckInUse, i];
        }
    }
}
