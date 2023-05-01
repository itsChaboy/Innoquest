using System.Net;
using System.Globalization;
using System.Net.Sockets;
using UnityEngine;

public class UDPReceiver : MonoBehaviour
{
	private UdpClient udpClient;
	private IPEndPoint endPoint;
	public float cGravityX;
	public float movementSpeed = 0.5f; // adjust this to change the speed of movement

	void Start()
	{
		udpClient = new UdpClient(1204); // Replace 1234 with the port number you want to use
		endPoint = new IPEndPoint(IPAddress.Any, 0);
	}

	void Update()
	{
		if (udpClient.Available > 0)
		{
			byte[] data = udpClient.Receive(ref endPoint);
			string message = System.Text.Encoding.ASCII.GetString(data);
			Debug.Log("Received message: " + message);

			string[] messageParts = message.Split(',');
			foreach (string part in messageParts)
			{
				if (messageParts[2] == "[$$$]CGravity_X")
				{
					string stringX = messageParts[4].Trim();
					if (stringX.EndsWith (";")) 
					{
						stringX = stringX.Substring (0, stringX.Length - 1);
					}
					cGravityX = float.Parse(stringX);
					Debug.Log("CGravity_X: " + cGravityX);
					break;
				}
			}
				
		}
	}

	void OnDisable()
	{
		udpClient.Close();
	}
}