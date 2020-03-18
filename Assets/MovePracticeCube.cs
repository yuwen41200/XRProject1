using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePracticeCube : MonoBehaviour {

    public Vector3 currentPosition;

    // Start is called before the first frame update
    void Start() {
        //currentPosition = new Vector3(2, 4, 6);
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            currentPosition.x -= 0.01f;
        }
        if (Input.GetKey(KeyCode.D)) {
            currentPosition.x += 0.01f;
        }
        if (Input.GetKey(KeyCode.W)) {
            currentPosition.z += 0.01f;
        }
        if (Input.GetKey(KeyCode.S)) {
            currentPosition.z -= 0.01f;
        }
        transform.position = currentPosition;
    }

}
