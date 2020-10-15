using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interfaces;

public class CCActionManager : SSActionManager, SSActionCallback
{
    public SSActionEventType Complete = SSActionEventType.completed;

    public void BoatMove(BoatController Boat)
    {
        Complete = SSActionEventType.started;
        CCMoveToAction action = CCMoveToAction.getAction(Boat.getDestination(), Boat.getMoveSpeed());
        addAction(Boat.getGameObject(), action, this);
        Boat.changeTFflag();
    }

    public void CharacterMove(MyCharacterController GameObject, Vector3 Destination)
    {
        Complete = SSActionEventType.started;
        Vector3 CurrentPos = GameObject.getPosition();
        Vector3 MiddlePos = CurrentPos;
        if (Destination.y > CurrentPos.y)
        {
            MiddlePos.y = Destination.y;
        }
        else
        {
            MiddlePos.x = Destination.x;
        }
        SSAction action1 = CCMoveToAction.getAction(MiddlePos, GameObject.getMoveSpeed());
        SSAction action2 = CCMoveToAction.getAction(Destination, GameObject.getMoveSpeed());
        SSAction seqAction = CCSequenceAction.getAction(1, 0, new List<SSAction> { action1, action2 });
        this.addAction(GameObject.getGameObject(), seqAction, this);
    }

    public void SSActionCallback(SSAction source,
            SSActionEventType events = SSActionEventType.completed,
            int intParam = 0,
            string strParam = null,
            Object objectParam = null)
    {
        Complete = SSActionEventType.completed;
    }
}
