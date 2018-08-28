using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawns : MonoBehaviour {
	public GameObject cloud;
	public List<Sprite> cloudSprites;
	public const int cloudMax = 10;
	private List<GameObject> cloudPool = new List<GameObject>();
	// Use this for initialization
	void Start () {
		cloudPool = new List<GameObject>();
		for(int i = 0; i < cloudMax; i++){
			GameObject temp = (GameObject)Instantiate(cloud);
			temp.SetActive(false);
			temp.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0,cloudSprites.Capacity)];
			cloudPool.Add(temp);
		}
		InvokeRepeating("SpawnCloud", 6.0f, 2.0f);
	}

	void SpawnCloud(){
		for(int i = 0; i < cloudMax; i++){
			if(!cloudPool[i].activeInHierarchy){
				cloudPool[i].SetActive(true);
				Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
				cloudPool[i].transform.SetPositionAndRotation(new Vector2(transform.position.x,screenPosition.y),this.transform.rotation);
				cloudPool[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0.5f,1f),0);
				break;
			}
		}
	}
}
