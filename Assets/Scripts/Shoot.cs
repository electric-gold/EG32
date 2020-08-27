using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public float Damage = 24f;
    public float range = 100f;
    public Camera fpsCam;
    public Text DamageUI;
    public GameObject Enemy;
    public static float EnemyHealth = 100;
    public ParticleSystem particleLaunch;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
                RaycastHit HitInfo;
                particleLaunch.Emit(1);
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out HitInfo, range) && HitInfo.transform.tag != "Player")
                {
                    if (HitInfo.collider.gameObject == Enemy)
                    {
                        Damage = Random.Range(23f, 28f);
                        EnemyHealth -= Damage;
                        Debug.Log(EnemyHealth);
                    }
                }
            } else if (Reload.ShootGunEnabled == false)
            {
                // Nothing!
            }
        }
    }
}