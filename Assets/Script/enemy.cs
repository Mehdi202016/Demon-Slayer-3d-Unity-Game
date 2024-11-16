using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class enemy : MonoBehaviour
{
    private Transform Target;
    private NavMeshAgent navMesh;
    private Animator anim;
    public int Health = 1;
    bool canAttack = true;
    float attackCoolDown = 3f;


    public static enemy instance;
    public BoxCollider ColliderHit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Speed", navMesh.velocity.magnitude);
        navMesh.SetDestination(Target.position);
        float distance = Vector3.Distance(transform.position,Target.position);
        if (distance <= navMesh.stoppingDistance)
        {
            if (canAttack)
            {
                StartCoroutine(cooldown());
                anim.SetTrigger("EnemyAttack");
            }
        }
    }

    IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }

    public void ShowSwordCollider()
    {
        ColliderHit.enabled = true;
    }
    public void HideSwordCollider()
    {
        ColliderHit.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sword"))
        {
            anim.SetTrigger("Hit");
            Health--;

            if (Health <= 0)
            {
                //UIManager.CoinsScore += 5;
                //UIManager.KillerScore += 1;
                //PlayerPrefs.SetInt("Score", UIManager.CoinsScore);
                //PlayerPrefs.SetInt("Killer", UIManager.KillerScore);
                //Debug.Log("Coin Score : " +UIManager.CoinsScore);
                UIManager.instance.Scr+=5;
                UIManager.AddScore(5);
                UIManager.AddKiller(1);
                Destroy(gameObject, 2f);
            }
        }
    }
}
