using UnityEngine;
using System.Collections;

public class RandomNum : MonoBehaviour {
	public static TextMesh randomNum;
	public static string randomNumber = Random.Range(1,10).ToString();

	// Use this for initialization
	void Start () {
		randomNum = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
		randomNum.text = randomNumber;
	}
	
	// Update is called once per frame
	void Update () {

}
}
