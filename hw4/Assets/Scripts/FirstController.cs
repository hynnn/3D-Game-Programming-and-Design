using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interfaces;

public class FirstController : MonoBehaviour, ISceneController, UserAction
{
    readonly Vector3 water_pos = new Vector3 (0, 0.5f, 0);
	UserGUI user;
	public CoastController fromCoast;
	public CoastController toCoast;
	public BoatController boat;
	//private MyCharacterController[] characters;
	private List<MyCharacterController> team;		//角色
	public Judge judge;
	private CCActionManager manager;

	void Awake(){
		SSDirector director = SSDirector.getInstance ();
		director.currentSceneController = this;
		user = gameObject.AddComponent<UserGUI> () as UserGUI;		//添加UserGUI脚本作为组件
		//characters = new MyCharacterController[6];
		team = new List<MyCharacterController>();
		manager = gameObject.AddComponent<CCActionManager> () as CCActionManager;
		LoadResource ();
	}

/*	void Start(){
		manager = GetComponent<CCActionManager>();
	}
*/
	public void LoadResource(){	
		GameObject water = Instantiate (Resources.Load ("Prefabs/water", typeof(GameObject)), water_pos, Quaternion.identity, null) as GameObject;
		water.name = "water";

		fromCoast = new CoastController ("from");
		toCoast = new CoastController ("to");
		boat = new BoatController ();
		judge = new Judge(fromCoast, toCoast, boat);
		//judge = gameObject.AddComponent<Judge> () as Judge;

		for (int i = 0; i < 3; i++) {
			MyCharacterController tem = new MyCharacterController ("priest");
			tem.setName ("priest" + i);
			tem.setPosition (fromCoast.getEmptyPosition ());
			tem.getOnCoast (fromCoast);
			fromCoast.getOnCoast (tem);
			team.Add (tem);
		}
		for (int i = 0; i < 3; i++) {
			MyCharacterController tem = new MyCharacterController ("devil");
			tem.setName ("devil" + i);
			tem.setPosition (fromCoast.getEmptyPosition ());
			tem.getOnCoast (fromCoast);
			fromCoast.getOnCoast (tem);
			team.Add (tem);
		}
	}

	public void ObjectIsClicked (MyCharacterController tem_char){		//
		if (manager.Complete == SSActionEventType.started) 
			return;
		if (tem_char.isOnBoat()) {
			CoastController tem_coast;
			if (boat.getTFflag() == -1) {
				tem_coast = toCoast;
			} else {
				tem_coast = fromCoast;
			}
			boat.getOffBoat(tem_char.getName ());
			//tem_char.moveToPosition (tem_coast.getEmptyPosition ());
			manager.CharacterMove(tem_char, tem_coast.getEmptyPosition());
			tem_char.getOnCoast(tem_coast);
			tem_coast.getOnCoast(tem_char);
		} else {
			CoastController tem_coast2 = tem_char.getCoastController();
			if (boat.getEmptyIndex() == -1)
				return;
			if (boat.getTFflag() != tem_coast2.getTFflag())
				return;
			tem_coast2.getOffCoast (tem_char.getName());
			//tem_char.moveToPosition (boat.getEmptyPosition ());
			manager.CharacterMove(tem_char, boat.getEmptyPosition());
			tem_char.getOnBoat(boat);
			boat.getOnBoat(tem_char);
		}
		//check whether game over;
		user.if_win_or_not = judge.Check();
	}

	public void MoveBoat(){
        if (manager.Complete == SSActionEventType.started || boat.isEmpty()) 
		//if (boat.isEmpty()) 
			return;
        manager.BoatMove(boat);
        //新增的裁判类
        user.if_win_or_not = judge.Check();
    }

	public void Restart(){
		boat.reset();
		fromCoast.reset();
		toCoast.reset();
		foreach (MyCharacterController i in team) {
			i.reset();
		}
		//moveable.cn_move = 0;
	}
}
