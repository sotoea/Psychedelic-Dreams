using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
	public GameObject spike;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int rand = Random.Range(0, 500);
		if(rand == 3){
			Instantiate(spike,new Vector3(transform.position.x + Random.Range(-5, 5),transform.position.y + Random.Range(-5, 5),transform.position.z + Random.Range(-5, 5)), transform.rotation);
		}
	}
}
