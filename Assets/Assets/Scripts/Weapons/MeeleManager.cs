using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeeleManager : MonoBehaviour
{
    public bool isCanMeele;
    public static Action meele;

    private void Start()
    {
        isCanMeele = false;
    }

    private void Update()
    {
        CheckDamage();
    }

    void CheckDamage()
    {
        if (isCanMeele)
        {
            MeeleDamage();
        }
    }

    public void MeeleDamage()
    {
        Debug.Log("AAASD");

        Debug.Log("AAAA");
        meele?.Invoke();
        isCanMeele = false;
    }


}
