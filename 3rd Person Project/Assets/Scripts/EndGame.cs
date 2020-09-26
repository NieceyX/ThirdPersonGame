using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public AudioSource ouch;
    // Start is called before the first frame update
    void Start()
    {
        ouch = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Apples and bannanas");
        if (collision.gameObject.name == "Enemy")
        {
            ouch.Play();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Debug.Log("Apples and bannanas x2");
            SceneManager.LoadScene("Lost");
        }
    }
}
