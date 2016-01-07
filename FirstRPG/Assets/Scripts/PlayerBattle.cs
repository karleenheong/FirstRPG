using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBattle : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public int maxHealth;
    public int maxATB;
    public float atbSpeed;
    public int attackDamage;
    public RectTransform healthTransform;
    public RectTransform atbTransform;

    private EnemyBattle enemyBattle;
    //ATB variables
    private Text atbText;
    private float yPosATB;
    private float currentATB;
    private float maxXPosATB;

    //HP variables
    private Text hpText;
    private float yPosHP;
    private int currentHealth;
    private float maxXPosHP;

    // Use this for initialization
    void Start()
    {
        enemyBattle = FindObjectOfType<EnemyBattle>();
        atbText = GameObject.Find("ATBGauge").GetComponent<Text>();
        hpText = GameObject.Find("HPGauge").GetComponent<Text>();
        healthTransform = GameObject.Find("HPBar").GetComponent<RectTransform>();
        atbTransform = GameObject.Find("ATBBar").GetComponent<RectTransform>();
        currentATB = maxATB;
        currentHealth = maxHealth;

        //Healthbar stuff
        yPosHP = healthTransform.position.y;
        maxXPosHP = healthTransform.position.x;
        //ATB stuff
        yPosATB = atbTransform.position.y;
        maxXPosATB = atbTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateATB();
        Movement();
        hpText.text = currentHealth.ToString();
        if(Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Blizzard();
        }
    }
    
    public void Attack()
    {
        if(currentATB >= 1)
        {
           enemyBattle.TakeDamage(5);
           currentATB -= 1;
        }
    }

    public void Blizzard()
    {
        if(currentATB >= 3)
        {
            enemyBattle.TakeDamage(12);
            currentATB -= 3;
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float increment = healthTransform.rect.width / maxHealth;   //how many units per HP
        float positionDifference = (maxHealth - currentHealth) * increment;
        float newPosX = maxXPosHP - positionDifference;
        healthTransform.position = new Vector2(newPosX, yPosHP);

        if (currentHealth <= maxHealth / 4)
        {
            Image healthBar = GameObject.Find("HPBar").GetComponent<Image>();
            healthBar.color = Color.red;
        }

        if (currentHealth <= 0)
        {
            Application.LoadLevel("04 Lose Screen");
        }
    }


    private void UpdateATB()
    {
        //clamp atb
        if (currentATB < 0f) { currentATB = 0f; }
        if (currentATB > maxATB) { currentATB = maxATB; }

        //refill atb gauge
        if (currentATB < 5f)
        {
            currentATB += atbSpeed * Time.deltaTime;
        }

        atbText.text = Mathf.RoundToInt(currentATB).ToString();

        //update ATB bar graphic
        float increment = atbTransform.rect.width / maxATB;   //how many units per HP
        float positionDifference = (maxATB - currentATB) * increment;
        float newPosX = maxXPosATB - positionDifference;
        atbTransform.position = new Vector2(newPosX, yPosATB);

    }

    private void Movement()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }

}