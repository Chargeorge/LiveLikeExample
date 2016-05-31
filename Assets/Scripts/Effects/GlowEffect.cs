using UnityEngine;
using System.Collections;

public class GlowEffect : EffectBase {

	private bool _baseColor =true;
 public Color basicColor;
 public Color overColor; 
 private Material _baseMat;
 public float colorChangeRate = .1f;
	// Use this 	for initialization
	void Start () {
		_baseMat = GetComponent<Renderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(!_baseColor){
			_baseMat.SetColor("_EmissionColor",Color.Lerp(_baseMat.GetColor("_EmissionColor"), overColor, colorChangeRate));
			_baseMat.color = Color.Lerp(_baseMat.color, overColor, colorChangeRate);
		}
		else{
			_baseMat.SetColor("_EmissionColor",Color.Lerp(_baseMat.GetColor("_EmissionColor"), basicColor, colorChangeRate));
			_baseMat.color = Color.Lerp(_baseMat.color, basicColor, colorChangeRate);
		}
	}

	public override void Activate(EventData ed){
		Debug.Log("Base coloring!");
		_baseColor = !_baseColor;
	}
}
