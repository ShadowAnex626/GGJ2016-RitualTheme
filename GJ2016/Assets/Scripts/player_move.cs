using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {

    public float speed;

    void Start()
    {

    }

    void Update()
    {

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0) * Time.deltaTime);

    }
}
