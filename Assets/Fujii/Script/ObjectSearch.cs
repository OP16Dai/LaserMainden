using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSearch : MonoBehaviour
{

    //破棄したくないオブジェクトを保存する変数
    public GameObject BSO;

    // Use this for initialization
    void Start()
    {


        //現在のシーンに"BgmSoundObject"がついたタグがあるかどうか
        //(今回は手っ取り早くTagでサーチしているが、1つだけ作成すべきオブジェクトが既に生成されているか
        //どうかを調べることができればいいので、Typeサーチなどの他のサーチ方法でもいい)
        if (GameObject.FindGameObjectWithTag("BgmSoundObject") == null)
        {

            //無ければシーンに作成
            GameObject Bgm = Instantiate(BSO);
            //作成したオブジェクトを登録
            DontDestroyOnLoad(Bgm);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
