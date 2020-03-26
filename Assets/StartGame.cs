using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StartGame : MonoBehaviour {

    public SteamVR_Action_Boolean playerAction;
    public Hand hand;

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
            StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncLoad.isDone)
            yield return null;
    }

}
