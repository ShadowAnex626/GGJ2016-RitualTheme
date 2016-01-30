using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
    public int health;
    public int damage;
    public int power;
<<<<<<< HEAD

    float movementSpeed;
    int attackSpeed;
    float knifeVelocity;

    public Rigidbody2D knife;
=======
    public float knifeVelocity;
    public Rigidbody2D knife;
    public Text healthText;
    public Slider healthSlider;
    public Enemy1 enemy1Script;
    public Text powerText;
    public Slider powerSlider;
>>>>>>> origin/terry

    float movementSpeed;
    float attackSpeed;
    int maxHealth;
    float attackTimer;
    float hitTimer;
    int maxPower = 140;
    void Start()
    {
        health = 100;
        damage = 20;
        power = 65;
        movementSpeed = 5;
<<<<<<< HEAD
        attackSpeed = 1;
        knifeVelocity = 4f;
=======
        attackSpeed = .4f;
        knifeVelocity = 10;
        maxHealth = 100;
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHealth;
        attackTimer = 0.0f;
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;
       
>>>>>>> origin/terry
    }

    void Update()
    {
        healthText.text = ("HP: " + health);
        healthSlider.value = health;
        powerText.text = ("Power: " + power);
        powerSlider.value = power;
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, knifeVelocity, 0));
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, -knifeVelocity, 0));
            knifeThrow.transform.Rotate(180f, 0, 0);
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(-knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, 90f);
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, -90f);
            attackTimer = Time.time + attackSpeed;

        }

        if (power >= 1 && Input.GetKeyDown(KeyCode.E))
        {
            health += power;
            power = 0;
            
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        if (power >= maxPower)
        {
            power = maxPower;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health -= enemy1Script.damage;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (Time.time >= hitTimer)
            {
                health -= enemy1Script.damage;
                hitTimer = Time.time + .5f;
            }
        }
    }
}
