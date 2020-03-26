using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ViveController : MonoBehaviour {

    public SteamVR_Action_Boolean playerAction;
    public Hand hand;
    public GameObject weapon, ammunition;

    private void OnEnable() {
        if (hand == null)
            hand = GetComponent<Hand>();
        if (playerAction == null)
            return;
        playerAction.AddOnChangeListener(OnPlayerActionChange, hand.handType);
        weapon.transform.parent = hand.transform;
        weapon.transform.localPosition = new Vector3(0.012f, -0.04f, -0.06f);
        weapon.transform.localEulerAngles = new Vector3(-145, 0, 0);
    }

    private void OnDisable() {
        if (playerAction != null)
            playerAction.RemoveOnChangeListener(OnPlayerActionChange, hand.handType);
    }

    private void OnPlayerActionChange(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources, bool newValue) {
        if (newValue)
            Instantiate(ammunition, weapon.transform.position, weapon.transform.rotation);
    }

}
