using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetScore : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
	}
}
