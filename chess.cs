using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chess : MonoBehaviour
{
	private int count = 0;			//记录下了几个棋子
    private int player = 0;			//轮到了第几个玩家
    private int[,] map = new int[3, 3];		//棋盘	
	//private int [] repent		//记录当前玩家下棋位置坐标
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

	void OnGUI(){
		int result = check();
		//GUI.Label(new Rect(Screen.width / 2 - 100,100,300,300),"");  

		if (GUI.Button(new Rect(Screen.width / 2 + 100 , 120, 100, 50), "Restart"))	//重新开始
			Reset();

	//	if ( !(result > 0) && GUI.Button(new Rect(Screen.width / 2 + 100, 150, 100, 50), "Retreat"))	//悔棋，后退一步
		//	Retreat();
		
		GUI.skin.button.fontSize = 15;
		GUI.skin.label.fontSize = 25;
		GUI.skin.label.normal.textColor = Color.black;
		GUI.backgroundColor = Color.white;

		for(int i=0; i<3; i++){
			for(int j=0; j<3; j++){
				if(map[i,j] == 1)
					GUI.Button(new Rect(50*i + Screen.width / 2 - 100, 50*j + 70, 50, 50),"O");
				if(map[i,j] == 2)
					GUI.Button(new Rect(50*i + Screen.width / 2- 100, 50*j + 70, 50, 50),"X");
				//else
				//	GUI.Button(new Rect(50*i + Screen.width / 2- 100, 50*j + 70, 50, 50),"");
				if(result == 0 && GUI.Button(new Rect(50*i + Screen.width / 2- 100, 50*j + 70, 50, 50),"")){
					if(player == 0){
						map[i,j] = 1;
						player = 1;
					}
					else if(player == 1){
						map[i,j] = 2;
						player = 0;
					}
					count++;
		//			repent[0] = i;
		//			repent[1] = j;
				}
			}
		}
		
		if(result == 1)
			GUI.Label(new Rect(Screen.width / 2 - 50, 20, 100, 50), "O wins");
		else if(result == 2)
			GUI.Label(new Rect(Screen.width / 2 - 50, 20, 100, 50), "X wins");
		else if(result == 3)
			GUI.Label(new Rect(Screen.width / 2 - 50, 20, 100, 50), "TIE!");
		else
			GUI.Label(new Rect(Screen.width / 2 - 50, 20, 100, 50), "Plying...");
	}

	void Reset(){
		count = 0;
		player = 0;
		for(int i=0; i<3; i++){
			for(int j=0; j<3; j++)
				map[i,j] = 0;
		}
	}
/*
	void Retreat(){
		player = (player+1)%2;                        // 将玩家设为想要悔棋的一方
		map[repent[0],repent[1]] = -1;		// repent数组记录的坐标点即没有棋子
	}*/

	int check(){		//检查行、列、对角
		for (int i = 0; i < 3; i++){
            if (map[i, 0] == map[i, 1] && map[i, 0] == map[i, 2] && map[i, 0] != 0)
                return map[i, 0]; 
        }
        for (int j = 0; j < 3; j++){
            if (map[0, j] == map[1, j] && map[0, j] == map[2, j] && map[0, j] != 0)
                return map[0, j]; 
        }
        if (map[0, 0] == map[1, 1] && map[0, 0] == map[2, 2] && map[0, 0] != 0) 
			return map[0, 0];
        if (map[0, 2] == map[1, 1] && map[0, 2] == map[2, 0] && map[0, 2] != 0) 
			return map[0, 2];

        if (count == 9) 
			return 3;   //平局

		return 0;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
