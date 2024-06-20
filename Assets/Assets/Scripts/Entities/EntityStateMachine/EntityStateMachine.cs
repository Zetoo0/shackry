using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EntityStateMachine : MonoBehaviour
{

    public abstract void SwitchState(BaseState state);

}
