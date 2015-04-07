using UnityEngine;
using System.Collections;

public class destroy2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void Update () {
		if(transform.position.y<-20)
			Destroy(this.gameObject);
	}
	void OnTriggerEnter(Collider collision) {
		if(collision.name == "Spiked Mace 1"){
			rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
			collision.animation.Play("spikyDeath");
			//fishPlane.transform.parent = collision.transform;
			//collision.SendMessage("changeMove");
		}
		
	}
}
