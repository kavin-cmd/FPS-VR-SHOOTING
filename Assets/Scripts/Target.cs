using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioClip targetSound;
    private AudioClip winSound;
    private bool registered = false;

    // Start is called before the first frame update
    void Start()
    {
        targetSound = Resources.Load<AudioClip>("targetHit");
        winSound = Resources.Load<AudioClip>("win");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.gameTime < 0.25f)
        {
            GetComponent<MeshRenderer>().enabled = false;
            Player.targetsMax = 0;
            registered = false;
        }
        // randomly decide which targets appear
        else if (Player.gameTime >= 0.25f && !registered)
        {
            float result = UnityEngine.Random.Range(0.0f, 1.0f);
            if (result <= 0.5f)
            {
                GetComponent<MeshRenderer>().enabled = true;
                Player.targetsMax++;
            }
            
            registered = true;
        }
    }

    // collider
    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<MeshRenderer>().enabled)
        {
            AudioSource.PlayClipAtPoint(targetSound, transform.position, 1.0f);
            Player.targetsHit++;
            GetComponent<MeshRenderer>().enabled = false;
            if (Player.targetsHit >= Player.targetsMax)
            {
                AudioSource.PlayClipAtPoint(winSound, transform.position, 0.8f);
            }

            //Destroy(gameObject);
        }
    }
}
