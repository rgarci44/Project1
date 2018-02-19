using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Logic : MonoBehaviour
{

    public Rigidbody Target;
    public GameObject TargetSpawner;
    public GameObject Gold_Item;
    public GameObject Silver_Item;
    public GameObject Bronze_Item;
    public GameObject Default_Item;
    public UnityEngine.UI.Text Score_Text1;
    public UnityEngine.UI.Text Score_Text2;
    public UnityEngine.UI.Text Win_Text;

    // Use this for initialization
    void Start()
    {

        Rigidbody Target1;
        Rigidbody Target2;
        Target1 = Instantiate(Target, new Vector3(-2, Target.transform.position.y, Target.transform.position.z), transform.rotation) as Rigidbody;
        Target2 = Instantiate(Target, new Vector3(-5, 2, 5), transform.rotation) as Rigidbody;
        TargetSpawner.SetActive(false);
        Gold_Item.SetActive(false);
        Silver_Item.SetActive(false);
        Bronze_Item.SetActive(false);
        Default_Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Score_Text1.text = BulletCollision.score.ToString();
        Score_Text2.text = BulletCollision.score.ToString();

        if ((GameObject.Find("Target(Clone)")) == null)
        {
            if (BulletCollision.score >= 100)
            {
                Bronze_Item.SetActive(false);
                Silver_Item.SetActive(false);
                Gold_Item.SetActive(true);
                Default_Item.SetActive(false);
            }

            if (BulletCollision.score >= 50 && BulletCollision.score < 100)
            {
                Bronze_Item.SetActive(false);
                Silver_Item.SetActive(true);
                Gold_Item.SetActive(false);
                Default_Item.SetActive(false);

            }
            if (BulletCollision.score >= 25 && BulletCollision.score < 50)
            {
                Bronze_Item.SetActive(true);
                Silver_Item.SetActive(false);
                Gold_Item.SetActive(false);
                Default_Item.SetActive(false);
            }


            if (BulletCollision.score < 25)
            {
                Bronze_Item.SetActive(false);
                Silver_Item.SetActive(false);
                Gold_Item.SetActive(false);
                Default_Item.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;
        GameObject otherObject = collision.gameObject;
        Transform otherTransform = collision.transform;
        Rigidbody otherRigidBody = collision.rigidbody;


        if (otherObject.tag == "Gold")
        {
            Win_Text.text = "You won Gold!";
            Destroy(Gold_Item);
            FPS_Script.playable = false;
        }

        if (otherObject.tag == "Silver")
        {
            Win_Text.text = "You won Silver!";
            Destroy(Silver_Item);
            FPS_Script.playable = false;
        }

        if (otherObject.tag == "Bronze")
        {
            Win_Text.text = "You won Bronze";
            Destroy(Bronze_Item);
            FPS_Script.playable = false;
        }

        if (otherObject.tag == "Generic")
        {
            Win_Text.text = "You win!";
            Destroy(Default_Item);
            FPS_Script.playable = false;
        }
    }
}
