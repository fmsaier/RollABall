using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    private int sorce = 0;

    public TextMeshProUGUI scoreText;

    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(moveX, 0, moveZ));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            ++sorce;
            scoreText.text = sorce.ToString();
            Destroy(other.gameObject);
            if(sorce == 11)
            {
                winUI.SetActive(true);
            }
        }
    }
}
