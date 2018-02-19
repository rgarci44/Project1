using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour {

    public GameObject Player;
    public GameObject Appendage;
    public Rigidbody Bullet;
    public Camera Camera;
    public Camera Camera2;
    public GameObject Gun;
    public float rotationSpeed = 90f;
    public float moveSpeed = 4.0f;



    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        Cursor.visible = false;
        Camera2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FPS_Script.playable)
        {

            Vector3 lookDirection = Vector3.zero;

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            if (mouseX > 0)
            {
                transform.Rotate(transform.up, rotationSpeed * Time.deltaTime, Space.World);
            }

            if (mouseX < 0)
            {
                transform.Rotate(-transform.up, rotationSpeed * Time.deltaTime, Space.World);
            }



            if (mouseY < 0)
            {
                transform.Rotate(transform.right, rotationSpeed * Time.deltaTime, Space.World);
            }

            if (mouseY > 0)
            {
                transform.Rotate(-transform.right, rotationSpeed * Time.deltaTime, Space.World);
            }


            if (transform.rotation.z < 0 || transform.rotation.z > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }

            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

            if ((Input.GetMouseButtonDown(0)))
            {
                Rigidbody clone;
                clone = Instantiate(Bullet, Gun.transform.position, transform.rotation) as Rigidbody;
                clone.velocity = transform.TransformDirection(Vector3.forward * 10);

            }
        }
        else
        {
            Camera.gameObject.SetActive(false);
            Camera2.gameObject.SetActive(true);
        }
    }
}

