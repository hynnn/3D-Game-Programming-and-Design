using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interfaces;
//实现一个动作组合序列，顺序播放动作
public class CCSequenceAction : SSAction, SSActionCallback
{
    public List<SSAction> sequence;
    public int repeat = 1; // 1->only do it for once, -1->repeat forever
    public int currentActionIndex = 0;

    public static CCSequenceAction getAction(int repeat, int currentActionIndex, List<SSAction> sequence)
    {
        CCSequenceAction action = ScriptableObject.CreateInstance<CCSequenceAction>();
        action.sequence = sequence;
        action.repeat = repeat;
        action.currentActionIndex = currentActionIndex;
        return action;
    }

    public override void Update()
    {
        if (sequence.Count == 0) return;
        if (currentActionIndex < sequence.Count)
        {
            sequence[currentActionIndex].Update();
        }
    }

    public void SSActionCallback(SSAction source,
            SSActionEventType events = SSActionEventType.completed,
            int intParam = 0,
            string strParam = null,
            Object objectParam = null)
    {
        source.destroy = false;
        this.currentActionIndex++;
        if (this.currentActionIndex >= sequence.Count)
        {
            this.currentActionIndex = 0;
            if (repeat > 0) repeat--;
            if (repeat == 0)
            {
                this.destroy = true;
                this.CallBack.SSActionCallback(this);
            }
        }
    }

    public override void Start()
    {
        foreach (SSAction action in sequence)
        {
            action.gameObject = this.gameObject;
            action.transform = this.transform;
            action.CallBack = this;
            action.Start();
        }
    }

    void OnDestroy()
    {
        foreach (SSAction action in sequence)
        {
            Object.Destroy(action);
        }
    }
}
