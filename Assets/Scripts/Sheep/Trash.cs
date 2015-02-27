﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler {
	public GameObject item{
		get {
			if (transform.childCount>0) {
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			Destroy (DragHandler.itemBeingDragged);
//			DragHandler.itemBeingDragged.transform.SetParent(transform);
//			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.HasChanged());
		} else {
			Destroy (DragHandler.itemBeingDragged);
		}
	}

	#endregion
}
