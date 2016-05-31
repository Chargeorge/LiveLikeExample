using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	RaycastHit _hit;
	public GameObject crossHairQuad;

//Settings	
		public float defaultDistance;  //The initial Distance, if not colliding is used as the total Distance _UU means the measurement is in UnityUnits
		public float maxDistance;    //Max Distance for the crosshair
		public bool CheckCollision;  //Should the crosshair rest on objects in the scene?
		public LayerMask AvoidSelfCollision; //
		public float hitOffSetDistance = .99f;


		void Start () {
			UnityEngine.Cursor.visible = true;
			if(crossHairQuad == null){
				throw new UnityException("Missing Crosshair Quad");
			}

		//Just in case someone forgot to parent the crosshair and position properly
		crossHairQuad.transform.parent = this.transform;
		crossHairQuad.transform.localPosition = (Vector3.forward * defaultDistance) ;
	}
	
	// Update is called once per frame
	void Update () {

		if(CheckCollision){
			if(Physics.Raycast(transform.position  ,transform.forward,out _hit,maxDistance,AvoidSelfCollision)){
				crossHairQuad.transform.localPosition = (Vector3.forward * _hit.distance) * hitOffSetDistance ;

			}
			else{
				crossHairQuad.transform.localPosition = (Vector3.forward * maxDistance);
			}
		}
		else{
			crossHairQuad.transform.localPosition = (Vector3.forward * defaultDistance);
		}
	}

}
