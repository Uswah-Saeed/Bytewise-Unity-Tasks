using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class collectible_count
{


    private static collectible_count instance;

    /* private int kills;*/
    private int score = 0;

    private collectible_count()
    {

    }
    public static collectible_count GetInstance()
    {
        if (instance == null)
        {
            instance = new collectible_count();  //kisi static function k under non static variable ko call nhi kr sakte - vice versa kr sakte
        }                                //non static bnte tb hain jb object create hota hai

        return instance;

    }
    public void addScore(int score)
    {  //setter
        this.score += score;
        /*Debug.Log("this is scoreee   " + score);
*/
        UpdateCount();
    }
    public int getScore() { return this.score; }

    /*
        public void addkills(int kills)
        {
            this.kills++;
        }
        public int getkills()
        {
            return this.kills;
        }*/
    void Awake() => UpdateCount();
    void UpdateCount()
    {
        if (GameObject.FindWithTag("ScoreTag") != null)
        {
            GameObject.FindWithTag("ScoreTag").GetComponent<Text>().text = $"{score} / {collectibles.total}";
        }
        if (score == collectibles.total)
        {
            doorOpen.win = true;
        }
    }

}


