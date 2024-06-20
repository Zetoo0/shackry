using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class GunGun : MonoBehaviour, IRangedWeapon
{
    [SerializeField] public RangedWeapon wp;
    float lastTimeShoot;

    [SerializeField]RecoilSystem recSys;
    [SerializeField]public ManageTextValues mngText;
    public byte currMag;
    WeaponBulletSpecial bullSpec;
    [SerializeField] LineRendererHandler lineRendererH;
    [SerializeField] Transform Bulletpos;
    [SerializeField] private SoundManager soundManager;
    Vector3 shootOrigin;

    [SerializeField] Transform ShootPos;

    Camera mainCam;
    private int attackableLayerMask;

    public static Action onCanShoot;
    [SerializeField] private float weaponShootDenominator;
    [SerializeField] private float weaponShootTime;

    private Action onReaload;

    [SerializeField] private Vector3 V_reloadRotateAngle;
    private Quaternion Q_reloadRotateAngle;
    private bool isReload;
    private Quaternion baseRotation;

    private byte shotBullets;
    private byte weaponMaximumShootableBulletNum;
    public byte weaponMagazine;
    private void Awake()
    {
        SetAwake();
    }

    private void SetAwake()
    {
        currMag = wp.magazine;
    }

    private void Start()
    {
        mainCam = Camera.main;
        shootOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,0.0f));
        Vector3 centerCam = mainCam.transform.localPosition;
        bullSpec = wp.WPBSpecial;
        attackableLayerMask = LayerMask.GetMask(StaticLayerNames.attackableLayers);
        Q_reloadRotateAngle = Quaternion.Euler(V_reloadRotateAngle);
        baseRotation = gameObject.transform.localRotation;
        weaponMaximumShootableBulletNum = wp.maximumLoadableBullet;
        weaponMagazine = wp.magazine;
        shotBullets = 0;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
    }

    //TODO
    private bool CanShoot() => lastTimeShoot > weaponShootTime / (wp.fireRate / weaponShootDenominator);

    public void Shoot()
    {
        if (CanShoot())
        {
            onCanShoot?.Invoke();
        }
        RaycastHit hit;
        shootOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1.0f));
        Debug.Log("Lőttem egyáltalán?");
        if (!isReload && !weaponMagazine.Equals(0))
        {   
            soundManager.PlayAudioAt(SoundManager.Sound.p_Shoot,this.transform.position,false);
            Debug.Log("Can I shoot? " + CanShoot());
            if (Physics.Raycast(ShootPos.transform.position, ShootPos.transform.forward, out hit, wp.distance,attackableLayerMask))
            {
                Debug.Log("I shot");
                if (hit.collider.gameObject.CompareTag("Enemy") /*&& CanShoot()*/)
                {
                    Debug.Log("Talált?");
                    recSys.OnRecoil();
                    soundManager.PlayAudioAt(SoundManager.Sound.e_Hurt,hit.transform.position,false);
                    hit.collider.gameObject.GetComponent<enemyStateMachine>().myEnemy.DamageEnemy(wp.damage);
                    shotBullets++;
                    weaponMagazine--;
                    lastTimeShoot = 0;
                    CheckAmmo();
                }
            }
            else if (CanShoot())
            {
                Debug.Log("Nem talált");
                recSys.OnRecoil();
                shotBullets++;
                weaponMagazine--;
                lastTimeShoot = 0;
                CheckAmmo();
            }
        }
    }
    
    /// <summary>
    ///Checking the weapon's bullet spec type and do stuffs with the enemy based on the bullet type
    /// </summary>
    /// <param name="hit"></param>
    /*private void WeaponSpecialBulletTypeHandler(RaycastHit hit)//Damage and do things  with the enemy here
    {
        //working
        switch (bullSpec)
        {
            case WeaponBulletSpecial.WBSNormal:
                hit.collider.gameObject.GetComponent<EnemyMovement>().enemy.DamageEnemy(wp.damage);
                break;
            case WeaponBulletSpecial.WBSInfection:
                //Do da infection
                break;
            case WeaponBulletSpecial.WBSPushBack:
                //Do da push Back
                break;
            default:
                break;
        }
    }*/
    
    public void CheckAmmo()
    {
        if (shotBullets.Equals(wp.maximumLoadableBullet))
        {
            Reload();
        }
        else
        {
            // mngText.SetAmmoText(true);
        }
        
    }

    public void Reload()
    {
        isReload = true;
      //  mngText.SetAmmoText(false);
    }
    
    private void Update()
    {
        Debug.DrawRay(ShootPos.transform.position,ShootPos.transform.forward*20.0f,Color.magenta);
        if (isReload)
        {
            Debug.Log("Reload animation kellene");
            this.gameObject.transform.Rotate(Vector3.right, 420*Time.unscaledDeltaTime, Space.Self);
            StartCoroutine(ReloadAnimationThresholder());
        }
        UpdateShoot();

    }

    IEnumerator ReloadAnimationThresholder()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        shotBullets = 0;
        gameObject.transform.localRotation = baseRotation;
        isReload = false;
    }
    
    private void UpdateShoot()
    {
        lastTimeShoot += Time.deltaTime;
    }
    
    public void Attack()
    {
        Debug.Log("AttackWithAGun???");
        Shoot();
    }

    public string GetName()
    {
        return wp.weaponName;
    }

    public void AddAmmo(byte amount)
    {
        wp.magazine += amount;
    }
}
