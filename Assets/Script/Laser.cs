using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Laser : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;
    public GameObject cursor;
    private Spline spline;

    // Start is called before the first frame update
    void Start()
    {
        spline = spriteShapeController.spline;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision");

        Vector2 closestPoint = spriteShapeController.gameObject.GetComponent<EdgeCollider2D>().ClosestPoint(cursor.transform.position);

        float distance = Vector2.Distance(closestPoint, collision.transform.position);
        float threshold = 1f;

        if (distance < threshold)
        {
            Vector2 forceDirection = (closestPoint - (Vector2)collision.transform.position).normalized;

            float strength = 1000f;

            collision.GetComponent<Rigidbody2D>().MovePosition(closestPoint);        }

        // make the cursor follow the closest point
        //cursor.transform.position = closestPoint;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");

        //reset force
        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
//    private void OnCollisionStay2D(Collision2D collision)
//    {
//        Debug.Log("Collision");
        
//        //attract the object to the laser
//        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - collision.gameObject.transform.position) * 1000);        
//    }
//}
