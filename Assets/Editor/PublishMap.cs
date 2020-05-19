using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Publish : EditorWindow
{
    [MenuItem("Publish/Export Map")]
    static void bangbangPublish()
    {
        EditorWindow.GetWindow(typeof(Publish));
    }

    private void OnGUI()
    {
        GUILayout.Label("-- Only change if you know what you are doing");
        AssetBundleTitle = EditorGUILayout.TextField("Asset Bundle Name", AssetBundleTitle);

        GUILayout.Label("-- Mod Build Settings");
        MapExportTitle = EditorGUILayout.TextField("Exported map filename", MapExportTitle);

        if (GUILayout.Button("Publish")) BuildAssetBundles(AssetBundleTitle, MapExportTitle);
    }

    string AssetBundleTitle = "level";
    string MapExportTitle = "MyMod";

    private static void BuildAssetBundles(string assetBundleTitle, string mapExportTitle)
    {
        if (Directory.Exists(Application.dataPath + "/ExportDirectory")) Directory.Delete(Application.dataPath + "/ExportDirectory", true);
        Directory.CreateDirectory(Application.dataPath + "/ExportDirectory");

        BuildPipeline.BuildAssetBundles(Application.dataPath + "/ExportDirectory", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
        File.Move(Application.dataPath + "/ExportDirectory/" + assetBundleTitle, Application.dataPath + "/ExportDirectory/" + mapExportTitle + ".win.level");

        BuildPipeline.BuildAssetBundles(Application.dataPath + "/ExportDirectory", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneOSX);
        File.Move(Application.dataPath + "/ExportDirectory/" + assetBundleTitle, Application.dataPath + "/ExportDirectory/" + mapExportTitle + ".osx.level");

        BuildPipeline.BuildAssetBundles(Application.dataPath + "/ExportDirectory", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneLinux64);
        File.Move(Application.dataPath + "/ExportDirectory/" + assetBundleTitle, Application.dataPath + "/ExportDirectory/" + mapExportTitle + ".linux.level");

        File.Delete(Application.dataPath + "/ExportDirectory/" + assetBundleTitle);
        File.Delete(Application.dataPath + "/ExportDirectory/" + assetBundleTitle + ".manifest");
        File.Delete(Application.dataPath + "/ExportDirectory/" + assetBundleTitle + ".meta");
        File.Delete(Application.dataPath + "/ExportDirectory/" + assetBundleTitle + ".manifest.meta");
        File.Delete(Application.dataPath + "/ExportDirectory/ExportDirectory");
        File.Delete(Application.dataPath + "/ExportDirectory/ExportDirectory" + ".meta");
        File.Delete(Application.dataPath + "/ExportDirectory/ExportDirectory" + ".manifest");
        File.Delete(Application.dataPath + "/ExportDirectory/ExportDirectory" + ".manifest.meta");

        AssetDatabase.Refresh();
    }
}
