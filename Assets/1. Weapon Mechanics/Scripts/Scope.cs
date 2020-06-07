using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

    public Animator Anim;
    public Camera WeaponCamera;
    public GameObject CrossHair;
    public GameObject ScopeOverlay;
    public float ScopedFOV = 15f;

    private bool ScopedIn;
    private float NormalFOV;
    private Camera MainCamera;

    private void Start() {
        MainCamera = Camera.main;
        NormalFOV = MainCamera.fieldOfView;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire2")) {
            ScopedIn = !ScopedIn;
            CrossHair.SetActive(!ScopedIn);
            Anim.SetBool("ScopedIn", ScopedIn);
            if (ScopedIn)
                StartCoroutine(ScopeIn());
            else
                ScopeOut();
        }
    }
    private IEnumerator ScopeIn() {
        yield return new WaitForSeconds(.25f);
        ScopeOverlay.SetActive(ScopedIn);
        MainCamera.fieldOfView = ScopedFOV;
        WeaponCamera.gameObject.SetActive(!ScopedIn);
    }
    private void ScopeOut() {
        ScopeOverlay.SetActive(ScopedIn);
        MainCamera.fieldOfView = NormalFOV;
        WeaponCamera.gameObject.SetActive(!ScopedIn);
    }
}
