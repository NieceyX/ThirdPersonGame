using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOperator : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void Operate()
    {
        player.Heal();
        Destroy(this.gameObject);
    }
}
