using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //大鼓 古琴 古筝 琵琶 
    
    public bool[] PlayerStatus = new bool[5];
    public AudioSource[] audioSources;
    public bool SongisStarted = false;
    public int firstPlayer;

    void Awake() 
    {
        //Set all to false
        for (int i = 0; i < 5; i++)
        {
            PlayerStatus[i] = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //当任一image target 初次检测到时，playsong，但是将其它声部设为静音
        if(!SongisStarted)
        {
            for(int i = 0; i < 5; i++)
            {
                if(PlayerStatus[i])
                {
                    firstPlayer = i;
                    BegintheSong(firstPlayer);
                    SongisStarted = true;
                    break;
                }
            }
        }
        //检测到新的target，播放声音
        Unmute();
        //target消失，静音
        Mute();
        //都没有时，停止播放
        EndtheSong();
    }

    void BegintheSong(int playerIndex)
    {
        // 首次播放
        for(int i = 0; i < 5; i++)
        {
            audioSources[i].Play();//各个声部都开始播放，防止延时
        }
        for (int i = 0; i < 5; i++) // MuteAllExcept
        {
            if (i != playerIndex)
            {
                audioSources[i].mute = true;
            }
        }
        //除了第一个以外，其它都静音

        Debug.Log("Song is Started");
    }

    void Mute(){
        for (int i = 0; i < 5; i++) // MuteAllExcept
        {
            if (PlayerStatus[i] == false)
            {
                audioSources[i].mute = true;
            }
        }
    }
    void Unmute(){
        for (int i = 0; i < 5; i++) // MuteAllExcept
        {
            if (PlayerStatus[i] == true)
            {
                audioSources[i].mute = false;
            }
        }
    }

    public void EndtheSong(){
        if(AllMuted())
        {
            SongisStarted = false;
            Debug.Log("Song is Ended");
        }
    }

    bool AllMuted(){
        for (int i = 0; i < 5; i++) // MuteAllExcept
        {
            if (PlayerStatus[i] == true)
            {
                return false;
            }
        }
        return true;
    }

    public void ResetAudio()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerStatus[i] = false;
        }
        Mute();
        SongisStarted = false;

    }
}
