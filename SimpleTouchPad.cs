using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	private Vector2 origin;

	public void OnPointerDown (PointerEventData data){
		origin = data.position;
	}
	public void OnDrag (PointerEventData data){
		Vector2 currentPosition = data.position;
		Vector2 directionRaw = currentPosition - origin;
		Vector2 direction = directionRaw.normalized;
		Debug.Log (direction);
	}
	public void OnPointerUp (PointerEventData data){
		
	}
}
