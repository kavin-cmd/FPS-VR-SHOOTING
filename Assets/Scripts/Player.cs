using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public static float health = 100.0f;
    [SerializeField] Transform head;

    private AudioClip hitSound;
    private AudioClip doneSound;

    // global variables
    [SerializeField] public static int targetsHit;
    public static int targetsMax = 0;
    public static float gameTime;

    private void resetGame()
    {
        gameTime = 0.0f;
        targetsHit = 0;
        transform.position = new Vector3(-7.94f, 0.0f, 12.76f);
        health = 100.0f; // change this value later maybe?
        AudioSource.PlayClipAtPoint(doneSound, transform.position, 1.0f);
    }
   
    private void Start()
    {
        hitSound = Resources.Load<AudioClip>("playerHurt");
        doneSound = Resources.Load<AudioClip>("timeOut");
    }

    private void FixedUpdate()
    {
        if (gameTime >= 120.0f)
        {
            resetGame();
            // reset is spread out through the different scripts because I don't know how to do it any other way
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.8f);
        Debug.LogError(string.Format("Player health: {0}",health));
		if (health <= 0.0f) {
			resetGame();
		}
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }

}
