using UnityEngine;
using System.Collections;

//Constantly fires raycasts, if it hits it sends over to the trigger
public class RaycastCondition : ConditionBase {
	public Vector3 localDirection;

	// Use this for initialization
	void  Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(transform.position,transform.forward,out _hit,maxDistance_UU,layersToHit)){
			if(_hit.collider.GetComponent<HoverTrigger>() != null){

						EventData ed = new EventData();
						ed.hitData = _hit;
						ed.sender = this.gameObject;
						_hit.collider.GetComponent<HoverTrigger>().over(ed);
					}
			}
	}
}
