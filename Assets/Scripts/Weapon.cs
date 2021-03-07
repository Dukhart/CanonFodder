using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] ParticleSystem fireParticleSystem;
    [SerializeField] float rateOfFire = 1.0f;
    private ObjectPool ammoPool;
    private bool canFire;

    private void Start()
    {
        ammoPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    public void Fire()
    {
        if (canFire)
        {
            canFire = false;
            StartCoroutine(FireCooldown());
            GameObject bullet = ammoPool.GetGameObject(ammo);
            bullet.GetComponent<Ammo>();

        }
    }
    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(rateOfFire);
        canFire = true;
    }
}
