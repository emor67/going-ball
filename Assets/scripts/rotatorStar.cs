using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatorStar : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float moveAmplitude = 5.0f;
    public float moveFrequency = 1.0f;
    private float currentLocation;

    private void Start()
    {
        currentLocation = transform.position.y;
    }

    void FixedUpdate()
    {
        // Nesnenin rotasyonunu guncelle
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        // Nesnenin y ekseninde hareket ettir
        float yPos =(Time.deltaTime * moveFrequency) * moveAmplitude + currentLocation;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
