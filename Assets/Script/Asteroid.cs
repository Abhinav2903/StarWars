using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotate_speed = 3.0f;
    [SerializeField]
    private GameObject _explodeprefab;
    SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotate_speed * Time.deltaTime);
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Laser")
        {
            Instantiate(_explodeprefab, new Vector3(0, 3, 0),Quaternion.identity);
            //Destroy(_explodeprefab);
            _spawnManager.StartSpawn();
            Destroy(other.gameObject);
            Destroy(this.gameObject,.25f);
        }
        
    }


}
