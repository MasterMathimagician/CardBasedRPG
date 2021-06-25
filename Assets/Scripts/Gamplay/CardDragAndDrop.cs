using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// CardDragAndDrop
/// This script is meant to contain the basic functionality of using cards, this doesn't contain the code related
/// to card effects but will send messa
/// 
/// Note: If the collider of the card used is too large there will be problems with this script, recommend making the
/// collider as small as possible 

public class CardDragAndDrop : MonoBehaviour
{
    public GameplayManager gameplayManager;

    public GameObject mainCanvas;
    private GameObject startParent;
    private GameObject target;

    private bool isPlayable;
    private bool isDragging=false;
    private bool isPlayed = true;

    private Vector2 startPosition;
    private Vector2 endPostion;
    


    /// This function needs to find all the gameobjects and manager scripts the card can interact with.
    /// This includes GameplayManager and the canvas 
    void Awake()
    {
        gameplayManager = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        mainCanvas = GameObject.Find("MainCanvas");

    }

    // This needs to bring the card selected with the mouse as well as display a larger version of the card when moused
    /// over but not while dragging as that could get in the way of gameplay
    void Update()
    {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(mainCanvas.transform, true);
        }
    }

    /// <summary>
    /// This function needs to detect what the card is directly over and figure out if the card can be played,
    /// and set up the fields neccesary to trigger that if the card is released
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");

        target = collision.gameObject;
        // try to set the isPlayable to the value of the object in the current gamestate, for now it will just be true
        isPlayable = true;
    }

    // This function needs to remove the possibility of a card being played on the area just removed from 
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("collision exit" +collision.ToString());
        isPlayable = false;
        target = null;
    }

    // allows card to move and remember its' origin
    public void StartDrag()
    {
        isDragging = true;
        //Debug.Log("start drag");
        //startParent = self.parent.transform.position;
        startPosition = transform.position;
    }

    // probably not needed
    public void Dragging()
    {
        
    }

    // if there is a playable target the game will contact the gameController gameobject script to try to play the
    // card if the card it not played it will return to its' source
    public void EndDrag()
    {
        //Debug.Log("end drag");

        if (target != null)
        {
            //Debug.Log("target not null");
            if (isPlayable) {
                transform.SetParent(target.transform);
                // send message to gameManager to play card which should give an option to be played
                if (isPlayed) {
                    //Destroy self?
                    //return;
                }
            }
        } else {


        }
        isDragging = false;
        //transform.SetParent(startParent);
        transform.position = startPosition;
    }
}
