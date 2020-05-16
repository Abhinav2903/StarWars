using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _isgameover = false;
    public void GameOver()
    {
        _isgameover = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isgameover == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
