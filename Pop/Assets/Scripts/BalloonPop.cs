using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPop : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
	
			Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3(touch.position.x, touch.position.y, 0));
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
			if (hit)
				if(touch.phase == TouchPhase.Began){
					this.GetComponent<AudioSource>().Play();
					hit.collider.gameObject.SetActive(false);
				}
		}
	}
}
