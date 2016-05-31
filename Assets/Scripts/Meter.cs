using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	private float _progress;
	[SerializeField] bool _startFull;
	public float progress{
		get{
			return _progress;
		
		}
		set{
			_progress = value;
			SpriteRenderer rend = GetComponent<SpriteRenderer>();
			//rend.material.SetFloat("_Cutoff", 1.0001f-value);
			GetComponent<Renderer>().material.SetFloat("_Cutoff", 1.0001f-value);
		}
	}
	// Use this for initialization
	void Start () {
		if(_startFull)
			progress=1.0f;
		else
			progress = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 inverseLook  = transform.InverseTransformVector (transform.position-Camera.main.transform.position );
//		transform.localRotation = Quaternion.LookRotation (inverseLook);
//		transform.LookAt (Camera.main.transform.position);

		//progress +=.01f;
	}
}
