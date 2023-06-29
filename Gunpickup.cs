using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpickup : MonoBehaviour
{

    public string weapon;
    public bool debug = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public void setWeapon(string w)
    {
        weapon = w;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<GunFace>() != null)
        {
            GunFace G = collision.gameObject.GetComponent<GunFace>();
            G.setWeapon(weapon);
            if (!debug)
            {
                Destroy(this.gameObject);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GunFace>() != null)
        {
            GunFace G = collision.gameObject.GetComponent<GunFace>();
            G.setWeapon(weapon);
            if (!debug)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
