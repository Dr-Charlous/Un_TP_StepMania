using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] List<float> _timeTouch;
    [SerializeField] float _timeS;
    [SerializeField] VideoClip _clip;
    [SerializeField] TextAsset _textFile;

    private void Update()
    {
        _timeS += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timeTouch.Add(_timeS);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WriteString(_timeTouch, _textFile);
        }

        [MenuItem("Tools/Write file")]
        static void WriteString(List<float> TimeTouch, TextAsset _textFile)
        {
            string path = AssetDatabase.GetAssetPath(_textFile);
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
