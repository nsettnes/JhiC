using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public KeyCode left = KeyCode.None;
	public KeyCode aLeft = KeyCode.None;
	public KeyCode right = KeyCode.None;
	public KeyCode aRight = KeyCode.None;

	public float movespeed;
	
	CharacterController cc;
	public bool bFacingRight = false, bIsMoving = false;
	public Transform spriteRoot;
	
	Animator anim;

	void Start () 
	{
		anim = transform.FindChild("sBodyUpper").GetComponent<Animator>();
		CheckControlsInit();
	}

	void CheckControlsInit()
	{
		if(left == KeyCode.None)
			Debug.LogWarning("PlayerController, KeyCode 'left' is not set");
		if(aLeft == KeyCode.None)
			Debug.LogWarning("PlayerController, KeyCode 'aLeft' is not set");
		if(right == KeyCode.None)
			Debug.LogWarning("PlayerController, KeyCode 'right' is not set");
		if(aRight == KeyCode.None)
			Debug.LogWarning("PlayerController, KeyCode 'aRight' is not set");	

		if(movespeed == 0)
			Debug.LogWarning("PlayerController, float movespeed is set to 0");

		if(spriteRoot == null)
			Debug.LogWarning("PlayerController, Transform sprites is not set");

		if(anim == null)
			Debug.LogWarning("PlayerController, Animator anim is not set");

	}
	
	void FixedUpdate () 
	{
		Vector2 v = Vector2.zero;
		bIsMoving = false;

		if(Input.GetKey(left) || Input.GetKey(aLeft))
		{
			v += movespeed * -Vector2.right;
			bFacingRight = false;
			bIsMoving = true;
		}
		if(Input.GetKey(right) || Input.GetKey(aRight))
		{
			v += movespeed * Vector2.right;
			bFacingRight = true;
			bIsMoving = true;
		}

		rigidbody2D.velocity = new Vector2(v.x, rigidbody2D.velocity.y);

		anim.SetBool("Moving", bIsMoving);

		CheckSprites();
	}

	void CheckSprites()
	{
		if(bFacingRight)
			transform.eulerAngles = new Vector3(0, 180, 0);
		else 
			transform.eulerAngles = new Vector3(0, 0, 0);
	}
}