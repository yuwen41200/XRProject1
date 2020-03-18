using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBullet : MonoBehaviour {

    private void Update() {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
