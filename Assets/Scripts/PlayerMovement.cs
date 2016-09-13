using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5f;
    private float verticalVelocity = 0f;
    private float gravity = 12f;

    private float animationDuration = 3f;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
	}
}
