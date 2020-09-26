using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shhh : MonoBehaviour
{
    public AudioSource hush;

    // Start is called before the first frame update
    void Start()
    {
        hush = GetComponent<AudioSource>();
        StartCoroutine(Oop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Oop()
    {
        yield return new WaitForSeconds(6);
        hush.Play();
        yield return new WaitForSeconds(6);
        StartCoroutine(Oop());
    }
}
