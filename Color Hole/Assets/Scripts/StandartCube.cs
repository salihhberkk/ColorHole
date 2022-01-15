using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb.sleepThreshold = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoToPlayer();
            gameObject.layer = LayerMask.NameToLayer("Test");
            GameManager.Instance.CollectCube();

            var diamondExplosionParticle = ObjectPooler.Instance.GetPooledObject("GreenParticle");
            diamondExplosionParticle.transform.position = transform.position;
            diamondExplosionParticle.SetActive(true);
            diamondExplosionParticle.GetComponent<ParticleSystem>().Play();
        }
    }

    public void GoToPlayer()
    {
        var dir = PlayerMovement.Instance.transform.position - gameObject.transform.position;
        rb.AddForce(dir * 200f);
        rb.AddTorque(dir * 1000f);
    }
}
