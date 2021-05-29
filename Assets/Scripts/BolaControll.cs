using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BolaControll : MonoBehaviour
{
    //Posição Seta
    [SerializeField]private Transform posStart;
    //seta
    [SerializeField]
    public GameObject setaGO;
    //Ang
    public float zRotate;
    public bool liberaRot = false;
    public bool libereTiro = false;

    //Força
      private Rigidbody2D bola;
      private float force = 0;
      public GameObject seta2Imag;

    void Awake ()
    {
        
        setaGO = GameObject.Find ("Seta");
        seta2Imag = setaGO.transform.GetChild (0).gameObject;
        setaGO.SetActive (false);

    }

    // Start is called before the first frame update
    void Start()
    {
        posStart = GameObject.Find("posStart").GetComponent<Transform>();
         PosicionaBola();
//Força
       
        bola = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoSeta();
        InputDeRotacao();
        LimitaRotacao();
        PosicionaSeta();
        //Força
        ControlaForca ();
        AplicaForca   ();

    }
     void PosicionaSeta()//posicao da seta
    {
        setaGO.GetComponent<Image>().rectTransform.position = transform.position;
    }
    void PosicionaBola () //posicao da bola
    {
        this.gameObject.transform.position=posStart.position;
    }
    void RotacaoSeta()
    {
        setaGO.GetComponent<Image>().rectTransform.eulerAngles = new Vector3(0,0,zRotate);
    }

    void InputDeRotacao() // controle de teclado
    {

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
        setaGO.SetActive (true);
    }

    void OnMouseUp()
    {
        liberaRot = false;
        libereTiro =true;
        setaGO.SetActive (false);
        AudioManager.instance.SonsFXToca(1);
    }

    //Força
     void AplicaForca()
    { 
        float x = force * Mathf.Cos (zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin (zRotate * Mathf.Deg2Rad);

        if(libereTiro == true)// clique mouse D (Input.GetKeyUp(KeyCode.Space) code tecla espaso )
        {
            bola.AddForce (new Vector2 (x, y));
            libereTiro = false;
        }
    } 

    void ControlaForca()
    {
        if(liberaRot == true) //medino a força
        {
            float moveX = Input.GetAxis ("Mouse X");
            
            if(moveX  < 0)
            {
                seta2Imag.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
                force = seta2Imag.GetComponent<Image>().fillAmount * 1000;
            }
            if(moveX  > 0)
            {
                seta2Imag.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
                force = seta2Imag.GetComponent<Image>().fillAmount * 1000;
            }
        }

    }

    void BolaDinamica()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
