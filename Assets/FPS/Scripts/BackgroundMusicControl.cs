using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControl : MonoBehaviour
{
    private AudioSource background;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<AudioSource>();
        background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            background.Pause();
        }
    }
}
