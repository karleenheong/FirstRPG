using UnityEngine;
using System.Collections;

public class BackWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision thing) {
        if (thing.gameObject.GetComponent<PlayerController>())
        {
            Application.LoadLevel("03 Win Screen");
        }
    }
}
