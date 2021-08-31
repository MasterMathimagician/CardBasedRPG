using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This text is specifically for reminder and clarification text to be deleivered to the user
 * 
*/


public class DescriptorTextController : MonoBehaviour
{

	//private Text displayText;
	public PersistentData data;

	// Use this for initialization
	void Start()
	{
		//displayText = GetComponentInChildren<Text> ();
	}

	// Update is called once per frame
	void Update()
	{
		//displayText.text = "Hero Level: " + data.GetHeroObject().Level;
	}
}
