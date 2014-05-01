using UnityEngine;
using System.Collections;


public class score : MonoBehaviour {


	private static TextMesh score2;
	private static int scoreNum = 0;
	// Use this for initialization
	void Start () {
		score2 = gameObject.GetComponent (typeof(TextMesh)) as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
		score2.text = "Score: " + scoreNum; 
	}
}
