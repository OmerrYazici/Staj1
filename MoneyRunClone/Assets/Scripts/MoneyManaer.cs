using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManaer : MonoBehaviour
{
    StackManager stackManager;
    public GameObject money;
    public Transform moneySpawnPoint, pos;
    Rigidbody rb;
    CollectCoin collectCoin;
    Player player;
    public Animator animator;
    public GameObject[] paralar;
    public int index;
    public float spawnSpeed, spawnSpeed1;
    private bool spawnStair;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        collectCoin = GetComponent<CollectCoin>();
        stackManager = GetComponent<StackManager>();
        InvokeRepeating("StairUp", spawnSpeed, spawnSpeed1);

    }

    // Update is called once per frame
    void Update()
    {

        if (paralar.Length == 0)
        {
            animator.SetBool("isHand", false);
            stackManager.prevObject = pos;
        }
        if(paralar.Length>0)
        {
            animator.SetBool("isHand", true);

        }
        paralar = GameObject.FindGameObjectsWithTag("PickUp");
        index = paralar.Length - 1;
        if(Input.GetMouseButtonDown(0))
        {
            spawnStair = true;
            rb.isKinematic = true;
        }
        if(Input.GetMouseButtonUp(0)||paralar.Length<=0)
        {
            spawnStair = false;
            rb.isKinematic = false;

        }
    }
    void StairUp()
    {
        if(spawnStair && paralar.Length>0)
        {
            for (index = 0; index < 1; index++)
            {
                Destroy(paralar[index]);
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
                Instantiate(money, moneySpawnPoint.transform.position, money.transform.rotation);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PsCafe"))
        {
            
            if (paralar.Length > 0)
            {
                for (index = 0; index < 4; index++)
                {
                    Destroy(paralar[index]);
                }
                Destroy(other.gameObject);
            }
            else if (paralar.Length <= 0)
            {
                 player.isDead= true;
            }
        }
    }
}
