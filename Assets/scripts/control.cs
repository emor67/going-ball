using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winScoreText;

    private int count;
    public new Camera camera;
    private Rigidbody rb;
    public float roadSpeedMultiplier;
    public GameObject winPanel;
    public GameObject gamePanel;


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
        Win(other);

        if (count < 0)
        {
            SceneManager.LoadScene("GameMain");
        }        
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

            count = count - 1;
            setCountText();
        }
    }

    private void CheckPoint(Collider other)
    {
        if (other.gameObject.CompareTag("checkPoint")){

            //camera.transform.rotation = other.transform.rotation;
            UpdateCheckPointPosition(other.transform.position);
            other.gameObject.SetActive(false);

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

    private void Win(Collider other)
    {
        if (other.gameObject.CompareTag("winZone"))
        {
            //winPanel will be active and, play again button will be added
            winPanel.gameObject.SetActive(true);
            gamePanel.gameObject.SetActive(false);

            winScoreText.text = "Your Score : " + count.ToString();

            Time.timeScale = 0;
        }
    }
    
}
