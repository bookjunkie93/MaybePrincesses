using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
[ExecuteInEditMode]
[AddComponentMenu("Event/DoubleClickEventTrigger")]

public class DoubleClickEventTrigger : MonoBehaviour, IPointerClickHandler {

	[System.Serializable]public class DoubleClickEvent : UnityEvent{}
	public DoubleClickEvent onDoubleClick;

	void Start () {
	}
	
	void Update () {

	}	

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.clickCount == 2) {
			onDoubleClick.Invoke();
		}
	}

	
}
