using UnityEngine;
using System.Collections;

//Enemy Shooting 

public class Enemy2 : MonoBehaviour {

    public player_move playerScript;

    //public variables used outside this code
    public int health = 20;
    public int damage = 10;
    public int power = 500;
    public bool isFollowing;
    //Variables used for this class
    int movementSpeed;
    int shotSpeed;
    GameObject player;
	// Use this for initialization
	void Start () {
        movementSpeed = 1;
        shotSpeed = 5;
        //Finding Player
        player = GameObject.FindWithTag("Player");
        isFollowing = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (isFollowing == true)
        {

            float yDifference = player.transform.position.y - transform.position.y;
            if (yDifference > 1f)
            {
                if (yDifference < 0f)
                {
                    transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);
            }
            float xDifference = player.transform.position.x - transform.position.x;
            if (xDifference > 1f)
            {
                if (xDifference < 0f)
                {
                    transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);

            }
        }

        if (health <= 0)
        {
            playerScript.power += power;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Knife")
        {
            health -= playerScript.damage;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isFollowing = true;
        }


    }
    void OnTriggerStay2D(Collider2D col)
    {


    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isFollowing = false;
        }
    }
}