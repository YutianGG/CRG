using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour {
	public UnityEvent OnEnter ;
	
	void OnTriggerEnter2D(Collider2D co){
		if(co.tag != "Player") return ;
  		OnEnter.Invoke() ;
	}
}
