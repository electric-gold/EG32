using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public static int CurrentMag;
    public static int AllMags;
    public static bool ShootGunEnabled = true;
    public GameObject SelectedGun;
    public Text ReloadGunText;
    // Start is called before the first frame update
    void Start()
    {
        if (SelectedGun.transform.name == "M9" && SelectedGun.transform.tag == "Gun")
        {
            CurrentMag = 15;
            AllMags = 45;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CurrentMag > 0 && AllMags > -15)
        {
            CurrentMag--;
            ReloadGunText.text = CurrentMag + "/" + AllMags;
            if (CurrentMag == 15 && AllMags == -15)
            {
                ReloadGunText.text = "0/0";
                ShootGunEnabled = false;
            }
        }
        else if (CurrentMag <= 0 && AllMags > -15)
        {
            ReloadGun();
        }
        if (CurrentMag == 15 && AllMags == -15)
        {
            ShootGunEnabled = false;
        } else {
            ReloadGunText.text = CurrentMag + "/" + AllMags;
        }
    }
    void ReloadGun()
    {
        CurrentMag = 15;
        AllMags -= CurrentMag;
        if (CurrentMag == 15 && AllMags == -15)
        {
            ReloadGunText.text = "0/0";

        }
    }
}
