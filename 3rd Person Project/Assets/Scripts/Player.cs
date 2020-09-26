using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource huah;
    public SimpleHealthBar healthBar;
    public int maxHealth = 50;
    private int currHealth;
    public int points = 0;

    public float radius = 10f;

    private Animator _animator;

    private int dodgeInstances = 0;
    private int instances = 0;
    private bool swing = false;
    private bool dodge = false;

    void Start()
    {
        huah = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        currHealth = maxHealth;
    }

    void Update()
    {
        if (currHealth <= 0)
        {
            StartCoroutine(Death());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && instances < 1)
        {
            StartCoroutine(Attack());
            swing = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dodgeInstances < 1)
        {
            StartCoroutine(Dodge());
            dodge = false;
        }

    }
    void LateUpdate()
    {
        _animator.SetBool("Attack", false);
        _animator.SetBool("Dodge", false);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy alive = collision.gameObject.GetComponent<Enemy>();
            if (alive._death == false && dodgeInstances < 1)
            {
                //_animator.SetBool("Hit", true);
                currHealth--;
                healthBar.UpdateBar(currHealth, maxHealth);
                //StartCoroutine(Ouch());
            }
        }

    }

    public void Heal()
    {
        currHealth += 5;
        healthBar.UpdateBar(currHealth, maxHealth);
    }

    public void AddPoints()
    {
        points += 10;
        GameObject.Find("Points").GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    public void AddItem(int item)
    {
        if (item == 0)
        {
            Image image = GameObject.Find("Book").GetComponent<Image>();
            image.enabled = true;
        }
        else if(item == 1)
        {
            Image image = GameObject.Find("Gold").GetComponent<Image>();
            image.enabled = true;
        }
    }
    

    IEnumerator Attack()
    {
        instances++;
        _animator.SetBool("Attack", true);
        huah.Play();
        Vector3 center = this.gameObject.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        
        while (i < hitColliders.Length && !swing)
        {
            
            if (hitColliders[i].tag == "Enemy")
            {
                Enemy alive = hitColliders[i].gameObject.GetComponent<Enemy>();
                if (alive._death == false)
                {
                    swing = true;
                    Enemy kill = hitColliders[i].gameObject.GetComponent<Enemy>();
                    kill.Hurt();
                }
            }
            i++;
        }
        yield return new WaitForSeconds(1f);
        instances--;
    }

    IEnumerator Death()
    {
            _animator.SetBool("Dead", true);
            GetComponent<RelativeMovement>().enabled = false;
            yield return new WaitForSeconds(4);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Died");
    }
    IEnumerator Ouch()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Hit", false);
    }

    IEnumerator Dodge()
    {
        dodgeInstances++;
        _animator.SetBool("Dodge", true);

        yield return new WaitForSeconds(1f);
        dodgeInstances--;
    }
}
