using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour
{
    //Posição seta
    [SerializeField] private Transform posStart;
    //Seta
    public Image setaImg;
    public GameObject setaGO;
    //Ang
    public float zRotate;
    public bool liberaRot = false;
    public bool liberaTiro = false;

    
    void Start()
    {
         posStart = GameObject.Find ("posStart").GetComponent<Transform>();
        setaImg = GameObject.Find ("Seta").GetComponent<Image>();
        setaGO = GameObject.Find ("Seta");

        PosicionaBola();

    }

    void Update()
    {
        PosicionaSeta();
        RotacaoSeta();
        InputDeRotacao();
        LimitaRotacao();
    
    }
    void PosicionaSeta() //Posição seta
    {
        setaImg.rectTransform.position = transform.position;
    }
    void PosicionaBola() //Posição Bola
    {
        this.gameObject.transform.position = posStart.position;
    }
    void RotacaoSeta() //angulaçao
    {
         setaImg.rectTransform.eulerAngles = new Vector3(0,0,zRotate);
    }
    void InputDeRotacao()
    {
      /*  if(Input.GetKey(KeyCode.UpArrow)) //seta para cima
        {
            zRotate += 2.5f;
        }
        if(Input.GetKey(KeyCode.DownArrow))//seta para baixo
        {
            zRotate -= 2.5f;
        }*/
        if(liberaRot == true) //movemetçao do mose
        {
            
            float moveY = Input.GetAxis ("Mouse Y");

            if(zRotate < 90)
            {
                if(moveY > 0)
                 {
                    zRotate += 2.5f;
                }
            }

            if(zRotate > 0)
            {
              if(moveY < 0)
             {
                zRotate -= 2.5f;
             }
            }
           

        }
    }
    void LimitaRotacao() //limita a rotação
    {
        if(zRotate >= 90)
        {
            zRotate =90;
        }
        if(zRotate <=0)
        {
            zRotate = 0;
        }
    }

    void OnMouseDown()
    {
        liberaRot = true;
        setaGO.SetActive(true);//ativa seta
    }

    void OnMouseUp()
    {
        liberaRot = false;
        liberaTiro = true;
        setaGO.SetActive(false);//desativa seta
        AudioManager.instance.SonsFXToca (1);    }
}
