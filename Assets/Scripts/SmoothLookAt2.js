var target : Transform;
var damping = 0.3;

@script AddComponentMenu("Camera-Control/Smooth Look At")

function LateUpdate () {

		target = GameObject.FindGameObjectWithTag("GameController").transform;

	if (target) {
		// Just lookat
	    transform.LookAt(target);
	    transform.Translate(Vector3.forward*damping);

	}
}

function Start () {
		
	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

//0.2699733
//-0.3750401
//0.8464203

//353.8616
//353.0341
//8.175507

//1.389517
//0.579834