using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas
public class Items : MonoBehaviour
{
    [SerializeField] AudioClip sonido;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        FindObjectOfType<GameController>().SendMessage("AnotarItemRecogido");
        AudioSource.PlayClipAtPoint(sonido, transform.position);
        Destroy(gameObject);
    }
}
