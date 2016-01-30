using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {
    public int health;
    public int damage;
    public int power;

    float movementSpeed;
    int attackSpeed;

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

    }
}
