using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordQuest : MonoBehaviour {

    private Player player;
    private int jewelCount = 0;

    private float animationTimer = 2.5f;

    public GameObject gate;
    private GameObject waechter;

    Animator anim;


    private void Update()
    {
        if (anim.GetBool("Open"))
        {
            animationTimer -= Time.deltaTime;

            if(animationTimer <= 0)
            {
                gate.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            jewelCount = FindObjectOfType<Player>().getCollectedJewel();

        }

        if (jewelCount >= 1)
        {

            FindObjectOfType<Player>().clearJewel();

            DialogueManager.questprogress = 1;

            anim.SetBool("Open", true);

        }

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        if (FindObjectOfType<Player>().getCollectedSword() > 0)
        {
            gate.SetActive(false);
        }

    }
}
