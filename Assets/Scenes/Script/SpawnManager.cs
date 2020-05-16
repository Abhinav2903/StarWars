using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemyConatiner;
    [SerializeField]
    private bool stopSpawn = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    void Update()
    {   
       
    }
    IEnumerator SpawnRoutine()
    {
        while (stopSpawn==false)
        {
            Vector3 epos = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0f);
            GameObject newEnemy = Instantiate(_enemyprefab, epos, Quaternion.identity);
            newEnemy.transform.parent = _enemyConatiner.transform;  

            yield return new WaitForSeconds(5.0f);
        }
        if (stopSpawn == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void onPlayerDeath()
    {
        stopSpawn = true;
    }
}
