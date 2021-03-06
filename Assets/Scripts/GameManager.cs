using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //bola
    [SerializeField]
    private GameObject bola;
    public int bolasNum = 1;
    private bool bolaMorreu = false;
    public int bolasEmCena = 0;
    public Transform pos;

    public int tiro = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad (this.gameObject);
        }
        else
        {
            Destroy (gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
    }
    
    void Carrega(Scene cena,LoadSceneMode modo)
    {
        pos = GameObject.Find("posStart").GetComponent<Transform>();
    }

    void Start ()
    {
        ScoreManager.instance.GameStartScoreM ();
    }

   

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.UpdateScore ();
        UIManager.instance.UpdateUI ();
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene ("Level2");
        }

        NascBolas();
        if (bolasNum <=0)
        {
            GameOver();
        }
    }
//responsável pelo  nascbola
    void NascBolas()
    {
        if(bolasNum > 0 && bolasEmCena == 0)
        {
            Instantiate (bola, new Vector2(pos.position.x,pos.position.y), Quaternion.identity);
            bolasEmCena += 1;
            tiro = 0;
        }
    }

    void GameOver()
    {
        UIManager.instance.GameOverUI();
    }

}
