using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;


    //Patrol
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkingRange;

    //Attack
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletPrefab;
    bool alreadyAttacked;

    //States 
    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    float nextFire = 0.0f;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //Checking attack and sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


    }
    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkingRange, walkingRange);
        float randomX = Random.Range(-walkingRange, walkingRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;

    }
    void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    void AttackPlayer()
    {
        
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (Time.time > nextFire)
        {
            Debug.Log("firing");
            nextFire = Time.time + fireRate;
            createBullet();
        }

    }

    void createBullet()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
