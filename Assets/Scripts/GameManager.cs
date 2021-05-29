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
    private int bolasNun = 2;
    private bool bolaMorreu = false;
    private int bolasEmCena = 0;
    private Transform pos;

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
    void Star ()
    {
        ScoreManager.instance.GameStartScoreM ();
    }

   

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.UpdateScore ();
        UIManager.instance.UpdateUI ();

        NascBolas();
    }
//responsável pelo  nascbola
void NascBolas()
{
    if(bolasNun > 0 && bolasEmCena == 0)
    {
        Instantiate (bola, new Vector2(pos.position.x,pos.position.y), Quaternion.identity);
        bolasEmCena += 1;
    }
}

}
