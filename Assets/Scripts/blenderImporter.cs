using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class blenderImporter : AssetPostprocessor
{
    private void OnPreprocessAnimation()
    {
        ModelImporter importer = assetImporter as ModelImporter;
        var animations = importer.defaultClipAnimations;

        if (animations.Length == 0)
        {
            return;
        }

        foreach(var clip in animations)
        {
            clip.loopTime = true;
        }

        importer.clipAnimations = animations;
    }
}
