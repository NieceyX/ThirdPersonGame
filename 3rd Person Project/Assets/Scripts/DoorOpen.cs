using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;
    [SerializeField] private float doorSpeed = 1f;


    enum State
    {
        Open, Opening, Closed, Closing
    };

    private State _state;
    private Vector3 _openPos;
    private Vector3 _closedPos;

    void Start()
    {
        _state = State.Closed;
        _closedPos = transform.position;
        _openPos = transform.position - dPos;
    }
    void Update()
    {
        if (_state == State.Opening)
        {
            transform.position = Vector3.Lerp(transform.position, _openPos, doorSpeed * Time.deltaTime);
            if (transform.position == _openPos)
            {
                _state = State.Open;
            }
        }

        else if (_state == State.Closing)
        {
            transform.position = Vector3.Lerp(transform.position, _closedPos, doorSpeed * Time.deltaTime);
             if (transform.position == _closedPos)
            {
                _state = State.Closed;
            }
        }
    }

    public void Operate()
    {
        if (_state == State.Open)
        {
            _state = State.Closing;
        }

        else
        {
            _state = State.Opening;
        }
    }
}