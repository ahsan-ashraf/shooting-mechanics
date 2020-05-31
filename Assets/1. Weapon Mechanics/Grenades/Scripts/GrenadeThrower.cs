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
        Vector3 position = transform.position;
        position.y -= 0.37f;
        GameObject grenade = Instantiate(GrenadePrefab, position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * ThrowForce, ForceMode.VelocityChange);
    }
}
