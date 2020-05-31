using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int Health = 100;

    private void TakeDamage(int amount) {
        Health -= amount;
        if (Health <= 0) {
            Die();
        }
    }
    private void Die() {
        Destroy(gameObject);
    }

}
