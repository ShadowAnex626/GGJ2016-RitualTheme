using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
    public int health;
    public int damage;
    public int power;
    public float knifeVelocity;
    public Rigidbody2D knife;
    public Text healthText;
    public Slider healthSlider;
    public Enemy1 enemy1Script;

    float movementSpeed;
    float attackSpeed;
    int maxHealth;

    void Start()
    {
        health = 100;
        damage = 20;
        power = 0;
        movementSpeed = 5;
        attackSpeed = 1;
        knifeVelocity = 4;
        maxHealth = 100;
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHealth;

    }

    void Update()
    {
        healthText.text = ("HP: " + health);
        healthSlider.value = health;
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, knifeVelocity, 0));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, -knifeVelocity, 0));
            knifeThrow.transform.Rotate(180f, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(-knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, 90f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, -90f);

        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health -= enemy1Script.damage;
        }
    }
}
