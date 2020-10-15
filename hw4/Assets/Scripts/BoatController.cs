using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController
{
    readonly GameObject boat;
	//readonly moveable Cmove;
	readonly Vector3 fromPos = new Vector3 (5, 1, 0);
	readonly Vector3 toPos = new Vector3 (-5, 1, 0);
	readonly Vector3[] from_pos;
	readonly Vector3[] to_pos;
	private int TFflag;		//-1->to, 1->from
	private MyCharacterController[] passenger = new MyCharacterController[2];
	int speed = 15;
	int moving_state = -1;	//1->move, -1->not move

	public BoatController(){
		TFflag = 1;
		moving_state = -1;
		from_pos = new Vector3[]{ new Vector3 (4.5f, 1.5f, 0), new Vector3 (5.5f, 1.5f, 0) };
		to_pos = new Vector3[]{ new Vector3 (-5.5f, 1.5f, 0), new Vector3 (-4.5f, 1.5f, 0) };
		
		boat = Object.Instantiate (Resources.Load ("Prefabs/Boat", typeof(GameObject)), fromPos, Quaternion.identity, null) as GameObject;
		boat.name = "boat";
		boat.AddComponent (typeof(ClickGUI));
	}

	public void getOnBoat(MyCharacterController tem_cha){		//上船
		int index = getEmptyIndex ();
		passenger [index] = tem_cha;
	}
	public MyCharacterController getOffBoat(string object_name){		//下船
		for (int i = 0; i < passenger.Length; i++) {
			if (passenger [i] != null && passenger [i].getName () == object_name) {
				MyCharacterController temp_character = passenger [i];
				passenger [i] = null;
				return temp_character;
			}
		}
		return null;
	}
	public int getEmptyIndex(){
		for (int i = 0; i < passenger.Length; i++) {
			if (passenger [i] == null)
				return i;
		}
		return -1;
	}
	public bool isEmpty(){
		for (int i = 0; i < passenger.Length; i++) {
			if (passenger [i] != null)
				return false;
		}
		return true;
	}
	public Vector3 getEmptyPosition(){
		Vector3 pos;
		int index = getEmptyIndex ();
		if (TFflag == 1) {
			pos = from_pos [index];
		} else {
			pos = to_pos [index];
		}
		return pos;
	}
	public GameObject getGameObject(){
		return boat;
	}
	public void changeTFflag(){
		TFflag = -TFflag;
	}
	public int getTFflag(){
		return TFflag;
	}
	public int[] getCharacterNum(){
		int[] count = { 0, 0 };	//[0]-.priest. [1]->devil
		for (int i = 0; i < passenger.Length; i++) {
			if (passenger [i] == null)
				continue;
			if (passenger [i].getType () == 0) {
				count [0]++;
			} else {
				count [1]++;
			}
		}
		return count;
	}
	public Vector3 getDestination(){
		if(TFflag == 1)
			return toPos;
		else
			return fromPos;
	}
	public int getMoveSpeed(){
		return speed;
	}
	public int getMovingState(){
		return moving_state;
	}
	public void changMovingState(){
		moving_state = -moving_state;
	}
	public void reset(){
		TFflag = 1;
        boat.transform.position = fromPos;
        passenger = new MyCharacterController[2];
        moving_state = -1;
	}

}
