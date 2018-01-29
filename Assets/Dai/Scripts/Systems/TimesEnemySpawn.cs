﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesEnemySpawn : MonoBehaviour
{

    //プレイヤー保管
    GameObject Player;

    //生成するプレファブ（敵）
    public GameObject[] Prefabs;
    //生成する位置
    Vector3 EnemyPos;

    //ステージ開始からの経過時間(フレーム数)
    int StageTime = 0;

    //敵出現タイミング
    int EnemyTime = 0;
    //敵の出撃位置
    float SpawnPositionZ = 50.0f;
    //敵出現間隔（このフレーム数おきに敵を出現）
    int EnemySpawnTime = 130;
    //敵の出現位置間隔
    float Spawn = 20.0f;
    //敵の出撃タイプの選択
    int EnemyType = 0;

    // Use this for initialization
    void Start()
    {
        //プレイヤー
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが死んでいたら停止
        if (Player == null)
        {
            return;
        }

        //=================================================
        //  敵の出撃
        //=================================================
        //一定時間経過(EnemySpawnTimeフレームおきに出現)
        if (EnemySpawnTime <= EnemyTime)
        {
            /*
             * @desc    プレファブの生成
             * @param   生成するプレファブ
             * @param   生成する位置
             * @param   生成するときの向き
             */
            //GameObject.Instantiate(Prefabs, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));           


            //======================================================================================
            //  出撃処理
            //======================================================================================
            //敵の出撃
            GameObject.Instantiate(Prefabs[EnemyType], new Vector3(0.0f, 0.0f, SpawnPositionZ), new Quaternion(0, 0, 0, 0));

            //出撃したらカウントをリセット
            EnemyTime = 0;

            //敵の出撃位置の更新
            SpawnPositionZ += Spawn;

            //出撃する敵を次のタイプへ
            this.EnemyType++;
        }


        //=================================================
        // 敵出現タイミングカウント
        //=================================================
        EnemyTime++;

        //=================================================
        // 経過時間(フレーム数)
        //=================================================
        StageTime++;
    }
}
