using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

    public float ThrowForce = 25.0f;
    public GameObject GrenadePrefab;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ThrowGrenade();
        }
    }
    private void ThrowGrenade() {
        GameObject grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * ThrowForce, ForceMode.VelocityChange);
    }
}
