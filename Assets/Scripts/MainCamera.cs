using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0f;
    private float animationDuration = 2f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        moveVector = lookAt.position + startOffset;

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp(moveVector.y, 3, 6);

        if (transition > 1f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation
            transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
	}
}
