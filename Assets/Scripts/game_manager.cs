using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class game_manager : MonoBehaviour
{
    public Rigidbody rb;
    public shatter_effect shatter_object;
    int lastLevel = 2;
	bool moving;
	bool dead;
	float startTime;
    float laneDist;
    float curLane;
    float moveLane;
    float forwardSpeed = 15f;
	float sideSpeed = 6f;
    public Stopwatch timer = new Stopwatch();
    public audio_manager AudioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //startTime = Time.time;
		laneDist = 1;
        curLane = rb.position.x;
        moveLane = curLane;
    }

    void Update()
	{

        if (!dead)
            rb.MovePosition(rb.position + transform.forward * Time.deltaTime * forwardSpeed);
        if (timer.Elapsed.TotalSeconds >= 1)
            restart();

        if (rb.position.y < -1.1)
            restart();

        if (!inBounds())
            dead = true;

        if (Input.GetKey("right") && inBounds() && !moving && !dead)
		{
            moveLane = curLane + 1;
            startTime = Time.time;
            moving = true;

        }
        else if (Input.GetKey("left") && inBounds() && !moving && !dead)
		{
            moveLane = curLane - 1;
            startTime = Time.time;
            moving = true;

        }
        if (moving)
        {
            float distCovered = (Time.time - startTime) * sideSpeed;
            //float distCovered = Time.deltaTime * sideSpeed;
            float fracJourney = distCovered / laneDist;
            //float fracJourney = Mathf.Abs(rb.position.x - curLane) / laneDist + distCovered; 
            Vector3 curVect = new Vector3(curLane, rb.position.y, rb.position.z);
            Vector3 moveVect = new Vector3(moveLane, rb.position.y, rb.position.z);
            transform.position = Vector3.Lerp(curVect, moveVect, fracJourney);
            
            //if (Mathf.Abs(rb.position.x - moveLane) < 0.0001)
            if(rb.position.x == moveLane)
            {
                //transform.position = new Vector3(moveLane, rb.position.y, rb.position.z);
                curLane = moveLane;
                moving = false;

            }
            /*
            else if(rb.position.x == curLane)
            {
                UnityEngine.Debug.Log(curLane);
                moveLane = curLane;
                moving = false;
            }
            */
        }

    }

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "obstacle")
		{
            AudioManager.playShatterSound();
            shatter_object.shatter();
			timer.Start();
			dead = true;
		}
	}
    
    void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Collider>().name == "WinBlock")
        {
            string curScene = SceneManager.GetActiveScene().name;
            int curLevel = int.Parse(curScene.Substring(5));
            int nextLevel = curLevel + 1;
            if (curLevel != lastLevel)
            {
                string nextScene = "level" + nextLevel.ToString();
                SceneManager.LoadScene(nextScene);
            }
            else
                UnityEngine.Debug.Log("Congrats");

        }
			
	}

	void restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnityEngine.Debug.Log("snkae");
	}

	bool inBounds()
	{
		return transform.position.x >= -3 && transform.position.x <= 3;
	}
}
