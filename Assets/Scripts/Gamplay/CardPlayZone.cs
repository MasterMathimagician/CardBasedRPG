using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardPlayZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

	//DraggableCards.CardType typeOfCard = DraggableCards.CardType.queueInstant; 

	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log ("OnPointerEnter");
		if (eventData.pointerDrag == null)
		{
			return;
		}
		//DraggableCards drag = eventData.pointerDrag.GetComponent<DraggableCards>();
		//if (drag != null)
		//{
		//	drag.ParentReturnTo = this.transform;
		//}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log ("OnPointerExit");
		if (eventData.pointerDrag == null)
		{
			return;
		}
		//DraggableCards drag = eventData.pointerDrag.GetComponent<DraggableCards>();
		//if (drag != null && drag.PlaceHolderParent == this.transform)
		//{
		//	drag.PlaceHolderParent = drag.ParentReturnTo;
		//}
	}

	public void OnDrop(PointerEventData eventData)
	{
		//Debug.Log (eventData.pointerDrag.name+ " was dropped on " + gameObject.name);
		//DraggableCards drag = eventData.pointerDrag.GetComponent<DraggableCards>();
		//if (drag != null)
		//{
		//	drag.ParentReturnTo = this.transform;
		//}
	}
}
