using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5f;
    private float jumpSpeed = 2f;
    private float verticalVelocity = 0f;
    private float gravity = 12f;

    private bool jump;

    private bool animationTimer;


    // Use this for initialization
    void Start () {
        animationTimer = false;
        StartCoroutine(Timer());
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(animationTimer == false)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            jump = true;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            jump = false;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            //controller.GetComponent<Collider>().attachedRigidbody.AddForce(0, 1, 0);
            //controller.Move(Vector3.up * jumpSpeed);
            Debug.Log("Jump");
        }
	}

    public void setSpeed(float modifier)
    {
        speed = 5f + modifier;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        animationTimer = true;
    }
}
