using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour 
{
	public bool doFancyStartup = true;
	public float startupTime = 5f;
	public Transform Player; 

	void Start () 
	{
		Invoke("StartGame", startupTime);
	}

	void StartGame()
	{
		Player.parent = null;
	}
}
