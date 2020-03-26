using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractBullet : MonoBehaviour {

    public GameObject attackEffect;
    private Vector3 moveDirection;
    private AudioSource triggerSound;

    private void Awake() {
        moveDirection = new Vector3(0, 0, -1);
        transform.Translate(moveDirection * 0.2f);
        triggerSound = GetComponent<AudioSource>();
        triggerSound.Play();
        if (GameObject.FindWithTag("Enemy") == null)
            StartCoroutine(LoadEndScene());
    }

    private void Update() {
        transform.Translate(moveDirection * Time.deltaTime * 8f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.root.name == "Player" || other.name.StartsWith("Bullet"))
            return;
        Debug.Log("Bullet collided with " + other.name);
        if (other.CompareTag("Enemy"))
            AttackEnemy(other);
        Destroy(gameObject);
    }

    private void AttackEnemy(Collider enemy) {
        GameObject attackEffectClone = Instantiate(attackEffect, enemy.transform.position, Quaternion.identity);
        Destroy(enemy.gameObject, 0.25f);
        Destroy(attackEffectClone, 16);
    }

    IEnumerator LoadEndScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FinalScene");
        while (!asyncLoad.isDone)
            yield return null;
    }

}
