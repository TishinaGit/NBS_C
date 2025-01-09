using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadRemoteAddressables : MonoBehaviour
{
    private GameObject _MyGameObject;

    public void InstantiateGameObjectUsingAssetReference(string key)
    {
        Addressables.InstantiateAsync(key).Completed += OnLoadDone;
    }    

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        _MyGameObject = obj.Result;
    }

    public void ReleseGameobjectUsingReference()
    {
        Addressables.Release(_MyGameObject);
    }
}
