using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildScript  
{

    public static void BuildAndroid()
    {
        string[] scenes = { "Assets/Scenes/SampleScene.unity" }; 
        string outputPath = "xd-game.apk";   
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.None);
    }

}








