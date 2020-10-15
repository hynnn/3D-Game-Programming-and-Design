using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interfaces;
//导演类，获取场景，管理全局
public class SSDirector : System.Object
{
    private static SSDirector _instance;    

    public ISceneController currentSceneController{ get; set;}
    public bool running { get; set; }

    public static SSDirector getInstance(){
        if(_instance == null)   //  单实例
            _instance = new SSDirector();
        return _instance;
    }
    // 游戏帧率
    public int getFPS(){
        return Application.targetFrameRate;
    }
    public void setFPS(int fps){
        Application.targetFrameRate = fps;
    }
}
