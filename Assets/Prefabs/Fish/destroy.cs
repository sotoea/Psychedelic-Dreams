using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
	public GameObject fishPlane;
	public Collider spikes;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		StartCoroutine(Example());

		if(transform.position.y<-20)
			Destroy(this.gameObject);
	}

	IEnumerator Example() {	
		yield return new WaitForSeconds(1); //this will wait 5 seconds 
		Destroy(spikes.gameObject);
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.name == "fish_02"){
		rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
		collision.animation.Play("Death");
		Instantiate(fishPlane,collision.transform.position-(new Vector3(1.85f,-0.5f,0f)), Quaternion.Euler(0,0,0));
			fishPlane.transform.parent = collision.transform;
			//collision.SendMessage("changeMove");
		}

		if(collision.name == "SpikedMace1(Clone)"){
			rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
			collision.animation.Play("dddd");
			spikes = collision;
			Example();
		//	Destroy(collision.gameObject);
			//fishPlane.transform.parent = collision.transform;
			//collision.SendMessage("changeMove");
		}
		
	}
}
