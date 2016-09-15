using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float speed = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
