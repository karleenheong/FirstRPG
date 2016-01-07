using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    private float timeToChangeDirection;
    private float startMoveTime;
    private float startTime;
    private bool chasing;
    private bool movingForward;


	void Start () {

        GameObject collidedEnemy = GameObject.Find(GameData.GetCollidedEnemy());
        if (GameData.GetCollidedEnemy() != null)
        {
            Destroy(collidedEnemy);
        }

        player = FindObjectOfType<PlayerController>();
        startMoveTime = Time.time;
        chasing = false;
        movingForward = true;
        timeToChangeDirection = Random.Range(2f, 8f);
       
	}
	
	void Update () {
        if (!chasing)
        {
            if (movingForward)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            if(!movingForward)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            if (Time.time - startMoveTime > timeToChangeDirection)
            {
                movingForward = !movingForward;
                startMoveTime = Time.time;
            }
        }
        else //chasing
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 5f)
            {
                chasing = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            chasing = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            GameData.SavePlayerPos(player.transform.position);
            GameData.SetCollidedEnemy(this.name);
            Application.LoadLevel("02 Battle Screen");
        }
    }





}
