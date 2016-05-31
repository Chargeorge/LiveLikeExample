using UnityEngine;
using System.Collections;

public class JumpEffect : EffectBase {
 public Vector3 jumpForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate(EventData ed){
		GetComponent<Rigidbody>().AddForce(jumpForce);
	}
}
