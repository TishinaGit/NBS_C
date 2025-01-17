using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid)
    {

    }
}
public class AddressableAudio : MonoBehaviour
{
    private GameObject _object;
    [SerializeField] private AssetReferenceAudioClip _clips;

    private void Awake()
    {
        InstantiateGameobjectAssetReferenceClip(_clips); 
    }
    public void InstantiateGameobjectAssetReferenceClip(AssetReferenceAudioClip key)
    {
        Addressables.InstantiateAsync(key).Completed += OnLoadDone;
    }
    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        _object = obj.Result;
    }
    public void ReleseGameobject()
    {
        Addressables.Release(_object);
    }
}
