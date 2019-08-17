using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_manager : MonoBehaviour
{   
    public Transform player;

    Vector3 camera_offset = new Vector3(0f,1f,-5f);
    Vector3 camera_offset2 = new Vector3(0f, 5f, -4f);

    Vector3 camera_angle = new Vector3(35, 0, 0);

    void Start()
    {
        //transform.eulerAngles = camera_angle;
        transform.position = player.position + camera_offset;
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(1.0f / Time.deltaTime);
        transform.position = player.position + camera_offset;
        //transform.position = new Vector3(0, 0, player.position.z) + camera_offset2;
    }
}
