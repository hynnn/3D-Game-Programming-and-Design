using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController
{
    readonly GameObject character;
	//readonly moveable Cmove;
	readonly ClickGUI clickgui;
	readonly int Ctype;		//0->priset, 1->devil
	private bool _isOnboat;
	private CoastController coastcontroller;
	int moving_state; //1-> move， -1-> not

	public MyCharacterController(string Myname){
		if(Myname == "priest"){
			character = Object.Instantiate(Resources.Load("Prefabs/Priest", typeof(GameObject)), Vector3.zero, Quaternion.identity,null) as GameObject;
			Ctype = 0;
		}
		else{
			character = Object.Instantiate(Resources.Load("Prefabs/Devil", typeof(GameObject)), Vector3.zero, Quaternion.identity,null) as GameObject;
			Ctype = 1;
		}
		clickgui = character.AddComponent(typeof(ClickGUI)) as ClickGUI;
		clickgui.setController(this);
		moving_state = -1;
	}
	public int getType(){
		return Ctype;
	}
	public void setName(string name){
		character.name = name;
	}
	public string getName(){
		return character.name;
	}
	public void setPosition(Vector3 postion){
		character.transform.position = postion;
	}
	public Vector3 getPosition(){
		return character.transform.position;
	}
	public void getOnBoat(BoatController tem_boat){
		coastcontroller = null;
		character.transform.parent = tem_boat.getGameObject ().transform;
		_isOnboat = true;
	}
	public void getOnCoast(CoastController coastCon){
		coastcontroller = coastCon;
		character.transform.parent = null;
		_isOnboat = false;
	}
	public bool isOnBoat(){
		return _isOnboat;
	}
	public CoastController getCoastController(){
		return coastcontroller;
	}
	public int getMoveSpeed(){
		return 20;
	}
	public GameObject getGameObject(){
		return character;
	}
	public int getMovingState(){
		return moving_state;
	}
	public void changeMovingState(){
		moving_state = -moving_state;
	}
	public void reset(){
		//Cmove.reset ();
		coastcontroller = (SSDirector.getInstance ().currentSceneController as FirstController).fromCoast;
		getOnCoast(coastcontroller);
		setPosition (coastcontroller.getEmptyPosition ());
		coastcontroller.getOnCoast (this);
	}
}
