using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardCastZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

	public void OnPointerEnter(PointerEventData eventData)
	{

	}

	public void OnPointerExit(PointerEventData eventData)
	{

	}

	public void OnDrop(PointerEventData eventData)
	{
		//DraggableCards drag = eventData.pointerDrag.GetComponent<DraggableCards>();
		//if (drag != null)
		//{
			//drag.Cast();
		//}
	}
}
