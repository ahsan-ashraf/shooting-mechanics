using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float Damage = 10.0f;
    public float Range = 100.0f;
    public float FireRate = 15f;
    public float ImpactForce = 40.0f;
    
    public Camera FpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private float NextTimeToFire = 0.0f;

    private void Update() {

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire) {
            NextTimeToFire = Time.time + 1 / FireRate;
            Shoot();
        }

    }
    private void Shoot() {
        //MuzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, Range)) {
            hit.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
            GameObject impactEffect = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 1.5f);
        }
    }
}
