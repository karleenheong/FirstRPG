using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotateSpeed;

  
	// Use this for initialization
	void Start () {
        
        if (GameData.GetPlayerPosition() != new Vector3(0f,0f,0f))
        {
            transform.position = GameData.GetPlayerPosition();
           
        }
       
        
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        */
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }
}
