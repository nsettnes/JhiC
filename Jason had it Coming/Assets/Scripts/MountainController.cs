using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MountainController : MonoBehaviour 
{
	Sprite[] mountainPrefabs;
	private List<Transform> mountainRange01, mountainRange02, mountainRange03;
	private List<Transform> proplist;
	public Transform props;
	public Transform mountains01, mountains02, mountains03;
	public float 
		fMountainMovement01, fMountainMovement02, fMountainMovement03, 
		fPropMovement;

	// normalize y coord: [-2.3, -5.5] *hardcoded*
	private float propNormMin = -2.3f, propNormDiff = -2.2f;

	void Start () 
	{
		LoadMountains();
		InitPropsLists();
		InitMountainRanges();
	}

	void LoadMountains()
	{
		mountainPrefabs = Resources.LoadAll<Sprite>("Sprites/Mountains");
	}

	void InitMountainRanges()
	{
		mountainRange01 = new List<Transform>();
		mountainRange02 = new List<Transform>();
		mountainRange03 = new List<Transform>();
		
		for(int i = 0; i < mountains01.childCount; i++)
			mountainRange01.Add( mountains01.GetChild(i) );

		for(int i = 0; i < mountains02.childCount; i++)
			mountainRange02.Add( mountains02.GetChild(i) );

		for(int i = 0; i < mountains03.childCount; i++)
			mountainRange03.Add( mountains03.GetChild(i) );
	}

	void InitPropsLists()
	{
		proplist = new List<Transform>();

		for(int i = 0; i < props.childCount; i++)
			proplist.Add( props.GetChild(i) );
	}
	
	public void UpdateMountains (float xMovement) 
	{
		LerpPosition(xMovement);
		CheckReposition(25f, 20f, 4f);
	}

	void CheckReposition(float maxDistance, float replaceDistance, float fRandomize)
	{
		foreach(Transform t in mountainRange01)
		{
			if(t.localPosition.x > maxDistance)
			{
				t.localPosition = new Vector3( -replaceDistance - Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
			else if(t.localPosition.x < -maxDistance)
			{
				t.localPosition = new Vector3( replaceDistance + Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
		}
		
		foreach(Transform t in mountainRange02)
		{
			if(t.localPosition.x > maxDistance)
			{
				t.localPosition = new Vector3( -replaceDistance - Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
			else if(t.localPosition.x < -maxDistance)
			{
				t.localPosition = new Vector3( replaceDistance + Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
		}
		
		foreach(Transform t in mountainRange03)
		{
			if(t.localPosition.x > maxDistance)
			{
				t.localPosition = new Vector3( -replaceDistance - Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
			else if(t.localPosition.x < -maxDistance)
			{
				t.localPosition = new Vector3( replaceDistance + Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
		}

		foreach(Transform t in proplist)
		{
			if(t.localPosition.x > maxDistance)
			{
				t.localPosition = new Vector3( -replaceDistance - Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
			else if(t.localPosition.x < -maxDistance)
			{
				t.localPosition = new Vector3( replaceDistance + Random.value * fRandomize, t.localPosition.y, t.localPosition.z );
			}
		}
	}

	void LerpPosition(float xMovement)
	{
		foreach(Transform t in mountainRange01)
		{
			t.localPosition += new Vector3(xMovement * fMountainMovement01/100f, 0,0);
		}
		
		foreach(Transform t in mountainRange02)
		{
			t.localPosition += new Vector3(xMovement * fMountainMovement02/100f, 0,0);
		}
		
		foreach(Transform t in mountainRange03)
		{
			t.localPosition += new Vector3(xMovement * fMountainMovement03/100f, 0,0);
		}

		foreach(Transform t in proplist)
		{
			float norm = Mathf.Abs( (t.localPosition.y - propNormMin) / propNormDiff );
			float normFactor = Mathf.Clamp( norm, 0.25f, 1f);
			t.localPosition += new Vector3(normFactor *xMovement * fPropMovement/100f, 0,0);
		}
	}
}
