using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    public Rigidbody Bullet;
    public GameObject Target;
    
    public float constrainDistance = 10;
    public static int score;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Bullet.position.x > constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
        if (Bullet.position.x < -constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }

        if (Bullet.position.z > constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
        if (Bullet.position.z < -constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;
        GameObject otherObject = collision.gameObject;
        Transform otherTransform = collision.transform;
        Rigidbody otherRigidBody = collision.rigidbody;


        if (otherObject.tag == "Bullseye")
        {
            score += 100;
            print("Bullseye : 100 points");
            Destroy(GameObject.Find("Target(Clone)"));
        }

        if (otherObject.tag == "Inner")
        {
            score += 50;
            print("Inner : 50 points");
            Destroy(GameObject.Find("Target(Clone)"));
        }

        if (otherObject.tag == "Middle")
        {
            score += 25;
            print("Middle : 25 points");
            Destroy(GameObject.Find("Target(Clone)"));
        }

        if (otherObject.tag == "Outer")
        {
            score += 10;
            print("Outer : 10 points");
            Destroy(GameObject.Find("Target(Clone)"));
        }

        if (otherObject.tag == "Outermost")
        {
            score += 5;
            print("Outermost : 5 points");
            Destroy(GameObject.Find("Target(Clone)"));
        }


        //print("Object " + transform.name + " collided with " + collision.gameObject.name);
        Destroy(GameObject.Find("Bullet(Clone)"));
        

    }

}