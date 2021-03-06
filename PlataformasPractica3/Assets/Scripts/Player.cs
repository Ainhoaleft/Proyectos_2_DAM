using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas
public class Player : MonoBehaviour
{
    private float xInicial, yInicial;
    [SerializeField] float velocidad = 5f;
    private Animator anim;

    private float alturaPersonaje;
    
    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if ((horizontal > 0.1f) || (horizontal < -0.1f))
            
            if(horizontal < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        anim.Play("Corriendo");
        
            transform.Translate(
                horizontal * velocidad * Time.deltaTime,
                0,0);

        float salto = Input.GetAxis("Jump");

        if (salto > 0)
        {
            RaycastHit2D impacto = Physics2D.Raycast(
                transform.position,
                new Vector2(0,-1));
            if ( impacto.collider != null)
            {
                float distaciaAlSuelo = impacto.distance;
                bool tocandoElSuelo = distaciaAlSuelo < alturaPersonaje;

                if (tocandoElSuelo)
                {
                    Vector3 fuerzaSalto = new Vector3(0,20,0);
                    GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);
                    anim.Play("Saltando");
                }
                
            }
          
        }
    }
    
   public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial,0);
        
    }
}