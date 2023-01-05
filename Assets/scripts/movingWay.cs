using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWay : MonoBehaviour
{
    private float roadPos;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
       roadPos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        transform.position = new Vector3(0, roadPos, (moveSpeed * Time.deltaTime));
    }
}
