using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitScanTest : MonoBehaviour
{
    TrailRenderer trail;
    float distance = 50.0f;
    Player myPlayer;
    PlayerMotion playermov;
    byte damage = 25;
    float shotD;

    private void Update()
    {
        playermov = GetComponentInParent<PlayerMotion>();
        myPlayer = playermov.player;
    }

    public void ShootFire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if((hit.collider.gameObject.CompareTag("Player")) && (hit.collider.gameObject.GetComponent<PlayerMotion>().player.team != myPlayer.team))
            {
                shotD = hit.distance;
                print(shotD);
                print($"Damage: {damage}");
                StartCoroutine(hit.collider.gameObject.GetComponent<PlayerMotion>().player.GetDamage(damage));
            }
        }
    }

    /*void Shoot(float distance)
    {
        Vector3 endPos = transform.position + transform.forward * distance;
        RaycastHit hit = Physics.Linecast(transform.position, transform.forward * distance, LayerMask.GetMask("Wall", "Ground", "Player"));
        if(hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {

            }
        }
    }*/
}
