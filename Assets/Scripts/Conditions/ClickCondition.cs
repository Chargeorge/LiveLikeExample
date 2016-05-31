using UnityEngine;
using System.Collections;

public class ClickCondition : ConditionBase {
 // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			if(Physics.Raycast(transform.position,transform.forward,out _hit,maxDistance_UU,layersToHit)){
				if(_hit.collider.GetComponent<ClickTrigger>() != null){
						EventData ed = new EventData();
						ed.hitData = _hit;
						ed.sender = this.gameObject;
						_hit.collider.GetComponent<ClickTrigger>().over(ed);
					}
				}
		}
	}
}
