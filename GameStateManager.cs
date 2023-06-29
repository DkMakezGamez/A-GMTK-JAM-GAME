using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
 

    public int lives = 6;
    public Vector2 deathlocale = Vector2.negativeInfinity;
    string deathweapon;

    public Gunpickup gunpickprefab;

   // public  int StartFruits = 0;

   // public float collsize;

   // public float xsize = 1;

    //public Vector3 checkpointpos;

  

    public void BombDia()
    {
        
      
    }

    
public int getlives()
    {
        return lives;
    }

  

   



    private static GameStateManager instance;

    public static GameStateManager Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deathlocale != Vector2.negativeInfinity)
        {
            Gunpickup g = GameObject.Instantiate(gunpickprefab, deathlocale, this.transform.rotation);
            g.setWeapon(deathweapon);
            deathlocale = Vector2.negativeInfinity;
        }
    }

  
    public void ChangeLives(int DeltaChange)
    {
        lives += DeltaChange;
        //insert negative nubmer to deal damage.
    }

   

    
    public void OnDeath()
    {
        Debug.Log("death trigger");
        ChangeLives(-1);

        if (lives < 0)
        {
            Debug.Log("no lives!");
            GameObject p = GameObject.Find("Player");

            GunFace pg = p.GetComponent<GunFace>();

            deathlocale = p.transform.position;
            deathweapon = pg.Weapon;

                
            lives = 6;
            //int randy = math.random(0,numweapons)
            //string rand;
            //switch case
            // case randy = 0;
            // rand = "Pistol";
            //break;
            //etc...
            // pg.setweapon(rand)
            //SceneManager.LoadScene("GameOver");
        }
    }
 
}
