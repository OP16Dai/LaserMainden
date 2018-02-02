using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlowButton : MonoBehaviour {

    //
    public AudioClip SE;

    //スピーカー(SE用)
    public AudioSource Source;

    public Button button;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick()
    {
        
        Time.timeScale = 0.5f;
            
        
        button.gameObject.SetActive(false);

        //BGMSoundObjectが存在したら
        if (GameObject.FindGameObjectWithTag("BgmSoundObject") != null)
        {

            //取得
            GameObject BSO = GameObject.FindGameObjectWithTag("BgmSoundObject");

            //取得したBGMSoundObjectにAudioSourceが付いていたら
            if (BSO.GetComponent<AudioSource>() != null)
            {
                //取得
                BSO.GetComponent<AudioSource>().Pause();

                
            }

        }

        Source.PlayOneShot(SE);

    }
}
