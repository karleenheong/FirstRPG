using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    static Vector3 playerPosition;
    static string collidedEnemy;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static void SavePlayerPos(Vector3 pos)
    {
        playerPosition = pos;
    }


    public static Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }


    public static void SetCollidedEnemy(string enemy)
    {
        collidedEnemy = enemy;
    }

    public static string GetCollidedEnemy()
    {
        return collidedEnemy;
    }
}
