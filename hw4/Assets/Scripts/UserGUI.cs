using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class UserGUI : MonoBehaviour {
	private UserAction action;
	private GUIStyle MyStyle;
	private GUIStyle MyButtonStyle;
	public int if_win_or_not;

	void Start(){
		action = SSDirector.getInstance ().currentSceneController as UserAction;

		MyStyle = new GUIStyle ();
		MyStyle.fontSize = 40;
		MyStyle.normal.textColor = new Color (255f, 0, 0);
		MyStyle.alignment = TextAnchor.MiddleCenter;

		MyButtonStyle = new GUIStyle ("button");
		MyButtonStyle.fontSize = 30;
	}
	void reStart(){
		if (GUI.Button (new Rect (Screen.width/2-Screen.width/8, Screen.height/2+80, 150, 50), "Restart", MyButtonStyle)) {
			if_win_or_not = 0;
			action.Restart ();
			//moveable.cn_move = 0;
		}
	}
	void OnGUI(){
		reStart ();
		if (if_win_or_not == -1) {
			GUI.Label (new Rect (Screen.width/2-Screen.width/8, 50, 100, 50), "Game Over!!!", MyStyle);
			reStart ();
		} else if (if_win_or_not == 1) {
			GUI.Label (new Rect (Screen.width/2-Screen.width/8, 50, 100, 50), "You Win!!!", MyStyle);
			reStart ();
		}
	}
}
