using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableDoor : MonoBehaviour
{
    public float doorOpenAngle = 90.0f;
    public float openSpeed = 2.0f;
    public int reqPoints = 600;

    bool open = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    private Player player;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Main function
    void Update()
    {
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);
    }

    public void Operate()
    {
        if (player.points >= reqPoints)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }

    }
}
