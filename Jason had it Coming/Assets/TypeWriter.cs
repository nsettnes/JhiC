using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour 
{
	public string[] snippets; 

	public float timeBetweenSnippets = 2.5f; 
	public float charactersPerSecond = 20;
	public bool additiveSnippets = false;

	private Text text;

	private int currentSnippet = 0;
	private float snippetStart = 0;
	private float snippetEnd = 0;
	private float snippetLength = 0;

	private bool shifting = false;

	void Start()
	{
		text = GetComponent<Text>();
		snippetStart = Time.time;
		snippetLength = snippets[currentSnippet].Length;
		snippetEnd = snippetStart + (snippetLength / charactersPerSecond);
	}

	void StartNewSnippet()
	{
		shifting = false;
		currentSnippet++;
		if(currentSnippet < snippets.Length)
		{
			if(additiveSnippets)
			{
				if(snippets[currentSnippet].Substring(0, 1) == "_")
				{
					sLegacy = "";
					snippets[currentSnippet] = snippets[currentSnippet].Substring(1, snippets[currentSnippet].Length-1);
				}
				else 
				{
					sLegacy = string.Concat( sLegacy, snippets[currentSnippet-1], "\n" );
				}
			}

			snippetStart = Time.time;
			snippetLength = snippets[currentSnippet].Length;
			snippetEnd = snippetStart + (snippetLength / charactersPerSecond);
		}
		else 
		{
			GameObject.Destroy(this);
		}
	}

	private string sLegacy = "";
	void Update()
	{
		if(!shifting)
		{
			float characters = Mathf.Clamp( (snippetLength * (Time.time - snippetStart) / (snippetEnd - snippetStart)), 0, snippetLength);
			text.text = string.Concat( sLegacy, snippets[currentSnippet].Substring(0, (int)characters) );


			if(characters >= snippetLength)
			{
				shifting = true;
				Invoke("StartNewSnippet", timeBetweenSnippets);
			}
		}
	}
}
