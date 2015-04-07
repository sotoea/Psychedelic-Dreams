using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public GameObject cub;
	public GameObject sphere;
	public GameObject spike;

	private bool highAllTheTime = false;

	public Collider spikes;
	public int health = 100;

	public Rigidbody bullet;
	public GameObject gun;
	
	void OnGUI(){
		GUI.Label(new Rect(20, 20, 500, 30),"Health = " + health);
	}

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	

	// Update is called once per frame
	void Update(){

		if(health <= 0){
			Application.LoadLevel("Scene1");
		}
			

		if(highAllTheTime){
			transform.Translate(Vector3.up*Time.deltaTime*100);
			if(transform.position.y>150){
				Application.LoadLevel("lvl2");
			}
		}
		//Screen.lockCursor = true;
		if(transform.position.y <-25){
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKey("escape"))
			Application.Quit();

		if (Input.GetMouseButtonDown(1)){
			Rigidbody clone;
			clone = Instantiate(bullet, transform.position+(new Vector3(0,0,0.2f)), transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 50);
			GameObject.FindWithTag("braingun").animation.Play("shoot");
			GameObject.Find("brain_gun").animation.Play("shoot");
			//transform.GetChild(1).animation.Play("shoot");
			gun.animation.Play("shoot");
		}
		if (Input.GetMouseButtonDown(0)){ // if right button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){

				// the object identified by hit.transform was clicked
				// do whatever you want
				if(hit.transform.gameObject.name == "Button"){

					int rand = Random.Range(1, 5);

					hit.transform.gameObject.animation.Play("PushButton");
					Vector3 temp = new Vector3(Random.Range(-5f,5f), 10f, Random.Range(2.5f,10.5f));
					Quaternion temp2 = Quaternion.Euler(Random.Range(0f,90f),Random.Range(0f,90f),Random.Range(0f,90f));

					if(rand == 1) Instantiate(cub, temp, temp2);
					if(rand == 2) Instantiate(sphere, temp, temp2);
					if(rand > 2) Instantiate(spike, new Vector3(Random.Range(-5f,5f), 1f, Random.Range(2.5f,10.5f)), temp2);

				}else if(hit.transform.gameObject.name == "FinalButton"){
					if(transform.position.y > 11.5){
						hit.transform.gameObject.animation.Play("FinalPush");
						highAllTheTime = true;

					}
				}
			}
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
