using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image barraDeVida;

    public Text textoVida;

    public float vidaActual;

    public float vidaMaxima;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        textoVida.text = (Mathf.FloorToInt(vidaActual)).ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "Enemie")
     {
        vidaActual -= 10;
       

     }

    if( other.gameObject.tag == "Boss")
     {
        vidaActual = 0;
       

     }

      if (Input.GetKeyDown("r") && other.gameObject.tag == "Enemie") {
          
          vidaActual += 10;
    }

    if (other.gameObject.tag == "Food") {
          
          vidaActual += 10;
          Destroy(other.gameObject);
    }
 
    }

}
