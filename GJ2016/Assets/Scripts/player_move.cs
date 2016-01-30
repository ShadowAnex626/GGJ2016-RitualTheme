using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {

    public float speed;
    public float knifeVelocity;

    public Rigidbody2D knife;

    void Start()
    {

    }

    void Update()
    {

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0) * Time.deltaTime);

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
