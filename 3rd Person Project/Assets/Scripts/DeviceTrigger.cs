using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeviceTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject[] targets;
   
    void OnTriggerEnter (Collider other)
    {
        SceneManager.LoadScene("Level2");
        /*foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }*/
    }
    /*void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }*/
}
