using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_enemy : MonoBehaviour
{
    public float speed;
    Player player;
    Animator animator;
    public GameObject Explosion;
    public AudioSource audioPlayer;

    //public AudioSource audioPlayer;




    /*private void Awake()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
       
    }*/

    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GreenHole")
        {
            //audioManager.PlaySFX(audioManager.scoreMinusEnemyCollison);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            player.AddScore();
            Destroy(this.gameObject);
        }

        if (other.tag == "RedHole" || other.tag == "BlueHole")
        {
            //audioPlayer.Play();
            //audioManager.PlaySFX(audioManager.scoreMinusEnemyCollison);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            //player.DeleteScore();
            player.TakeDamage();
            Destroy(this.gameObject);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // audioPlayer.Play();
        }
    }


}
