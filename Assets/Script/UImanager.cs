using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Sprite[] _liveSprite;
    [SerializeField]
    private Image _livesimage;
    [SerializeField]
    private Text _gameovertxt;
    [SerializeField]
    private Text _restarttxt;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:" + 0;
    }

    public void UpdateScore(int plrscore)
    {
        scoreText.text = "Score:" + plrscore.ToString();
        _gameovertxt.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    public void UpdateLives(int curlives)
    {
        _livesimage.sprite = _liveSprite[curlives];
        if (curlives == 0)
        {
            Gameoverseq();
        }
    }
    
    void Gameoverseq()
    {
        _gameManager.GameOver();
        _gameovertxt.gameObject.SetActive(true);
        _restarttxt.gameObject.SetActive(true);
        StartCoroutine(Gameoverflicker());
    }

    IEnumerator Gameoverflicker()
    {
        while (true)
        {
            _gameovertxt.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameovertxt.text = "";
            yield return new WaitForSeconds(0.5f);

        }
        
        

    }
}
