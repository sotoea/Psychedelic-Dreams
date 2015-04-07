using UnityEngine;
using System.Collections;

public class Controller2 : MonoBehaviour {

	private bool highAllTheTime = false;
	public Rigidbody bullet;
	public GameObject goal;
	public int health = 100;
	public GameObject gun;

	public Collider spikes;

	void OnGUI(){
		GUI.Label(new Rect(20, 20, 500, 30),"Health = " + health);
	}
	// Use this for initialization
	void Start () {
	
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update(){
		if(health<=0){
			Application.LoadLevel("lvl2");
		}
		if(transform.position.x<3.8&&transform.position.x>3.4&&transform.position.z<13.8&&transform.position.z>13.4){
			highAllTheTime = true;
		}
		if(highAllTheTime){
			transform.Translate(Vector3.up*Time.deltaTime*100);
			if(transform.position.y>100){
				Application.LoadLevel("lvl3_001");
			}
		}
		//Screen.lockCursor = true;
		if(transform.position.y <-25){
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if(Input.GetKey("escape"))
			Application.Quit();
		
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Rigidbody clone;
			clone = Instantiate(bullet, transform.position+(new Vector3(0,0,0.2f)), transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 50);
			GameObject.FindWithTag("braingun").animation.Play("shoot");
			GameObject.Find("brain_gun").animation.Play("shoot");
			//transform.GetChild(1).animation.Play("shoot");
			gun.animation.Play("shoot");

		}

		StartCoroutine(Example());
	}

	IEnumerator Example() {	
		yield return new WaitForSeconds(2); //this will wait 5 seconds 
		Destroy(spikes.gameObject);
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.name == "SpikedMace1(Clone)"){
			//rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
			collision.animation.Play("dddd");
			spikes = collision;
			health -= Random.Range(0, 10) + 10;
			Example();
		}
	}
}