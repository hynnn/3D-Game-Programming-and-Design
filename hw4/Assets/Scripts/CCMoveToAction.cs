using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实现具体动作，将一个物体移动到目标位置，并通知任务完成
public class CCMoveToAction : SSAction
{
    public Vector3 target;
    public float speed;

    //private CCMoveToAction() { }
    public static CCMoveToAction getAction(Vector3 target, float speed)
    {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.target = target;
        action.speed = speed;
        return action;
    }

    public override void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            destroy = true;
            CallBack.SSActionCallback(this);
        }
    }

    public override void Start()
    {

    }
}
