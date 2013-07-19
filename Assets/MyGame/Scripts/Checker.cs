using UnityEngine;
using System.Collections;

public class Checker : MonoBehaviour {
	
	public float nowSec;
	public bool isGoal = false;
	public GUIStyle style;
	public GUIStyle style2;
	public Vector2 currentRectXY;

	// Use this for initialization
	void Start () {
		isGoal = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( isGoal == true ) {
			currentRectXY = iTween.Vector2Update(currentRectXY, new Vector2(Screen.width/2 - 50, Screen.height/2 - 50), 3.0f);
		} else {
			nowSec += Time.deltaTime;
		}
	}
	
	void OnGUI() {
		GUI.Label(new Rect(currentRectXY.x,currentRectXY.y,400,300), "Time:" + nowSec, style );
		if ( isGoal ) {
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,400,300), "Goal !", style2);
			if ( GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 50,100,50), "Restart")) {
				Application.LoadLevel(0);
			}
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		isGoal = true;
	}
}
