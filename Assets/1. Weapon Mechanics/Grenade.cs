using UnityEngine;

public class Grenade : MonoBehaviour {

    public float Delay = 3.0f;
    public float ExplosionRadius = 20.0f;
    public float ExplosionForce = 10000.0f;
    public GameObject ExplosionEffect;
    
    private float CountDown = 0.0f;
    private bool Exploded = false;

    // Start is called before the first frame update
    void Start() {
        CountDown = Delay;
    }

    // Update is called once per frame
    void Update() {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0 && !Exploded) {
            Explode();
            Exploded = true;
        }
    }
    private void Explode() {
        GameObject explosionEffect = Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Destroy(explosionEffect, 2.0f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders) {
            collider.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
        }

        colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders) {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
            }
            collider.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
        }
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
