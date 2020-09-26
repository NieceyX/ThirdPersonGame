using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;
    private GameObject objSpawn;
    private int SpawnerID;

    private Player player;

    private Animator _animator;

    private float _speed;
    public bool _death = false;

    public float radius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
        _animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void setName(int sName)
    {
        SpawnerID = sName;
    }

    // Update is called once per frame
    void Update()
    {
        _speed = GetComponent<Rigidbody>().velocity.magnitude;
        _animator.SetFloat("Speed", _speed);

        Vector3 center = this.gameObject.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                _animator.SetBool("Attack", true);
            }
            i++;
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Attack", false);
    }

    public void Hurt()
    {
        health--;
        if (health <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        
        _death = true;
        _animator.SetBool("Death", true);
        GetComponent<Follow>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        if (GetComponent<Rigidbody>().velocity.magnitude < .01)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        player.AddPoints();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
