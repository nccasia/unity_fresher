using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BundledWebLoader : MonoBehaviour
{
    public string assetName = "BundledSpriteObject";
    public string bundleUrl = "http://localhost/assetbundles/testbundle";
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if(remoteAssetBundle == null) {
                Debug.LogError("Failed to download~");
                yield break;
            } 
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }

    }
}
