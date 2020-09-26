using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource walk;
    bool playsteps = false;
    public float waitTime = 1.0f;
    private int instances = 0;

    private CharacterController _charController;

    // Start is called before the first frame update
    void Start()
    {
        walk = GetComponent<AudioSource>();
        _charController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical") && _charController.isGrounded && instances < 1)
        {
            if (!walk.isPlaying && !playsteps && _charController.isGrounded)
            {
                playsteps = true;
                StartCoroutine(Footstep());
            }
        }

        else if (Input.GetButton("Horizontal") && _charController.isGrounded && instances < 1)
        {
            if (!walk.isPlaying && !playsteps && _charController.isGrounded)
            {
                playsteps = true;
                StartCoroutine(Footstep());
            }
        }
        else
        {
            playsteps = false;
            StopCoroutine(Footstep());
        }
    }

    IEnumerator Footstep()
    {
        instances++;
        while (playsteps)
        {
            walk.Play();
            yield return new WaitForSeconds(waitTime);
        }
        instances--;
    }
}
