using UnityEngine;
using System.Collections;

public class TerrainSwitchButton : MonoBehaviour
{
	public float transitionTime = 5.0f;
	public float transitionDistance = 25.0f;
	public Transform terrainTransform;
	
	private bool isPressed;
	private bool isTransitioning;
	
	private float transitionTimeRemaining;
	private Vector3 transitionStartPosition;
	private Vector3 transitionEndPosition;

	void Start ()
	{
		isPressed = false;
		isTransitioning = false;
	}
	
	void Update ()
	{
		if (isTransitioning) {
			transitionTimeRemaining -= Time.deltaTime;
			
			// advance transition
			terrainTransform.position = Vector3.Lerp(transitionStartPosition, transitionEndPosition,  1.0f - (transitionTimeRemaining / transitionTime));
		
			// exit condition
			if (transitionTimeRemaining <= 0.0f) {
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
		}
	}

	/*
    void FixedUpdate()
	{
		//transform.Rotate(playerRot, cameraRotationSpeed * Time.deltaTime);
	}
    */
}
