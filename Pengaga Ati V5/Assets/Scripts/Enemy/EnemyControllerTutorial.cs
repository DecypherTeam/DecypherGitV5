using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Examples {

public class EnemyControllerTutorial : MonoBehaviour
{
    NavMeshAgent agent;

    GameObject target;

    Animator animator;

    Rigidbody rb;

    public GameObject mesh;
    public Material ghostMaterial;

    //SpawnEnemy spawnEnemy;

    public static bool destroy = false;

    ParticleSystem ps;

    public AudioSource deathSound;

        /*public AudioSource angelSound;*/

        public AudioSource enemyComing;

        private bool playsound = false;

        public static bool boarShot = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        /*GameObject spawnenemy = GameObject.Find("SpawnEnemy");
        spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();*/
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Plant");

        if (target && GrownCheckTutorial.plantIsGrown == true)
        {
            GoToTarget();
        }
        else
        {
            StopEnemy();
        }

        if (destroy == true)
        {
            StartCoroutine(DestroyEnemy());
            destroy = false;
        }

        /*if(playsound == true)
            {
                enemyComing.Play();
                playsound = false;
            }*/

        ps = GameObject.Find("Particle Spirit").GetComponent<ParticleSystem>();
        ps.transform.position = transform.position;

        deathSound = GameObject.Find("BoarDeadSound").GetComponent<AudioSource>();

        /*angelSound = GameObject.Find("Angel Choir").GetComponent<AudioSource>();*/
    }

    private void GoToTarget()
    {
        animator.SetBool("isRunning", true);
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
            playsound = true;
        }

    private void StopEnemy()
    {
        animator.SetBool("isRunning", false);
        agent.isStopped = true;
    }

    public IEnumerator WaitBeforeGhost()
    {
        yield return new WaitForSeconds(2);
        /*angelSound.Play();*/
        mesh.GetComponent<Renderer>().material = ghostMaterial;
        rb.useGravity = false;
        agent.baseOffset = 2f;
        agent.speed = 2f;
        this.gameObject.tag = "Ghost";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            boarShot = true;
            animator.SetBool("isDead", true);
            agent.speed = 0f;
            deathSound.Play();
            ps.Play();
            StartCoroutine(WaitBeforeRevealGhost());
        }
    }

    public IEnumerator WaitBeforeRevealGhost()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(WaitBeforeGhost());
    }

    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1);
            enemyComing.Pause();
        Destroy(gameObject);
    }
}
}