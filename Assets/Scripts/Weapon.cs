using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzlePoint;
    [SerializeField] ParticleSystem fireParticleSystem;
    [SerializeField] float rateOfFire = 1.0f;
    [SerializeField] float forceOfFire = 10;
    private ObjectPool ammoPool;
    private bool canFire;

    private void Start()
    {
        canFire = true;
        ammoPool = GameObject.Find("AmmoPool").GetComponent<ObjectPool>();
    }

    public void Fire()
    {
        if (canFire)
        {
            Debug.Log("FireWep");
            canFire = false;
            StartCoroutine(FireCooldown());
            Ammo bullet = ammoPool.GetGameObject(ammo).GetComponent<Ammo>();
            bullet.Fire(muzzlePoint.transform.position, transform.rotation,transform.forward * forceOfFire, Vector3.zero);
            fireParticleSystem.Play();
        }
    }
    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(rateOfFire);
        canFire = true;
    }
}
