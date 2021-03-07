using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int lifeTime; // in seconds
    Rigidbody m_Rigidbody;
    Coroutine lifeDecay;
    private void Awake()
    {
        // get components
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        lifeDecay = StartCoroutine(LifeDecay());
    }
    IEnumerator LifeDecay ()
    {
        yield return new WaitForSeconds(lifeTime);
        Die();
    }
    // launches the ammo
    public void Fire(Vector3 pos, Quaternion rot, Vector3 force, Vector3 torque)
    {
        Debug.Log("FireAmmo");
        transform.SetPositionAndRotation(pos, rot);
        m_Rigidbody.AddForce(force, ForceMode.Impulse);
        m_Rigidbody.angularVelocity = torque;
    }
    // detect hits
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Target");
            Die();
        } else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Miss! hit Ground");
            Die();
        }
    }
    // remove the ammo
    void Die ()
    {
        StopAllCoroutines();
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    public void StopLifeDecay ()
    {
        StopCoroutine(lifeDecay);
    }
}
