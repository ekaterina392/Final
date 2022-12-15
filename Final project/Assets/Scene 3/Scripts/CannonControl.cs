using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public AudioSource CannonShoot;
    public ParticleSystem Shoot;
    public Transform _Player;
    private float distance;
    public float howClose;
    public Transform head, barrel;
    public GameObject _projectile;
    public float fireRate, nextFire;

    private void Update()
    {
        distance = Vector3.Distance(_Player.position, transform.position);
        if (distance <= howClose)
        {
            head.LookAt(_Player);
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                shoot();
                CreateParticles();
                CannonShoot.Play();
            }
        }
    }

    void shoot()
    {
        GameObject clone = Instantiate(_projectile, barrel.position, head.rotation);
        //force forward 1500    
        clone.GetComponent<Rigidbody>().AddForce(head.forward * 5000);
        
        //10 is amount of seconds after which projectile are destroyed
        Destroy(clone, 10);
    }
    
    void CreateParticles()
    {
        Shoot.Play();
    }
}
