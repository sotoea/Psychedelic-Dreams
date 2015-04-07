#pragma strict

function Start () {
 var someNumber : float;
 someNumber = 5.0;
 animation.Play("shoot");
 animation["shoot"].speed = someNumber;
}

