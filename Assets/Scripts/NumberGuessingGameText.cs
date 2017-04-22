using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberGuessingGameText : MonoBehaviour {

	public Text text;
	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () {
		StartGame ();
	}

	void StartGame() {
		max = 1000;
		min = 1;
		guess = 500;

		text.text = "Welcome To The Number Guessing Game! " +
					"\n\nPick a number in your head, but don't tell me! \n" +
					"The highest number you can pick is 1000. \nThe lowest number you can pick is 1.\n\nIs the number higher or lower than " + guess + 
					"?\n\nUp arrow = higher \nDown arrow = lower \nReturn key = correct";

		max = max + 1;
	}

	IEnumerator Restart() {
		yield return new WaitForSeconds(1);
		Start();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			text.text = "I won!";
			StartCoroutine(Restart());
		}
	}

	void NextGuess () {
		guess = (max + min) / 2;
		text.text = "Higher or lower than " + guess + 
					"?\n\nUp arrow = higher \nDown arrow = lower \nReturn key = correct";
	}
}
