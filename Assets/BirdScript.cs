using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    public float maxHeightLimit = 20;
    public float minHeightLimit = -20;
    public AudioSource deadSoundEffect;
    public AudioSource flySoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            flySoundEffect.Play();
        }
        if (transform.position.y > maxHeightLimit || transform.position.y < minHeightLimit)
        {
            birdKilled();
        }
    }
    private void birdKilled()
    {
        if (birdIsAlive == true)
        {
            deadSoundEffect.Play();
            birdIsAlive = false;
            logic.gameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdKilled();
    }
}
