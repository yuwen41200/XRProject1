using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : MonoBehaviour {

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

}
