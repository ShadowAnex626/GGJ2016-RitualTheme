using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {
    public int health;
    public int damage;
    public int power;

<<<<<<< HEAD
    float movementSpeed;
    int attackSpeed;
=======
    public float speed;
    public float knifeVelocity;

    public Rigidbody2D knife;
>>>>>>> refs/remotes/origin/terry

    void Start()
    {
        health = 100;
        damage = 20;
        power = 0;
        movementSpeed = 5;
        attackSpeed = 1;
    }

    void Update()
    {

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
}
