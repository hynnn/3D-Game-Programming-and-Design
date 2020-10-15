using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface ISceneController{
        void LoadResource();    // 加载资源
    }

    public interface UserAction{    //用户操作
        void MoveBoat();
        void ObjectIsClicked(MyCharacterController character);
        void Restart();
    }

    public enum SSActionEventType : int {started, completed}

    public interface SSActionCallback{
        void SSActionCallback(SSAction source,
            SSActionEventType events = SSActionEventType.completed,
            int intParam = 0,
            string strParam = null,
            Object objectParam = null);
    }
}
