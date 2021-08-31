using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CardAppearance: This script is meant to control the appearance of the card object it is attached to including:
 * CardTitle, CardImage, Type, Text, CardBack and possibly size
 * 
 * 
 */

public class CardAppearance : MonoBehaviour
{
    private GameObject thisCard;
    public GameObject cardText;
    public GameObject cardTitle;
    public GameObject cardPicture;


    // Start is called before the first frame update
    void Start()
    {
        thisCard = gameObject;
    }

    public void UpdateCardText()
    {

    }

    public void UpdateCardTitle()
    {

    }

    public void UpdateCardPicture()
    {

    }
}
