using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BundledObjectLoader : MonoBehaviour
{
    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";
    void Start()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if(localAssetBundle == null) {
            Debug.Log("Failed to load~");
            return;
        }
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }
}
