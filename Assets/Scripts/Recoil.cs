using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public GameObject Gun;
    public Camera MainCam;
    public static bool RecoilCheck = false;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            RecoilWait();
        }
    }
    void RecoilWait()
    {
        RecoilCheck = true;
        MainCam.transform.RotateAround(MainCam.transform.position, Vector3.left, Random.Range(80f, 90f) * Time.deltaTime);
        RecoilCheck = false;
    }
}
