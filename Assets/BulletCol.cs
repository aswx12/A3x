using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCol : MonoBehaviour
{
    // Start is called before the first frame update
    public bool objectPool;
    float activeDuration;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletDestroy(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!objectPool)
            Destroy(gameObject);
            else
            {
                gameObject.SetActive(false);

            }
        }
    }

    void BulletDestroy()
    {
        activeDuration += Time.deltaTime;
        if (activeDuration >= 5)
        {
            //if (!objectPool)
                Destroy(gameObject);
            //else
            //    gameObject.SetActive(false);
        }
    }

}
