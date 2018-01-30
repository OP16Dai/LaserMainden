using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Stage_System : MonoBehaviour {


    //ステージ開始時に再生するBGM
    public AudioClip NowBGM;
    //ステージ終了後のシーン遷移先で再生するBGM
    public AudioClip NextBGM;
    //ゲームクリア時のSE
    public AudioClip clear_SE;

    //スピーカー(SE用)
    public AudioSource clear_Source;

    //スピーカー(BGM用)
    public AudioSource AS;

    //プレイヤー保管
    GameObject Player;

    //プレイヤーがゲームをクリアしたかどうか
    bool clear = false;

    

    


    // Use this for initialization
    void Start()
    {
        //プレイヤー
        Player = GameObject.FindGameObjectWithTag("Player");
 
        //BGMSoundObjectが存在したら
        if (GameObject.FindGameObjectWithTag("BgmSoundObject") != null)
        {

            //取得
            GameObject BSO = GameObject.FindGameObjectWithTag("BgmSoundObject");
            
            //取得したBGMSoundObjectにAudioSourceが付いていたら
            if(BSO.GetComponent<AudioSource>() != null)
            {
                //取得
                this.AS = BSO.GetComponent<AudioSource>();
                //クリップにシーンのBGMを追加
                this.AS.clip = NowBGM;
                //再生
                this.AS.Play();

            }
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが死んだら
        if (this.Player == null)
        {
            //GameFinish関数を実行
            Invoke("GameFinish", 4.5f);


        }

        //プレイヤーがゲームをクリアしていたら
        if(this.clear == true)
        {
            //BGMを徐々に下げる

            //音量を下げる
            this.AS.volume -= 0.004f;

        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        //GameFinish関数を実行
        Invoke("GameFinish", 4.5f);

        //ゲームクリア音を再生
        clear_Source.PlayOneShot(clear_SE,0.1f);

        //クリアフラグにtrueを代入
        clear = true;

    }

    void GameFinish()
    {

        //クリップに次のシーンのBGMを追加
        this.AS.clip = NextBGM;
        //再生
        this.AS.Play();

        //音量を戻す
        this.AS.volume = 0.5f;

        //シーンの遷移
        SceneManager.LoadScene("StageSelectScene");
    }
}
