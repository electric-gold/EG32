using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    [SerializeField]
    private GameObject _CurrentGun;
    [SerializeField]
    private GameObject _CurrentKnife;
    [SerializeField]
    private GameObject _CurrentSuperpower;
    public GameObject SelectedItem;
    public int SelectionStatus = 1;

    void Start()
    {
        SelectedItem = _CurrentGun;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SelectionStatus++;
            if (SelectionStatus == 1)
            {
                SelectedItem = _CurrentGun;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(true);
                _CurrentSuperpower.SetActive(false);
            }
            else if (SelectionStatus == 2)
            {
                SelectedItem = _CurrentKnife;
                _CurrentKnife.SetActive(true);
                _CurrentGun.SetActive(false);
                _CurrentSuperpower.SetActive(false);
            }
            else if (SelectionStatus == 3)
            {
                SelectedItem = _CurrentSuperpower;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(false);
                _CurrentSuperpower.SetActive(true);
            } if (SelectionStatus > 3)
            {
                SelectionStatus = 1;
                SelectedItem = _CurrentGun;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(true);
                _CurrentSuperpower.SetActive(false);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SelectionStatus--;
            if (SelectionStatus == 1)
            {
                SelectedItem = _CurrentGun;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(true);
                _CurrentSuperpower.SetActive(false);
            }
            else if (SelectionStatus == 2)
            {
                SelectedItem = _CurrentKnife;
                _CurrentKnife.SetActive(true);
                _CurrentGun.SetActive(false);
                _CurrentSuperpower.SetActive(false);
            }
            else if (SelectionStatus == 3)
            {
                SelectedItem = _CurrentSuperpower;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(false);
                _CurrentSuperpower.SetActive(true);
            }
            if (SelectionStatus < 1)
            {
                SelectionStatus = 3;
                SelectedItem = _CurrentSuperpower;
                _CurrentKnife.SetActive(false);
                _CurrentGun.SetActive(false);
                _CurrentSuperpower.SetActive(true);
            }
        }
    }
}
