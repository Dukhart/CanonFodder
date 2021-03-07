using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int damage;
    Rigidbody m_Rigidbody;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Fire(Vector3 pos, Quaternion rot, Vector3 force, Vector3 torque)
    {
        transform.SetPositionAndRotation(pos, rot);

    }
}
