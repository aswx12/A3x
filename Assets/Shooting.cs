using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public bool objectPool;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Invoke("Shoot", 1f);
       // if (!objectPool)
            Shoot();
        //else
        //    ShootObjectPool();
    }


  

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }

    //void ShootObjectPool()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
    //        Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //        rb.AddForce(firePoint.forward * bullForce, ForceMode.Impulse);
    //        if (bullet != null)
    //        {
    //            bullet.transform.position = firePoint.position;
    //            bullet.SetActive(true);
    //        }

    //    }
    //}

}
