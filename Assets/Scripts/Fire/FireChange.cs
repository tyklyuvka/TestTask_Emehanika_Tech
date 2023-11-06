using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChange : MonoBehaviour {
    public Action<int> FireChangeAction;
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Water")) {
            FireChangeAction?.Invoke(-1);
        }
        else if (collider.gameObject.CompareTag("Fire")) {
            FireChangeAction?.Invoke(1);
            StartCoroutine(ShowObject(collider.gameObject));
        }
    }

    private IEnumerator ShowObject(GameObject hideCollider){
        hideCollider.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f); 
        hideCollider.gameObject.SetActive(true);
    }
}
