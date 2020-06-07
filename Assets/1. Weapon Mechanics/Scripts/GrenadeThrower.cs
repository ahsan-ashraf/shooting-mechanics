using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

    public float ThrowForce = 25.0f;
    public GameObject GrenadePrefab;
    public Transform ThrowPoint;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ThrowGrenade();
        }
    }
    private void ThrowGrenade() {
        GameObject grenade = Instantiate(GrenadePrefab, ThrowPoint.position, ThrowPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(ThrowPoint.forward * ThrowForce, ForceMode.VelocityChange);
    }
}
