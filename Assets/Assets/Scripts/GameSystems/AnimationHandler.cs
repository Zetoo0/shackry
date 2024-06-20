using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public static void ChangeAnimation(string newState, string curr,out string currAnim, Animator anim)
    {
    
            if (Animator.StringToHash(newState).Equals(Animator.StringToHash(curr)))
            {
                currAnim = curr;
                return;
            }

            currAnim = newState;
            anim.Play(Animator.StringToHash(newState));

    }

}
