using UnityEngine;
using System.Collections;

public class ChangeRagdoll : MonoBehaviour {

	public float forceDegree = 1.0f;

	void OnCollisionEnter(Collision collision) 
	{
		GetComponent<Animator>().enabled = false;
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<FollowAgent>().enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<SphereCollider>().enabled = false;
		
		Vector3 vec = collision.impactForceSum;
		float mag = vec.magnitude;
		vec.Normalize();
		vec.y += 0.5f;
		vec.Normalize();
		vec *= mag;
		
		Rigidbody [] ragdollRB = this.gameObject.GetComponentsInChildren<Rigidbody>();
		foreach( Rigidbody rb in ragdollRB ) {
			rb.isKinematic = false;
			rb.AddForce( vec * forceDegree, ForceMode.Impulse );
		}
		this.enabled = false;
	}
}
