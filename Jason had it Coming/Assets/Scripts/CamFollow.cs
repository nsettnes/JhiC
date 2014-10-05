using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour 
{
	public Transform focus; 
	public MountainController mc;
	public float followspeed;
	public float inFront;

	private bool focusMovingRight = true;
	private float focusLastXpos = 0f;

	void Start () 
	{
		if(focus == null)
			Debug.LogWarning("CamFollow, Transform focus is not set");

		if(mc == null)
			Debug.LogWarning("CamFollow, MountainController mc is not set");
	}
	
	void FixedUpdate () 
	{
		CheckFocusMovement();

		float movement;
		if(!focusMovingRight)
		{
			movement = Mathf.Clamp( Mathf.Abs(transform.position.x - focus.position.x + inFront), 0, 5 );
			movement *= followspeed * Time.fixedDeltaTime;

			transform.position = transform.position - new Vector3(movement, 0, 0);
			mc.UpdateMountains(movement);
		}
		else 
		{
			movement = Mathf.Clamp( Mathf.Abs(transform.position.x - focus.position.x - inFront), 0, 5 );
			movement *= followspeed * Time.fixedDeltaTime;

			transform.position = transform.position + new Vector3(movement, 0, 0);
			mc.UpdateMountains(-movement);
		}
	}

	void CheckFocusMovement()
	{
		if(focus.position.x < focusLastXpos)
			focusMovingRight = false;
		else if(focus.position.x > focusLastXpos)
			focusMovingRight = true;

		focusLastXpos = focus.position.x;
	}
}
