using UnityEngine;
using System.Collections;

public class SpriteRecursiveMatch : MonoBehaviour 
{
	SpriteRenderer match; 
	Transform root;

	void Awake () 
	{
		match = GetComponent<SpriteRenderer>();
		root = transform;
		MatchRecursive(root);
	}

	void MatchRecursive(Transform spr)
	{
		SpriteRenderer spr_temp = spr.GetComponent<SpriteRenderer>();
		if(spr_temp != null)
		{
			spr_temp.color = match.color;
		}

		if(spr.childCount > 0)
		{
			for(int i = 0; i < spr.childCount; i++)
			{
				MatchRecursive(spr.GetChild(i));
			}
		}
	}
}
