using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
    //Follow enemy Variant 1
    public player_move playerScript;
    // public variable
    public int health = 40;
    public int damage = 10;
    public int power = 7;
    public bool isFollowing;
    Animator anim;

    //private variables
    float movementSpeed = .5f;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        //Initializing stat variables

        //Finding Player
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        isFollowing = false;

    }

    // Update is called once per frame
    void Update()
    {
        float yDifference = player.transform.position.y - transform.position.y;
        float xDifference = player.transform.position.x - transform.position.x;
        Debug.Log(yDifference);

        //if (yDifference > xDifference)
        //{
        //    if (yDifference > 0.0f)
        //    {
        //        anim.SetInteger("Movement", 2);
        //    }
        //    if (yDifference < 0.0f)
        //    {
        //        anim.SetInteger("Movement", 4);
        //    }
        //}
            if (xDifference > 0.0f)
            {
                anim.SetInteger("Movement", 3);
            }
            if (xDifference < 0.0f)
            {
                anim.SetInteger("Movement", 1);
            }
        if (isFollowing == true)
        {
            if (player)
            {

                 yDifference = player.transform.position.y - transform.position.y;
                if (yDifference > .3f)
                {
                    if (yDifference < 0f)
                    {
                        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);   
                    }
                    if (yDifference > 0f)
                    {
                        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);
                }
                 xDifference = player.transform.position.x - transform.position.x;
                if (xDifference > .1f)
                {
                    if (xDifference < 0f)
                    {
                        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

                    } if (xDifference > 0f)
                    {
                        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);

                }

            }
        }

        if (health <= 0)
        {
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
            movementSpeed = 1;
        }
    }
}
