using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public float speed;
    public Text countText;
    private int count;

    private Rigidbody rb;


    Vector3 checkPointPosition;
    void Start()
    {
        count = 0;
       // setCountText();

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
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetPosDead(other);
        CheckPoint(other);
        PickUps(other);
    }

    private void ResetPosDead(Collider other)
    {
        if (other.gameObject.CompareTag("deadZone"))
        {

            gameObject.transform.position = checkPointPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void CheckPoint(Collider other)
    {
        if (other.gameObject.CompareTag("checkPoint")){
           
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
