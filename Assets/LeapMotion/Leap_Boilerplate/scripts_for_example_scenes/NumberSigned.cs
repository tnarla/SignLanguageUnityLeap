using UnityEngine;
using System.Collections;
using Leap;

public class NumberSigned : MonoBehaviour {

	private LeapManager _leapManager;
	private Controller _leapController;
	private Frame _currentFrame = Frame.Invalid;



	private static TextMesh text;


	static string Number;



	float numberTen;


	// Use this for initialization
	void Start () {
		//Frame frame = _leapController.Frame();
		_leapController = new Controller ();
		text = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;


		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;

	}

		/*
	 * A direct reference to the Controller for accessing the LeapMotion data yourself rather than going through the helper.
	 */
	public Controller leapController{
		get { return _leapController; }
	}
	
	/*
	 * The most recent frame of data from the LeapMotion controller.
	 */
	public Frame currentFrame
	{
		get { return _currentFrame; }
	}

	public Hand frontmostHand()
	{
		float minZ = float.MaxValue;
		Hand forwardHand = Hand.Invalid;
		
		foreach(Hand hand in _currentFrame.Hands)
		{
			if(hand.PalmPosition.z < minZ)
			{
				minZ = hand.PalmPosition.z;
				forwardHand = hand;
			}
		}
		
		return forwardHand;
	}



	// Update is called once per frame
	void Update () {
		Frame frame = _leapController.Frame();

		float left = frame.Pointables.Leftmost.TipPosition.x;
		float right = frame.Pointables.Rightmost.TipPosition.x;
		float front = frame.Pointables.Frontmost.TipPosition.x;
		float frontlength = frame.Pointables.Frontmost.TipPosition.z;
		float frontheight = frame.Pointables.Frontmost.TipPosition.y;
		float frontavg = (frontlength + frontheight + front) / 3;
		_currentFrame = _leapController.Frame();

		if (frontmostHand().Fingers.Count == 1)
		{
			if ((numberTen - frontavg) < 3)
			{
				Number = "1";
				numberTen = frontavg;
			}

			else if (numberTen != frontavg)
			{
				numberTen = frontavg;
				Number = "10";
			}
		}
		else if (frontmostHand().Fingers.Count == 2)
		{
			Number = "2";
		}

		else if (frontmostHand().Fingers.Count == 5)
		{
			Number = "5";
		}

		else if (frontmostHand().Fingers.Count == 4)
		{
			Number = "4";
		}

		else if (frontmostHand().Fingers.Count == 3)
		{
			if (left == front)
			{
				Number = "9";
			}
			else if (right == front)
			{
				Number = "3";
			}
			else if ((left != front) && (right != front) && (Mathf.Abs(Mathf.Abs(front - left) - Mathf.Abs(right - front)) < 10))
			{
				Number = "6";
			}
			else if (Mathf.Abs(front - left) > Mathf.Abs(right - front))
			{
				Number = "8";
			}
			else if (Mathf.Abs(front - left) < Mathf.Abs(right - front))
			{
				Number = "7";
			}
		}


		text.text = "Number signed: " + Number;

	//	while (Number = randomNumber) {
	//		score2 += 5; 
	//}

}
}
