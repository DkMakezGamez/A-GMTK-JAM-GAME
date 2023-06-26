using System;
using System.Collections.Generic;
using UnityEngine;

public class GunFace : MonoBehaviour
{
    public Bullet projPrefab;
    public Bomb RPGprefab;
  

    private enum State
    {
        Normal,
    }

   // private PlayerMain playerMain;
    public string Weapon = "Pistol";
    
   
    Animator anim;
    public float angleoffset = 45f;

    public float pistolcool = 2f;
    public float shotcool = 5f;
    public float riflecool = 0.5f;
    public float RPGcool = 15f;
    public float snipecool = 20f;




    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (anim == null){
            Debug.LogError("Animator not found");
        }
    }


    public void setWeapon(string Sweapon)
    {
        Weapon = Sweapon;
        pistolcool = 2f;
     shotcool = 5f;
     riflecool = 0.5f;
        RPGcool = 15f;
     snipecool = 20f;
}
  



    // Update is called once per frame
    void Update()
    {
       // Grendaes = GameStateManager.Instance.getBombs();
        Vector3 Mouseposition = Input.mousePosition;

        Mouseposition = Camera.main.ScreenToWorldPoint(Mouseposition);

        Vector2 Direction = new Vector2(
            Mouseposition.x - transform.position.x,
             Mouseposition.y - transform.position.y
             );


        transform.up = Direction;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            onShoot(Direction);
        }

       



        pistolcool -= Time.deltaTime;
        shotcool -= Time.deltaTime;
        riflecool -= Time.deltaTime;
        RPGcool -= Time.deltaTime;
        snipecool -= Time.deltaTime;

        if(pistolcool <= 0f)
        {
            anim.SetBool("Rollin", true);
           // Debug.Log("here");
        }

        if (Input.GetAxis("Fire1") != 0)
        {
          
            onShoot(Direction);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            Debug.Log("hit");
            GameStateManager.Instance.OnDeath();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            Debug.Log("hit");
        }
    }

    public void onShoot(Vector2 d)
    {




        if (pistolcool <= 0f && Weapon == "Pistol")
        {


            Bullet temp = GameObject.Instantiate(projPrefab, new Vector3(this.transform.position.x + d.x, this.transform.position.y + d.y), this.transform.rotation);

            temp.transform.position = this.transform.position + this.transform.up * 0.4f * Mathf.Sign(this.transform.localScale.x);
            // temp.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);


            temp.setDirection(d);
            pistolcool = 2f;
            //anim.SetBool("Rollin", false);
            //anim.SetInteger("Rollno", bulletnum);
            string debug = anim.GetInteger("Rollno").ToString();
            // Debug.Log(bulletnum + " " + debug);

        }
        else if (shotcool <= 0f && Weapon == "Shotgun")
        {

            for (int i = 0; i < 3; i++)
            {
                // Debug.Log("ran ");
                Bullet temp = GameObject.Instantiate(projPrefab, new Vector3(this.transform.position.x + d.x, this.transform.position.y + d.y), this.transform.rotation);

                temp.transform.position = this.transform.position + this.transform.up * 0.4f * Mathf.Sign(this.transform.localScale.x);
                // temp.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

                temp.setDirection(d * (Mathf.Deg2Rad * (angleoffset * i)));


            }




            shotcool = 5f;
        } else if (riflecool <= 0f && Weapon == "Rifle")
        {

            Bullet temp = GameObject.Instantiate(projPrefab, new Vector3(this.transform.position.x + d.x, this.transform.position.y + d.y), this.transform.rotation);

            temp.transform.position = this.transform.position + this.transform.up * 0.4f * Mathf.Sign(this.transform.localScale.x);
            // temp.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);


            temp.setDirection(d);
            pistolcool = 2f;
           
        }else if (RPGcool <= 0f && Weapon == "RPG")
        {
            Bullet temp = GameObject.Instantiate(projPrefab, new Vector3(this.transform.position.x + d.x, this.transform.position.y + d.y), this.transform.rotation);

            temp.transform.position = this.transform.position + this.transform.up * 0.4f * Mathf.Sign(this.transform.localScale.x);
        }
    }
        
        
       
      
                   
                
     }




