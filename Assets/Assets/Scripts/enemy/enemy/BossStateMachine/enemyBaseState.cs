using System;


public abstract class BaseState
{
     public State state;
     public EntityStateMachine state_machine { get;  set; }
    protected BaseState() { }

    public virtual void EnterState() { }

    public virtual bool IsConditionsMet() { return true; }

    public virtual bool IsCoolingDown() { return true; }

    public virtual void OnTriggerEnter() { }

    public virtual void UpdateState() { }
}
