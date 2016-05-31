using UnityEngine;
using System.Collections;

public class GenericTrigger : MonoBehaviour {

	[SerializeField]
	private float totalTime;

	private EventData _lastData;

	public float TotalTime {
		get {
			return totalTime;
		}
		set {
			totalTime = value;
		}
	}

	private float _timeLeft;
	public float TimeLeft {
		get {
			return _timeLeft;
		}
	
	}

	public int exitFrameBuffer= 5;

	[SerializeField]
	private float coefRestoreRate;
	public float CoefRestoreRate {
		get {
			return coefRestoreRate;
		}
		set {
			coefRestoreRate = value;
		}
	}
	public bool disableOnTrigger;
	private float framesSinceLastOver;
	private bool doIncrement  = true;

	public GameObject[] overrideTargets;
	public bool showMeter = true;
	public Meter overideMeter;

	private bool _isActive  = true;

	public bool isActive {
		get {
			return _isActive;
		}
		set{
			_isActive = value;
		}
	}

	private bool _toggledLastFrame = false;

	private Meter meter;
	// Use this for initialization
	void Start () {
	 if(totalTime ==0) totalTime =.01f; //Fix issue with 0 based time;
		_timeLeft = totalTime;

			meter = overideMeter;

		if (meter == null) {
			showMeter = false;
		}

	}

	void Update () {

	 //Do increment: Trigger is inactive
		if(doIncrement){
			_timeLeft = Mathf.MoveTowards(TimeLeft, TotalTime, Time.deltaTime * coefRestoreRate);  	
			if(framesSinceLastOver ==exitFrameBuffer){
				overEnd();
			}
			framesSinceLastOver++;
			if(showMeter){
				meter.progress = .99f-TimeLeft/TotalTime;
			}

		}


		else{
			decrementTime();
			if(showMeter){

				meter.progress = .99f-TimeLeft/TotalTime;

			}
			doIncrement = true;
			framesSinceLastOver = 0;

		}

		if (_toggledLastFrame) {
			if(coefRestoreRate == 0){
				_timeLeft = TotalTime;
				if(showMeter && overideMeter ==null){
				
					meter.gameObject.SetActive(false);
				}
			}
			
			_toggledLastFrame = false;
		}

	}

	void decrementTime(){
		float timeLeftPrev = _timeLeft;
		_timeLeft = Mathf.MoveTowards(TimeLeft, 0, Time.deltaTime );
		if((TimeLeft == 0 && timeLeftPrev > 0) || (totalTime == 0)){

			toggle();
			_toggledLastFrame = true;
		}

	}

	//Finds the proper target and enables it.  
	public void toggle(){

		if (disableOnTrigger) {
			this.enabled = false;
		}

			if(this.gameObject.GetComponent<EffectBase>()){
				activateAll(gameObject);
		}				
	
			foreach(GameObject go in overrideTargets){
//				Debug.Log("Hitting me allllll the time");
				activateAll(go);
		}
	}
	
	public void over(EventData ed){
		if (isActive) {
			doIncrement = false;
			if (framesSinceLastOver > exitFrameBuffer) {
				overStart ();
			}
			_lastData = ed;
		}
	}

	private void activateAll(GameObject go){
	 if(go == null) return;
		foreach (EffectBase tb in go.GetComponents<EffectBase>()) {
			tb.Activate(_lastData);
		}
	}

	private void overStart(){

		if(showMeter){

			meter.gameObject.SetActive(true);
			meter.progress = TimeLeft/TotalTime;

		}
	}

	private void overEnd(){
		if(showMeter && overideMeter == null){

			meter.gameObject.SetActive(false);
				}

	}

	
}
