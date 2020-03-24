using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot2 : MonoBehaviour
{
    private AudioSource audiogunshot;

    // Start is called before the first frame update
    void Start()
    {
        audiogunshot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audiogunshot.Play();
        }
    }
}
