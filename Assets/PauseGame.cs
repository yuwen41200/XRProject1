using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    private bool _isPaused;

    private void Start() {
        _isPaused = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Time.timeScale = _isPaused ? 1 : 0;
            _isPaused = !_isPaused;
        }
    }

}
