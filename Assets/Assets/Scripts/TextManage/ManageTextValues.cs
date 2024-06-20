using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ManageTextValues : MonoBehaviour
{
    Player TMPplayer;
    [SerializeField]TMP_Text healthText;
    [SerializeField]public TMP_Text ammoText;
    [SerializeField] TMP_Text completionText;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] public TMP_Text MoneyText;
    [SerializeField] public TMP_Text weaponText;
    public GunGun gun;
    [SerializeField] CompletionSystem completionSys;
    [SerializeField] private FiringSystemManager _firingSystemManager;
    private int currentHealth = 100;
    public static short currentAmmoLoaded;
    public static short currentAmmoInMagazine;
    float time = 0;
    Canvas _canvas;
    private Color originalColor;
    //Some onWeaponChange Action


    [SerializeField]private float frequency;
    [SerializeField]private float amplitude;

    private void Awake()
    {
        gun = GetComponentInChildren<GunGun>();
        TMPplayer = GetComponent<PlayerMotion>().player;
    }

    private void OnEnable()
    {
        PlayerMotion.onHealthChange += SetHealthText;
        GunGun.onCanShoot += SetAmmoText;
        PickupAmmo.ammoPickedUp += SetAmmoText;
        enemyStateMachine.enemyDying += ChangeCompletionPercent;
        GameStartManager.PartCompleted += OnPartCompleted;
        WeaponSwitchManager.weaponChange += OnWeaponChange;
    }

    private void OnDestroy()
    {
        PlayerMotion.onHealthChange -= SetHealthText;
        GunGun.onCanShoot -= SetAmmoText;
        PickupAmmo.ammoPickedUp -= SetAmmoText;
        enemyStateMachine.enemyDying -= ChangeCompletionPercent;
        GameStartManager.PartCompleted -= OnPartCompleted;
        WeaponSwitchManager.weaponChange -= OnWeaponChange;
    }

    public void OnWeaponChange()
    {
        weaponText.SetText(_firingSystemManager.currentActiveWeapon.GetName());
    }

    public void Start()
    {
        originalColor = healthText.color;
        Debug.Log("SetTextElőtt");
        SetTextsOnStart();
        Debug.Log("SetTextUtán");
    }

    private void Update()
    {
        if (currentHealth < 100)
        {
            var flashy = Mathf.Sin(Time.deltaTime * frequency) * amplitude+1;
            healthText.color *= (float)flashy;
        }
    }

    private void OnPartCompleted()
    {
        StartCoroutine(SetPartCompletedText());
    }

    private IEnumerator SetPartCompletedText()
    {
        popupText.SetText("Part X Completed! Wait for the next turn");
        yield return new WaitForSecondsRealtime(3f);
        popupText.SetText("");
    }
    
    private void SetTextsOnStart()
    {
        currentHealth = (int)TMPplayer.health;
        Debug.Log("CurrentPlayerHealth");
        healthText.SetText(currentHealth.ToString());
        Debug.Log("Health Text Bekőne állva lenni");
        currentAmmoLoaded = gun.wp.maximumLoadableBullet;
        ammoText.SetText(currentAmmoLoaded.ToString());
        Debug.Log("Player health :" + currentHealth);
        Debug.Log("Player ammo loaded in the current gun:" + currentAmmoLoaded);
        weaponText.SetText(_firingSystemManager.currentActiveWeapon.GetName());
       // completionText.SetText("Completion: 0%");
       
    }

    private void ChangeCompletionPercent()
    {
        Debug.Log("I reached the changeCompletion");
        completionSys.enemyDied++;
        SetCompletionText();
    }

    private void SetBackHealthColor()
    {
        healthText.color = new Color(255, 72, 255, 1);
    }
    
    public void SetHealthText()
    {
        if (TMPplayer.health > 0)
        {
            Debug.Log("HP: " + TMPplayer.health);
            currentHealth = (int)TMPplayer.health;
            healthText.color = new Color(0, originalColor.g, originalColor.b);
            Invoke("SetBackHealthColor",0.05f);
            healthText.SetText(TMPplayer.health.ToString());
        }
        else
        {
            healthText.SetText("0");
        }
        
    }

    public void AddToHealth(short q)
    {
        currentHealth += q;
        healthText.SetText(currentHealth.ToString());
    }
    

    public void SetAmmoText()
    {
        ammoText.SetText(gun.weaponMagazine.ToString());
    }

    public void SetCompletionText()
    {
        float calculatedPercent = completionSys.CalculatePercent();
        if (completionSys.enemyDied == completionSys.startManager.enemyNum)
        {
            popupText.SetText("Survived part");            
        }
        completionText.SetText($"{calculatedPercent.ToString("0")}%");
    }


}
