using UnityEngine;

public class MoveController : MonoBehaviour
{
	public UDPReceiver udpreceiver; // reference to the other script
	private float X;
	private float moveSpeed = 10;

	private void Start()
	{
		


	}

	private void Update()
	{
		float X = udpreceiver.cGravityX;


		Debug.Log (X);
		Debug.Log (moveSpeed);
		if (X > 0) {
			transform.position += new Vector3 (moveSpeed * Time.deltaTime, 0f, 0f);
		} 

		else 
		
		{
			transform.position += new Vector3 (moveSpeed * (-1)* Time.deltaTime, 0f, 0f);
		}
		 // move the GameObject on the X axis based on the value of the variable from the other script
	}
}
