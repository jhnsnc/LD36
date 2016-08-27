using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 1.0f;
	public float cameraRotationSpeed = 50.0f;

	private CharacterController characterController;

	private bool enableRotation = false;

	// Use this for initialization
	void Start ()
	{
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			enableRotation = true;
		}
		if (Input.GetButtonUp("Fire2"))
		{
			enableRotation = false;
		}
	}

	void FixedUpdate()
	{
		float moveForward = Input.GetAxis("Vertical");
		float strafe = Input.GetAxis("Horizontal");

		Vector3 playerRot = new Vector3(0, 0, 0);
		Vector3 cameraRot = new Vector3(0, 0, 0);

		if (enableRotation)
		{
			if ( Input.GetAxis("Mouse X") < 0 )
			{
				playerRot.y -= 1;
			}

			if ( Input.GetAxis("Mouse X") > 0 )
			{
				playerRot.y += 1;
			}

			if ( Input.GetAxis("Mouse Y") < 0 )
			{
				cameraRot.x += 1;
			}

			if ( Input.GetAxis("Mouse Y") > 0 )
			{
				cameraRot.x -= 1;
			}
		}

		transform.Rotate(playerRot, cameraRotationSpeed * Time.deltaTime);
		Camera.main.transform.Rotate(cameraRot, cameraRotationSpeed / 2 * Time.deltaTime);

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float forwardSpeed = moveForward * moveSpeed;

		characterController.SimpleMove(forward * forwardSpeed);
	}

}
