using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    private float offset = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 v = transform.position;
            v.x -= offset;
            transform.position = v;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 v = transform.position;
            v.y -= offset;
            transform.position = v;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 v = transform.position;
            v.x += offset;
            transform.position = v;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 v = transform.position;
            v.y += offset;
            transform.position = v;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
