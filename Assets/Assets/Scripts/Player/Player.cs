using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player
{
    public byte team { get; set; }
    public string name { get; set; }
    public float health { get; set; }
    public float movementspeed { get; set; }
    public float gravity { get; private set; }
    public GameObject player { get; set; }
    public ManageTextValues TextManager { get; set; }
    public bool isCured { private get; set; }
    //Armor/shield???


    public Player(byte tm,string nam, float hp, float speed, float grav, GameObject playr, ManageTextValues manager)
    {
        this.team = tm;
        this.name = nam;
        this.health = hp;
        this.movementspeed = speed;
        this.gravity = grav;
        this.player = playr;
        this.TextManager = manager;
        this.isCured = true; 
    }


    public IEnumerator GetDamage(float dmg)//Amikor damagel az enemy k�zelharccal(!!!!) akkor a player h�tr�bb l�k�se?
    {
        Debug.Log("Base mov speed: " + this.movementspeed);
        this.health -= dmg;
        yield return new WaitForSecondsRealtime(.5f);
        Debug.Log("Fuck im damaged");
        CheckHealth();
       
    }

    public bool isPlayerCured()
    {
        return this.isCured;
    }

    public void CurePlayer()
    {
        this.isCured = true;
    }

    public void GetInfected()
    {
        this.isCured = false;
    }

    public void GetFallDamage(float dmg)
    {
        this.health -= Mathf.Round(dmg);
        //this.TextManager.SetHealthText(Mathf.Round(dmg));
        
    }

    private void CheckHealth()
    {
        if(this.health <= 0)
        {
            Debug.Log("Dead");
            this.player.SetActive(false);
            //Die
        }
        else
        {
            Debug.Log($"Health: {this.health}");
            return;
        }
    }


    


}
