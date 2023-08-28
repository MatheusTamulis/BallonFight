using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public float speed;
    
    public Text txt;

    public AudioSource[] sons;

    public float velocidadeImpulso;

    float x;

    int pontos = 0;

    bool impulso;

    Vector2 meuX;
    Vector2 meuY;

    SpriteRenderer sp;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sons = GetComponents<AudioSource>(); //Quando for pegar mais de um componente igual usar GetComponents (com S no final, plural)

        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = pontos.ToString();

        Movimento();
        VirarSprite();
        PuloTrue();
        Teleporte();
        MudarCena();
    }

    private void FixedUpdate()
    {
        Flutuar();
    }

    void Movimento()
    {
        x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, 0.0f, 0.0f);
    }

    void VirarSprite()
    {
        if (x < 0.0f)
        {
            sp.flipX = true;
        }
        else if (x > 0.0f) 
        {
            sp.flipX= false;
        }
    }

    /*void Flutuar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sons[0].Play();
            rb.gravityScale = -1.3f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 0.3f;
        }
    }*/

    void PuloTrue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sons[0].Play();
            impulso = true;
        }
    }

    void Flutuar()
    {
        if (impulso) 
        {
            rb.velocity = new Vector2(0.0f, velocidadeImpulso);
            impulso = false;
        }
    }

    void Teleporte()
    {

        if (transform.position.x > 9.85f)
        {
            meuX = new Vector2(-8.95f, transform.position.y);
            transform.position = meuX;
        }
        else if (transform.position.x < -9.85f)
        {
            meuX = new Vector2(8.95f, transform.position.y);
            transform.position = meuX;
        }

        if (transform.position.y > 6.36f)
        {
            meuY = new Vector2(transform.position.x, -6.34f);
            transform.position = meuY;
        }
        else if (transform.position.y < -6.37f)
        {
            meuY = new Vector2(transform.position.x, 6.34f);
            transform.position = meuY;
        }

    }

    void MudarCena()
    {
        if (pontos == 10)
        {
            SceneManager.LoadScene("TittleScreen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moeda")
        {
            sons[1].Play();
            pontos++;
        }
    }
}
