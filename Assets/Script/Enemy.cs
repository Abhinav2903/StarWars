using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int enemySpd = 4;
    Player _player;
    Animator animator;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * enemySpd * Time.deltaTime);
        if (transform.position.y <= -5.0f)
        {     
            transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            animator.SetTrigger("On_Destruction");
            enemySpd = 0;
            Destroy(this.gameObject,2.8f);

            
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
           
        }

        if (other.tag == "Laser")
        {
            //Destroy(other.gameObject);
            Destroy(other.gameObject);
            animator.SetTrigger("On_Destruction");
            enemySpd = 0;
            _player.AddScore(5);
            Destroy(this.gameObject,2.8f);

        }

       /* if (other.tag == "TripleShot")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }*/


    }

}
