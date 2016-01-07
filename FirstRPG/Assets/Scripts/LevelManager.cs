using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.timeSinceLevelLoad >= 2f)
        {
            Application.LoadLevel(1);
        }
	}
}
