using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forca : MonoBehaviour
{
      private Rigidbody2D bola;
      private float force = 0;
      private Rotacao rot; // ter acesso aqui eu vou ter acesso a Z
    public Image seta2Imag;

    void Start()
    {
        bola = GetComponent<Rigidbody2D>();
        rot = GetComponent<Rotacao>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlaForca ();
        AplicaForca   ();
    }

    void AplicaForca()
    { 
        float x = force * Mathf.Cos (rot.zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin (rot.zRotate * Mathf.Deg2Rad);

        if(rot.libereTiro == true)// clique mouse D (Input.GetKeyUp(KeyCode.Space) code tecla espaso )
        {
            bola.AddForce (new Vector2 (x, y));
            rot.libereTiro = false;
        }
    } 

    void ControlaForca()
    {
        if(rot.liberaRot == true) //medino a força
        {
            float moveX = Input.GetAxis ("Mouse X");
            
            if(moveX  < 0)
            {
                seta2Imag.fillAmount += 0.8f * Time.deltaTime;
                force = seta2Imag.fillAmount * 1000;
            }
            if(moveX  > 0)
            {
                seta2Imag.fillAmount -= 0.8f * Time.deltaTime;
                force = seta2Imag.fillAmount * 1000;
            }
        }

    }
}
