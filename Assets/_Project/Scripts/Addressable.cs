using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Addressable : MonoBehaviour
{
    private GameObject _object;

    [SerializeField] private AssetReference _job1;
    [SerializeField] private AssetReference _job2;

    private void Awake()
    {
        InstantiateGameobjectAssetReference(_job1);
        InstantiateGameobjectAssetReference(_job2);
    }

    public void InstantiateGameobjectAssetReference(AssetReference  key)
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
