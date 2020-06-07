using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public bool Autometic;
    public float Damage = 10.0f;
    public float Range = 100.0f;
    public float FireRate = 15f;
    public float ImpactForce = 40.0f;

    public float MaxAmmo;
    public float ReloadDelay;
    private float CurrentAmmo;
    private bool Reloading;
    
    public Animator Anim;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    public Transform ShootPoint;

    private float NextTimeToFire = 0.0f;

    private void Start() {
        CurrentAmmo = MaxAmmo;
    }

    private void OnEnable() {
        Reloading = false;
        Anim.SetBool("Reloading", false);
    }

    private void Update() {
        
        if (Reloading)
            return;
        
        if (CurrentAmmo <= 0) {
            StartCoroutine(Reload());
            return;
        }
        if (Autometic) {
            if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire) {
                NextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        } else {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }

    }
    private void Shoot() {
        //MuzzleFlash.Play();
        CurrentAmmo -= 1;
        RaycastHit hit;
        if (Physics.Raycast(ShootPoint.transform.position, ShootPoint.transform.forward, out hit, Range)) {
            hit.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
            Debug.Log(hit.transform.name);
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
            GameObject impactEffect = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 1.5f);
        }
    }
    private IEnumerator Reload() {
        Reloading = true;
        Anim.SetBool("Reloading", true);
        yield return new WaitForSeconds(ReloadDelay- .3f);
        Anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(.3f);
        CurrentAmmo = MaxAmmo;
        Reloading = false;
    }
}
