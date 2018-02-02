using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarrierButtonScript : MonoBehaviour {

    //
    public AudioClip SE;

    //スピーカー(SE用)
    public AudioSource Source;

    public Button button;

    //プレイヤー保管
    public GameObject Player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick()
    {
        if (Player.GetComponent<Rigidbody>() != null)
        {
            
            Player.GetComponent<Rigidbody>().isKinematic = true;


            GameObject.FindGameObjectWithTag("Robot").gameObject.GetComponent<Renderer>().material.color = new Color(220,220,220);

            Source.PlayOneShot(SE);
        }
        button.gameObject.SetActive(false);
    }
}
