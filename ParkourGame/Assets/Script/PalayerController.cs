using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PalayerController : MonoBehaviour
{
    public bool isDead;
    public int hiz;
    public float ziplamaKuvveti;
    private float harekety�n�;
    private Rigidbody2D rb;
    private bool zemin;
    public Transform zeminKontrol;
    public float yaricapKontrol;
    public LayerMask zeminNe;
    private int ekstraAtlama;
    public int ekstraZ�plamaSyas�;
    private bool karakterSagY�z = true;
    public GameManager gameManager;
    public GameObject DeatScreen;


    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        if (zemin == true)
        {
            ekstraAtlama = ekstraZ�plamaSyas�;
        }
        if (Input.GetKeyUp(KeyCode.Space) && ekstraAtlama > 0)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
            ekstraAtlama--;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && ekstraAtlama == 0 && zemin == true)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }

        if (karakterSagY�z == false && harekety�n� <0)
        {
            Flip();
        }
        else if(karakterSagY�z == true && harekety�n� > 0)
        {
            Flip();
        }

       
    }

    private void FixedUpdate()
    {
        zemin = Physics2D.OverlapCircle(zeminKontrol.position, yaricapKontrol, zeminNe);
        harekety�n� = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(harekety�n� * hiz, rb.velocity.y);
    }
    private void Flip()
    {
        karakterSagY�z = !karakterSagY�z;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")

        {
            gameManager.UpdateScore();
        }
        if (collision.tag == "next")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;
            DeatScreen.SetActive(true);
        }
    }
}
