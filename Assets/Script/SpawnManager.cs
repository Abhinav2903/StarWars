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
    [SerializeField]
    private GameObject[] _powerups;
    void Start()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    
    void Update()
    {   
       
    }
    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (stopSpawn==false)
        {
            Vector3 epos = new Vector3(Random.Range(-9.0f, 9.0f), 7.0f, 0f);
            GameObject newEnemy = Instantiate(_enemyprefab, epos, Quaternion.identity);
            newEnemy.transform.parent = _enemyConatiner.transform;  

            yield return new WaitForSeconds(5.0f);
        }
        if (stopSpawn == true)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(stopSpawn==false)
        {
            Vector3 pupos = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
            int x = Random.Range(0, 3); 
            Instantiate(_powerups[x], pupos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f,7f));
        }
        if(stopSpawn==true)
        {
            Destroy(this.gameObject);
        }
    }

    public void onPlayerDeath()
    {
        stopSpawn = true;
    }
}
