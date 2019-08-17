using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatter_effect : MonoBehaviour
{
    float cubeSize = 0.2f;
    int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    Material playerMat;

    float explosionForce = 10f;
    float explosionRadius = 1f;
    float explosionUpward = -1.4f;

    // Use this for initialization
    void Start()
    {
        playerMat = GetComponent<Renderer>().material;
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void shatter()
    {
        //make object disappear
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
            for (int y = 0; y < cubesInRow; y++)
                for (int z = 0; z < cubesInRow; z++)
                    createPiece(x, y, z);
        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material = playerMat;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}

