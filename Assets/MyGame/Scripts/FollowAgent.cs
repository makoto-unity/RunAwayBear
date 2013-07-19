using UnityEngine;
using System.Collections;

public class FollowAgent : MonoBehaviour {

	// public GameObject			particle; // omit
	protected NavMeshAgent		agent;
	protected Animator			animator;

	protected Locomotion locomotion;
	// protected Object particleClone; // omit

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);

		// particleClone = null; // omit
	}

	//protected void SetDestination()
	//{
	//      :           omit all 
	//}
	
	
	protected void SetupAgentLocomotion()
	{
		if (AgentDone())
		{
			locomotion.Do(0, 0);
			// if (particleClone != null)
			// {
			// 	GameObject.Destroy(particleClone);
			// 	particleClone = null;
			// }
		}
		else
		{
			float speed = agent.desiredVelocity.magnitude;

			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;

			float angle = Mathf.Atan2(velocity.x, velocity.z) * 180.0f / 3.14159f;

			locomotion.Do(speed, angle);
		}
	}

    void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}
	
	void OnTriggerStay(Collider other) 
	{
		if ( this.enabled == false ) return;
		Vector3 dir = this.transform.position - other.transform.position;
		Vector3 pos = this.transform.position + dir * 0.5f;
		agent.destination = pos;
	}

	// Update is called once per frame
	void Update () 
	{
		//if (Input.GetButtonDown ("Fire1")) 
		//	SetDestination();

		SetupAgentLocomotion();
	}
}
