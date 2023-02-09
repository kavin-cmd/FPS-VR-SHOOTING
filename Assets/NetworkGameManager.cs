using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
using TMPro;

public class NetworkGameManager : MonoBehaviour
{
    NetworkObject myPlayer;
    [SerializeField] private Transform myText;

    // Start is called before the first frame update
    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("project");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            myPlayer = VelNetManager.NetworkInstantiate("PlayerAvatar");
            //myText = GameObject.Find("ScoreText");
            myText = myPlayer.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        };
    }

    // Update is called once per frame
    void Update()
    {
        GameObject manager = GameObject.Find("XR Origin");
        if (myPlayer != null && manager != null)
        {
            myPlayer.transform.position = manager.transform.position;

            if (myText != null)
            {
                myText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + Player.targetsHit + "\nHEALTH: " + Player.health + "\nTIME LEFT: " + (120.0f - Mathf.Floor(Player.gameTime));
            }

            Player.gameTime += Time.deltaTime;
        }
    }
}
