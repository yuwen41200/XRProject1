using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ViveController : MonoBehaviour {

    public SteamVR_Action_Boolean playerAction;
    public Hand hand;
    public GameObject obj;

    private void OnEnable() {
        if (hand == null)
            hand = GetComponent<Hand>();
        if (playerAction == null)
            return;
        playerAction.AddOnChangeListener(OnPlayerActionChange, hand.handType);
    }

    private void OnDisable() {
        if (playerAction != null)
            playerAction.RemoveOnChangeListener(OnPlayerActionChange, hand.handType);
    }

    private void OnPlayerActionChange(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources, bool newValue) {
        if (newValue)
            Instantiate(obj, hand.transform.position, hand.transform.rotation);
    }

}
