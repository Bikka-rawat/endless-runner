using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector2 pos;
    [SerializeField]float speed;
    float jump;
    Vector3[] lanepos;
    int currlaneindex;
    Rigidbody playerrb;


    [SerializeField]float smoothness;
    [SerializeField] GameObject[] lanes;
    // Start is called before the first frame update
    void Start()
    {
        lanepos = new Vector3[lanes.Length];
        playerrb = GetComponent<Rigidbody>();
        currlaneindex = lanes.Length / 2;
        for (int i = 0; i < lanes.Length; i++)
        {
            lanepos[i] = lanes[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        inputmanager();
        move();
    }

    private void FixedUpdate()
    {
        
    }

    void inputmanager()
    {
        if (Input.GetKeyDown(KeyCode.A)&& currlaneindex != 0)
        {
            currlaneindex--;

        }
        if (Input.GetKeyDown(KeyCode.D)&&currlaneindex!=lanes.Length-1)
        {
            currlaneindex++;
        }
    }

    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, lanepos[currlaneindex], smoothness*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other);
        }
    }
}
