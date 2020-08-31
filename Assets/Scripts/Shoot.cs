using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public float Damage = 24f;
    public float range = 25f;
    public Camera fpsCam;
    public Text DamageUI;
    public GameObject Enemy;
    public float speed = 20f;
    public float StayThere;
    public static float EnemyHealth = 100;
    public GameObject bulletModel;
    public GameObject bulletSpawn;
    [SerializeField]
    private Transform _brrr;
    [SerializeField]
    private bool _bulletpos;
    public SphereCollider bulletDetector;
    int holder = 0;
    float FinalMouseX;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*Destroy(bulletModel);*/
            _bulletpos = true;
            ShootWeapon();
        }
    }
    void ShootWeapon()
    {
        if (Reload.CurrentMag == 0 && Reload.AllMags == 0)
        {
            
        }
        else
        {
            if (Reload.ShootGunEnabled == true)
            {
                RaycastCheck();
            }
            else if (Reload.ShootGunEnabled == false)
            {
                // Nothing!
            }
        }
    }
    void RaycastCheck()
    {
        Instantiate(bulletModel, bulletModel.transform.parent, false);
        _bulletpos = false;
        BulletBoom();
        RaycastHit HitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward * Time.deltaTime, out HitInfo, range) && HitInfo.transform.tag != "Player")
        {
            if (HitInfo.collider.gameObject == Enemy)
            {
                Damage = Random.Range(23f, 28f);
                EnemyHealth -= Damage;
                Debug.Log(EnemyHealth);
                Destroy(bulletModel);
                _bulletpos = false;
            }
            else
            {
                _bulletpos = false;
            }
        }
    }
    void BulletBoom()
    {
        holder = 0;
        while (holder < range && _bulletpos == false)
        {
            XPositionFix.Instance.XPos = FinalMouseX;
            StayThere = XPositionFix.Instance.XPos;
            bulletModel.transform.Translate(StayThere, 0f, speed * Time.deltaTime);
            holder++;            
        }
        if (holder == range)
        {
            Debug.Log("Holder = Range");
            _bulletpos = true;
        }
    }
}