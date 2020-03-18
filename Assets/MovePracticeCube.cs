using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePracticeCube : MonoBehaviour {

    [SerializeField] private float unitPerSecond = 5;

    // Start is called before the first frame update
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        // Input.GetKey(KeyCode.A)
        // Vector3.right
        // transform.position
        var translation = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        translation *= Time.deltaTime * unitPerSecond;
        transform.Translate(translation);
    }

}
