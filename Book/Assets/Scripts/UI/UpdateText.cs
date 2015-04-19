using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {
    Text txt;
	// Use this for initialization
	void Start () 
    {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        txt.text = HUDManager.Instance.allTheText;
	}
}
