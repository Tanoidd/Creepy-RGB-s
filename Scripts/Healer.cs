using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public float speed;
   
    public GameObject Explosion;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.tag == "GreenHole"|| other.tag== "BlueHole"|| other.tag == "RedHole")
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeHeal();
            }

            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }       

    }
}
