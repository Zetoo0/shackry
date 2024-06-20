
using UnityEngine;
using System;

public interface IEntityBaseState
{
    public  void EnterState();
    public  void UpdateState();
    public  bool IsConditionsMet();
    public  bool IsCoolingDown();
    public  void OnTriggerEnter();
}
