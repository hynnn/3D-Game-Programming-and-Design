using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class ClickGUI : MonoBehaviour {

	// Use this for initialization
	UserAction action;
	MyCharacterController character;

	public void setController(MyCharacterController tem){
		character = tem;
	}
	void Start(){
		action = SSDirector.getInstance ().currentSceneController as UserAction;
	}
	void OnMouseDown(){
		if (gameObject.name == "boat") {
			action.MoveBoat();
		} else {
			action.ObjectIsClicked(character);
		}
	}
}
