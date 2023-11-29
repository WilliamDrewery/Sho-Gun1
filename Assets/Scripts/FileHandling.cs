using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

public class FileHandling : MonoBehaviour
{
    public Transform placement;
    public GameObject textObject;
    public TextMeshProUGUI score;

    //defining where the text appears in the game world
    void Start()
    {
        string readFromFilePath = Path.Combine(Application.streamingAssetsPath+"/Recall/"+"Text"+".txt");
        //aquiring text file
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        //writing contents into a list
        int scoreInt = Int32.Parse(score.text);
        string store1 = "";
        string store2 = "";
        foreach (string line in fileLines)
        {
            if (scoreInt > int.Parse(line))
            {
                
                for (int i = 0; i < fileLines.Count; i++)
                {
                    store2 = line;
                    //line = store1;
                    //each score move down one place
                }
                scoreInt = int.Parse(score.text);
                //replace with new score

            }
            Instantiate(textObject, placement);
            textObject.GetComponent<Text>().text = line;
            //writing the text of the text file to a text mesh pro object
        }
        

    }
}