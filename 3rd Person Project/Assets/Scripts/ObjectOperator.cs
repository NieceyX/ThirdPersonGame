using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOperator : MonoBehaviour
{
    [SerializeField] public int code;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }


    public void Operate()
    {
        player.AddItem(code);
        Destroy(this.gameObject);
    }
}
