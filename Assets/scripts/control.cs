using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public float speed;
    public Text countText;
    private int count;
    public new Camera camera;
    private Rigidbody rb;
    public float roadSpeedMultiplier;


    Vector3 checkPointPosition;
    void Start()
    {
        count = 0;
        roadSpeedMultiplier = 1;
       

        rb = GetComponent<Rigidbody>();

        checkPointPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * roadSpeedMultiplier);
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetPosDead(other);
        CheckPoint(other);
        PickUps(other);
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("speedRoad"))
        {
            roadSpeedMultiplier = 5;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("speedRoad"))
        {
            roadSpeedMultiplier = 1;
        }
    }


    private void ResetPosDead(Collider other)
    {
        if (other.gameObject.CompareTag("deadZone"))
        {
            camera.transform.rotation = Quaternion.Euler(18, 0, 0);

            gameObject.transform.position = checkPointPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void CheckPoint(Collider other)
    {
        if (other.gameObject.CompareTag("checkPoint")){

            //camera.transform.rotation = other.transform.rotation;
            UpdateCheckPointPosition(other.transform.position);
            
        }
    }

    private void UpdateCheckPointPosition(Vector3 position)
    {
        checkPointPosition = position;
    }

    private void setCountText()
    {
        countText.text = "Count : " + count.ToString();
    }

    private void PickUps(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
    }

}
