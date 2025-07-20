using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_enemy : MonoBehaviour
{
    public float speed;
    Player player;
    Animator animator;
    public GameObject Explosion;
    // Start is called before the first frame update
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
        if (other.tag == "BlueHole")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            player.AddScore();
            Destroy(this.gameObject);
        }
        if (other.tag == "RedHole" || other.tag == "GreenHole")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            //player.DeleteScore();
            player.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
