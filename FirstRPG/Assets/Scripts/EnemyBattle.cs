using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBattle : MonoBehaviour {

    public int maxHealth;
    public float atbSpeed;
    public float atbMax;
    public int attackDamage;
    public RectTransform healthTransform;

    private PlayerBattle playerBattle;
    private Text hpText;
    private float currentATB;
    private float yPos;
    private int currentHealth;
    private float maxXPos;

    // Use this for initialization
    void Start () {
        playerBattle = FindObjectOfType<PlayerBattle>();
        hpText = GameObject.Find("EnemyHPGauge").GetComponent<Text>();
        healthTransform = GameObject.Find("EnemyHPBar").GetComponent<RectTransform>();
        currentATB = atbMax;
        currentHealth = maxHealth;
        yPos = healthTransform.position.y;
        maxXPos = healthTransform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateATB();
        hpText.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            Application.LoadLevel("01 Level 1");
        }
        if (currentATB >= 1f)
        {
            Attack();
        }
	}

    private void Attack()
    {
       playerBattle.TakeDamage(5);
       currentATB -= 1;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float increment = healthTransform.rect.width / maxHealth;   //how many units per HP
        float positionDifference = (maxHealth - currentHealth) * increment;
        float newPosX = maxXPos - positionDifference;
        healthTransform.position = new Vector2(newPosX, yPos);
    }

    private void UpdateATB()
    {
        //clamp atb
        if (currentATB < 0f) { currentATB = 0f; }
        if (currentATB > atbMax) { currentATB = atbMax; }

        //refill atb gauge
        if (currentATB < 5f)
        {
            currentATB += atbSpeed * Time.deltaTime;
        }

       
    }
}
