using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerLog : MonoBehaviour
{
   
    public int maxLines = 2;
    private Queue<string> queue = new Queue<string>();
    private string Mytext = "";
    

    public void NewActivity(string activity)
    {
        if (queue.Count >= maxLines)
            queue.Dequeue();

        queue.Enqueue(activity);

        Mytext = "";
        foreach (string st in queue)
            Mytext = Mytext + st + "\n";
    }


    void OnGUI()
    {

        GUI.Label(new Rect(0,                             // x, left offset
                     (0),            // y, bottom offset
                     300f,                                // width
                     100f), Mytext, GUI.skin.textArea);    // height, text, Skin features

    }
}
