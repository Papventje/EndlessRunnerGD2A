using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5f;
    private float verticalVelocity = 0f;
    private float gravity = 12f;

    private bool isDead = false;
    private bool animationTimer;


    // Use this for initialization
    void Start () {
        animationTimer = false;
        StartCoroutine(Timer());
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;

        if (controller.transform.position.y <= -10)
        {
            Debug.Log("U diedeidiedid");
        }

        if (animationTimer == false)
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

    public void setSpeed(float modifier)
    {
        speed = 5f + modifier;
    }

    private void Death()
    {
        //
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        animationTimer = true;
    }
}
