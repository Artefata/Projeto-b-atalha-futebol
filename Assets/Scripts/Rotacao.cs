using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour
{
    //Posição Seta
    [SerializeField]private Transform posStart;
    //seta
    [SerializeField]private Image setaImag;
    //Ang
    public float zRotate;
    public bool liberaRot = false;
    public bool libereTiro = false;
    
    // Start is called before the first frame update
    void Start()
    {
        PosicionaSeta();
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoSeta();
        InputDeRotacao();
        LimitaRotacao();

    }
    void PosicionaSeta()//posicao da seta
    {
        setaImag.rectTransform.position = posStart.position;
    }
    void PosicionaBola () //posicao da bola
    {
        this.gameObject.transform.position=posStart.position;
    }
    void RotacaoSeta()
    {
        setaImag.rectTransform.eulerAngles = new Vector3(0,0,zRotate);
    }

    void InputDeRotacao() // controle de teclado
    {/*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zRotate += 2.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            zRotate -= 2.5f;
        }
        */

        if(liberaRot == true)
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
    void LimitaRotacao()
    {
        if(zRotate >= 90)
        {
            zRotate = 90;
        }
        if(zRotate <= 0)
        {
            zRotate = 0;
        }
    }

    //força com mouse
    void OnMouseDown()
    {
        liberaRot = true;
    }

    void OnMouseUp()
    {
        liberaRot = false;
        libereTiro =true;
    }
}
