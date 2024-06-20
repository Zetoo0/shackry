using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//The nun jumpscare to the player face do some dance then disappear
public class NunScare : MonoBehaviour
{
    //[SerializeField] float disappearTime;
    [SerializeField] private Animator anim;
   // public static string animToPlay;


    private IEnumerator AppearAndDisappear()
    {
        anim.Play(Animator.StringToHash("summon"));
        yield return new WaitForSecondsRealtime(2f);
        this.gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        StartCoroutine(AppearAndDisappear());
    }
}
