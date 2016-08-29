using UnityEngine;
using System.Collections;

public class TerrainSwitchButton : MonoBehaviour
{
	public float transitionTime = 5.0f;
	public float transitionDistance = 25.0f;
	public Transform terrainTransform;
	
	public float doorLockTime = 0.5f;
	public float doorLockDistance = -10.0f;
	public Transform doorLockTransform;
	
	private bool isPressed;
	private bool isTransitioning;
	
	private float transitionTimeRemaining;
	private Vector3 transitionStartPosition;
	private Vector3 transitionEndPosition;
	
	private float doorTransitionDelay;
	private float doorTransitionTimeRemaining;
	private Vector3 doorTransitionStartPosition;
	private Vector3 doorTransitionEndPosition;

	void Start ()
	{
		isPressed = false;
		isTransitioning = false;
	}
	
	void Update ()
	{
		if (isTransitioning) {
			transitionTimeRemaining -= Time.deltaTime;
			if (doorTransitionDelay <= 0.0f) {
				doorTransitionTimeRemaining -= Time.deltaTime;
			} else {
				doorTransitionDelay -= Time.deltaTime;
			}
			
			// advance transition
			terrainTransform.position = Vector3.Lerp(transitionStartPosition, transitionEndPosition,  Mathf.Min(1.0f - (transitionTimeRemaining / transitionTime), 1.0f));
			if (doorTransitionDelay <= 0.0f) {
				doorLockTransform.position = Vector3.Lerp(doorTransitionStartPosition, doorTransitionEndPosition,  1.0f - (doorTransitionTimeRemaining / doorLockTime));
			}
		
			// exit condition
			if (transitionTimeRemaining <= 0.0f && doorTransitionTimeRemaining <= 0.0f) {
				isTransitioning = false;
			}
		}
	}
	
	void OnMouseDown()
	{
		if (!isTransitioning) {
			isPressed = !isPressed;
			isTransitioning = true;
			
			transitionTimeRemaining = transitionTime;
			transitionStartPosition = terrainTransform.position;
			transitionEndPosition = transitionStartPosition;
			transitionEndPosition.y += transitionDistance * (isPressed ? -1 : 1);
			
			doorTransitionTimeRemaining = doorLockTime;
			doorTransitionDelay =  (isPressed ? 0.0f : transitionTimeRemaining - doorTransitionTimeRemaining);
			doorTransitionStartPosition = doorLockTransform.position;
			doorTransitionEndPosition = doorTransitionStartPosition;
			doorTransitionEndPosition.y += doorLockDistance * (isPressed ? -1 : 1);
		}
	}
}
