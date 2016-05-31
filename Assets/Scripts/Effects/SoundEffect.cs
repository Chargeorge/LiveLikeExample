using UnityEngine;
using System.Collections;

public class SoundEffect : EffectBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate(EventData ed){
		GetComponent<AudioSource>().Play();
	}

}
