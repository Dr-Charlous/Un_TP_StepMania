using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class LevelEditor : MonoBehaviour
{
    public List<float> TimeTouch;
    public float TimeS;
    public VideoClip clip;

    private void Update()
    {
        TimeS += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeTouch.Add(TimeS);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WriteString(TimeTouch);
        }

        [MenuItem("Tools/Write file")]
        static void WriteString(List<float> TimeTouch)
        {
            string path = "C:/Users/charles.piercourt/Documents/GitHub/Un_TP_StepMania/TextFile1.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);

            foreach (float item in TimeTouch)
            {
                writer.WriteLine(item);
            }

            writer.Close();
            //Re-import the file to update the reference in the editor
            AssetDatabase.ImportAsset(path);
            TextAsset asset = (TextAsset)Resources.Load("TextFile1");
            //Print the text from the file
            Debug.Log(asset.text);
        }

        //[MenuItem("Tools/Read file")]
        //static void ReadString()
        //{
        //    string path = "C:/Users/charles.piercourt/Documents/GitHub/Un_TP_StepMania/TextFile1.txt";
        //    //Read the text from directly from the test.txt file
        //    StreamReader reader = new StreamReader(path);
        //    Debug.Log(reader.ReadToEnd());
        //    reader.Close();
        //}
    }
}
