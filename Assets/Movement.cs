using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool collide;
    private bool move;
    private float size;
    public Rigidbody2D rb;
    public float speed;

    private IEnumerator movement()
    {
        while (move == true)
        {
            if (collide == true)
            {
                transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                yield return new WaitForSeconds(1f/(speed * size));
            }
            else if (collide == false)
            {
                transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                yield return new WaitForSeconds(1f/(speed * size));
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        size = transform.position.y - (-5.5f);
        collide = false;
        move = true;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(movement());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /**
        if ((collide == true) && (move == true))
        {
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }
        else if ((collide == false) && (move == true))
        {
            transform.position = new Vector2(transform.position.x - (1f), transform.position.y);
        }
        **/
    }
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            move = false;
            Vector2 dir = transform.TransformDirection(-Vector2.up) * 0.1f;
            transform.position = new Vector2(transform.position.x, transform.position.y);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 1.1f), dir, Color.green, 10);
            if (size == 1)
            {
                Instantiate(rb, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
                GetComponent<Movement>().enabled = false;
            }
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.1f), -Vector2.up, 0.1f);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 1.1f), dir, Color.green, 100);
            if (hit.collider != null)
            {
                Instantiate(rb, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
                GetComponent<Movement>().enabled = false;
            }
            else if((size != 1) && (hit.collider == null))
            {
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((collide == true) && (col.gameObject.tag == "tile"))
        {
            collide = false;
        }
        else if ((collide == false) && (col.gameObject.tag == "tile"))
        {
            collide = true;
        }
    }
}
