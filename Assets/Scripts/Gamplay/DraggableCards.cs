using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* DraggableCards: Basic script which has basic functionality for using cards and will be heavily modified and 
 * expanded for use in the game as I progress.
*/

public class DraggableCards : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public Transform OriginalParent = null;
	public Transform ParentReturnTo = null;
	public Transform PlaceHolderParent = null;

	//public enum CardType { stackInstant, queueInstant, sorcery, summon, ring, weapon};
	//public CardType thisCard = CardType.summon;

	GameObject PlaceHolder = null;

	public void OnBeginDrag(PointerEventData eventData)
	{
		//Debug.Log ("Begin Drag called");

		PlaceHolder = new GameObject();
		//Debug.Log ("z is " + PlaceHolder.transform.position.z);
		PlaceHolder.transform.SetParent(this.transform.parent);
		LayoutElement le = PlaceHolder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		PlaceHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

		ParentReturnTo = this.transform.parent;
		OriginalParent = this.transform.parent;
		PlaceHolderParent = ParentReturnTo;
		this.transform.SetParent(this.transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log ("Drag called");

		this.transform.position = eventData.position;
		//Debug.Log ("z is " + this.transform.position.z);

		if (PlaceHolder.transform.parent != PlaceHolderParent)
		{
			PlaceHolder.transform.SetParent(PlaceHolderParent);
		}

		int newSiblingIndex = ParentReturnTo.childCount;

		for (int i = 0; i < PlaceHolderParent.childCount; i++)
		{
			if (this.transform.position.x < PlaceHolderParent.GetChild(i).position.x)
			{
				newSiblingIndex = i;
				if (PlaceHolder.transform.GetSiblingIndex() < newSiblingIndex)
				{
					newSiblingIndex--;
				}
				break;
			}
		}

		PlaceHolder.transform.SetSiblingIndex(newSiblingIndex);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log ("Drag End end "+ParentReturnTo.ToString());
		this.transform.SetParent(ParentReturnTo);
		this.transform.SetSiblingIndex(PlaceHolder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(PlaceHolder);
	}


	public void Cast()
	{
		CardProperties card = this.gameObject.GetComponent<CardProperties>();
		BattleController battleController = GameObject.Find("WorldController").GetComponent<BattleController>();
		bool castable = false;

		if ((card != null) && (battleController != null))
		{
			castable = battleController.UseCard(card);
		}
		else
		{
			Debug.Log("Card does not contain a CardProperties Script");
		}
		if (castable)
		{
			Destroy(this.gameObject);
		}
		else
		{
			//Debug.Log ("Card could not be cast");
			this.transform.SetParent(OriginalParent);
			this.transform.SetSiblingIndex(PlaceHolder.transform.GetSiblingIndex());
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		Destroy(PlaceHolder);
	}
}