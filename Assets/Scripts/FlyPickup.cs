using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {
		
		//If the Collider other is tagged with "Player"
		if (other.CompareTag ("Player")) {

			//...add the pickup particles at the location of the fly...
			//Note: pickupPrefab is the magical dust, transform.position gets the position 
			//of the fly, Quaternion.identity means no rotation.
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

			//...decrement the total number of flies...
			FlySpawner.totalFlies--;

			//...update the score
			ScoreCounter.score++;

			//...destroy this fly
			Destroy (gameObject);
			
		}
	}
}
