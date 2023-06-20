using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{


    [SerializeField] ParticleSystem crashVfx;


    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        // Debug.Log($"{this.name} triggered by {other.gameObject.name}");
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        crashVfx.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadScene), 1.5f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log($"{this.name} collided with {collision.gameObject.name}");
    }
}
