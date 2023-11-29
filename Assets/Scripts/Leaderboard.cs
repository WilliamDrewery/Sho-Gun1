using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    private Transform group;
    private Transform template;
    [SerializeField] TextMeshProUGUI posText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] int scoreGlobal;
    private List<HighscoreEntry> HighscoreList;
    private List<Transform> highscoreEntryTransformList;
    //defining variables and lists

    private void Awake()
    {
        group = transform.Find("Highscores");
        template = group.Find("EntryTemplate");
        //these variables are assigned to the game objects named "Highscores" and "EntryTemplate"
        
        template.gameObject.SetActive(false);
        HighscoreList = new List<HighscoreEntry>
        {
            new HighscoreEntry{score=6700, name="SHI"},
            new HighscoreEntry{score=6200, name="JAS"},
            new HighscoreEntry{score=5300, name="DAV"},
            new HighscoreEntry{score=4800, name="CRE"},
            new HighscoreEntry{score=1030, name="LUK"},
        };// defining example scores
        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in HighscoreList)
        {
            CreateEntryTransform(highscoreEntry, group, highscoreEntryTransformList);
            //running the function for each entry
        }
    }
    private void CreateEntryTransform(HighscoreEntry highscoreEntry, Transform scoreGroup, List<Transform> transformList)
    {
        float height = 100f;
        Transform entryTransform = Instantiate(template, group);
        RectTransform entryRect = entryTransform.GetComponent<RectTransform>();
        entryRect.anchoredPosition = new Vector2(0, -height * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        //each entry is positioned further down the screen than the last
        int pos = transformList.Count + 1;
        string posStr;
        switch (pos)
        {
            default:
                posStr = pos + "TH"; break;
            case 1: posStr = "2nd"; break;
            case 2: posStr = "3rd"; break;
            case 3: posStr = "4th"; break;
            case 4: posStr = "5th"; break;
        }//defining the positions 
        posText.text = posStr;
        int score=highscoreEntry.score;
        scoreText.text = score.ToString();
        string name = highscoreEntry.name;
        nameText.text = name;
        // implementing the new defined scores and names into the list in game
        transformList.Add(entryTransform);
    }
    private void Update()
    {
        //for (int i=0; i<HighscoreList.Length; i++)
       // {
           // if (scoreGlobal > HighscoreList[i])
           // {
            //    int store = HighscoreList[i];
            //    HighscoreList[i] = scoreGlobal;

         //   }
     //   }
    }
    private class HighscoreEntry
    {
        public int score;
        public string name;
        // defining HighscoreEntry as including the score and name
    }
}
// made with help from this video: https://www.youtube.com/watch?v=iAbaqGYdnyI

