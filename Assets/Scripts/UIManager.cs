using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private Text pontosUI, bolasUI; //UI

    [SerializeField]
    private GameObject losePainel;
    [SerializeField]
    private GameObject pausePainel;
    [SerializeField]
    private Button pauseBtn;
    private Animator animPause;

    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad (this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
        LigaDesligaPainel();
    }
     void Carrega(Scene cene, LoadSceneMode modo)
        {
            pontosUI = GameObject.Find ("PontosUI"). GetComponent<Text> ();
            bolasUI = GameObject.Find ("bolasUI"). GetComponent<Text> ();
            losePainel = GameObject.Find("PausePanel");
            pausePainel = GameObject.Find("LosePanel ");
            pauseBtn = GameObject.Find("pause").GetComponent<Button>();

            pauseBtn.onClick.AddListener (Pause);
        }

    public void UpdateUI()
    {
        pontosUI.text= ScoreManager.instance.moedas.ToString();
        bolasUI.text= GameManager.instance.bolasNum.ToString ();
    }
    public void GameOverUI()
    {
        losePainel.SetActive(true);
    }
    void LigaDesligaPainel()
    {
        StartCoroutine(tempo());
    }
    void Pause()
    {
        pausePainel.SetActive(true);
        pausePainel.GetComponent<Animator>().Play("MovesUI_pause");
        Time.timeScale = 0;
    }
    IEnumerator tempo ()
    {
        yield return new WaitForSeconds (0.001f);
        losePainel.SetActive(false); 
        pausePainel.SetActive(false);
    }
}
