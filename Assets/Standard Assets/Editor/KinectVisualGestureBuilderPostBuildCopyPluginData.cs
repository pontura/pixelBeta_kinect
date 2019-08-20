using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.Collections.Generic;
using System.IO;


public static class KinectVisualGestureBuilderPostBuildCopyPluginData
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        KinectCopyPluginDataHelper.CopyPluginData (target, path, "vgbtechs");
    }
}
