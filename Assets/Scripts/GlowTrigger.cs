using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GlowTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 private bool _baseColor =true;
 public Color baseColor;
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
		}
		else{

			_baseMat.SetColor("_EmissionColor",Color.Lerp(_baseMat.GetColor("_EmissionColor"), baseColor, colorChangeRate));
		}
	}

	public  void OnPointerEnter(PointerEventData pd){
		_baseColor = !_baseColor;

	}
	public  void  OnPointerExit(PointerEventData pd){
		
	}

}
