using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]public Player myPlayer;
    byte damage = 26;

    private void Awake()
    {
        //myPlayer = GetComponentInParent<Player>();
    }

    private void OnEnable()
    {
        Invoke("HideBullet",2.0f);
    }

    void HideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && collision.gameObject.GetComponent<PlayerMotion>().player.team != myPlayer.team)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Player>().GetDamage(damage);
            print("Damage");
            //collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
        else if(collision.transform.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
