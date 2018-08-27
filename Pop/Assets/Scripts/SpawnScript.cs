using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
	public int balloonMax = 100;
	public List<Sprite> balloonSprites;
    public GameObject balloon;
	private List<GameObject> balloonPool;
    // Use this for initialization
    void Start () {
		balloonPool = new List<GameObject>();
		for(int i = 0; i < balloonMax; i++){
			GameObject temp = (GameObject)Instantiate(balloon);
			temp.SetActive(false);
			temp.GetComponent<SpriteRenderer>().sprite = balloonSprites[Random.Range(0,balloonSprites.Capacity)];
			balloonPool.Add(temp);
		}
		InvokeRepeating("SpawnBalloon", 2.0f, 0.1f);
	}
	void SpawnBalloon(){
		for(int i = 0; i < balloonMax; i++){
			if(!balloonPool[i].activeInHierarchy){
			balloonPool[i].SetActive(true);
			Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
			balloonPool[i].transform.SetPositionAndRotation(new Vector2(screenPosition.x,this.transform.position.y),this.transform.rotation);
			break;
			}
		}
	}
}
