using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0f;
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int nextDifficulty = 10;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (score >= nextDifficulty) {
            LevelUp();
        }

        score += Time.deltaTime;
        scoreText.text = "Score: " + ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficulty == maxDifficulty)
            return;

        nextDifficulty *= 2;
        difficulty++;

        GetComponent<PlayerMovement>().setSpeed(difficulty);

        Debug.Log("Woah");
    }
}
