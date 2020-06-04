using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    private int SelectedWeapon = 0;

    private void Start() {
        SelectWeapon();
    }

    private void Update() {
        int previousSelectedWeapon = SelectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f) {
            if (SelectedWeapon >= transform.childCount - 1)
                SelectedWeapon = 0;
            else
                SelectedWeapon += 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f) {
            if (SelectedWeapon <= 0)
                SelectedWeapon = transform.childCount - 1;
            else
                SelectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            SelectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            SelectedWeapon = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            SelectedWeapon = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 5)
            SelectedWeapon = 4;

        if (previousSelectedWeapon != SelectedWeapon) {
            SelectWeapon();
        }
    }
    private void SelectWeapon() {
        int i = 0;
        foreach (Transform weapon in transform) {
            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
