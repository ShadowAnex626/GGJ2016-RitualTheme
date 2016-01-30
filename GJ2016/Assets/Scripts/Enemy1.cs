using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{
    //Follow enemy Variant 1

    // public variable
    public int health;
    public int damage;
    public int power;
    public bool isFollowing;

    //private variables
    int movementSpeed;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        //Initializing stat variables
        health = 20;
        damage = 5;
        movementSpeed = 1;
        power = 1;

        //Finding Player
        player = GameObject.FindWithTag("Player");

        isFollowing = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing == true) {

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