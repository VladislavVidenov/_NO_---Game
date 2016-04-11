using UnityEngine;
using System.Collections;

public class KeyPickupScript : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.keysCollected++;
           // Debug.Log("key destroyed.");
            Destroy(gameObject);
        }
    }
}
