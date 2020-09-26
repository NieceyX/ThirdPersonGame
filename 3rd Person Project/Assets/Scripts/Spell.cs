using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    private int instances = 0;

    private Animator _animator;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        part.Stop();

        _animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && instances < 1)
        {
            StartCoroutine(Attack());
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Spell", false);
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        other.GetComponent<Enemy>().Hurt();
    }

    IEnumerator Attack()
    {
        instances++;
        _animator.SetBool("Spell", true);
        part.Play();
        yield return new WaitForSeconds(0.5f);
        part.Stop();
        yield return new WaitForSeconds(3);
        instances--;
    }
}
