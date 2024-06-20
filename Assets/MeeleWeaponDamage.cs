using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeeleWeaponDamage : MonoBehaviour,IWeapon
{
    [SerializeField] public MeeleWeapon wp;

    private Animator _animator;
    private int attack_hash;
    private bool isAttacking;
    [SerializeField] SoundManager _soundManager;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.GetInteger("katana_swoo");
    }

    private void Start()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            Debug.Log("Eltaláltam az enemyt???");
            if (other.CompareTag("Enemy"))
            {
                _soundManager.PlayAudioAt(SoundManager.Sound.e_Hurt,other.transform.position,false);
                other.gameObject.GetComponent<enemyStateMachine>().myEnemy.DamageEnemy(wp.damage);
            }  
        }

    }

    private IEnumerator ResetAttackTrigger()
    {
        yield return new WaitForSecondsRealtime(0.33f);
        isAttacking = false;
        _animator.ResetTrigger("Attack");
        
    }

    public void Attack()
    {
        Debug.Log("Meelee attack??");
        isAttacking = true;
        _animator.SetTrigger("Attack");
        _soundManager.PlayAudioAt(SoundManager.Sound.p_Swish,this.transform.position,false);
        StartCoroutine(ResetAttackTrigger());
    }

    public string GetName()
    {
        return wp.weaponName;
    }
}
