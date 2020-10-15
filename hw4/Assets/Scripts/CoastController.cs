using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoastController
{
    readonly GameObject coast;
	readonly Vector3 from_pos = new Vector3(9,1,0);
	readonly Vector3 to_pos = new Vector3(-9,1,0);
	readonly Vector3[] postion;
	readonly int TFflag;		//-1->to, 1->from

	private MyCharacterController[] passengerPlaner;

	public CoastController(string to_or_from){
		postion = new Vector3[] {
			new Vector3 (6.5f, 2.25f, 0),
			new Vector3 (7.5f, 2.25f, 0),
			new Vector3 (8.5f, 2.25f, 0),
			new Vector3 (9.5f, 2.25f, 0),
			new Vector3 (10.5f, 2.25f, 0),
			new Vector3 (11.5f, 2.25f, 0)
		};
		passengerPlaner = new MyCharacterController[6];
		if(to_or_from == "from"){
			coast = Object.Instantiate(Resources.Load("Prefabs/Mycoast", typeof(GameObject)), from_pos, Quaternion.identity, null) as GameObject;
			coast.name = "from";
			TFflag = 1;
		}
		else{
			coast = Object.Instantiate(Resources.Load("Prefabs/Mycoast", typeof(GameObject)), to_pos, Quaternion.identity, null) as GameObject;
			coast.name = "to";
			TFflag = -1;
		}
	}
	public int getTFflag(){
		return TFflag;
	}
	public MyCharacterController getOffCoast(string object_name){
		for(int i=0; i<passengerPlaner.Length; i++){
			if(passengerPlaner[i] != null && passengerPlaner[i].getName() == object_name){
				MyCharacterController myCharacter = passengerPlaner[i];
				passengerPlaner[i] = null;
				return myCharacter;
			}
		}
		return null;
	}
	public int getEmptyIndex(){
		for(int i=0; i<passengerPlaner.Length; i++){
			if(passengerPlaner[i] == null){
				return i;
			}
		}
		return -1;
	}
	public Vector3 getEmptyPosition(){
		int index = getEmptyIndex();
		Vector3 pos = postion[index];
		pos.x *= TFflag;
		return pos;
	}
	public void getOnCoast(MyCharacterController myCharacter){
		int index = getEmptyIndex();
		passengerPlaner[index] = myCharacter;
	}
	public int[] getCharacterNum(){
		int[] count = {0,0};
		for(int i=0; i<passengerPlaner.Length; i++){
			if(passengerPlaner[i] == null) continue;
			if(passengerPlaner[i].getType() == 0) count[0]++;
			else count[1]++;
		}
		return count;
	}
	public void reset(){
		passengerPlaner = new MyCharacterController[6];
	}
}
