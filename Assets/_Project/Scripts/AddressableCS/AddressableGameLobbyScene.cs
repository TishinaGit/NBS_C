using System;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.AddressableAssets; 
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

[Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid) { }
}

[Serializable]
public class AssetReferenceAudioSource : AssetReferenceT<AudioSource>
{
    public AssetReferenceAudioSource(string guid) : base(guid) { }
}

public class AddressableGameLobbyScene : MonoBehaviour
{
    private void Awake()
    {
        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Texture", typeof(Texture2D)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Texture", typeof(Texture)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Texture", typeof(Sprite)).Completed += LoadResourceAsync;

        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Material", typeof(Material)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Material", typeof(Shader)).Completed += LoadResourceAsync;

        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Mesh", typeof(Mesh)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbyScene_Mesh", typeof(GameObject)).Completed += LoadResourceAsync;

        Addressables.LoadResourceLocationsAsync("GameLobbyScene_SO", typeof(ScriptableObject)).Completed += LoadResourceAsync;

        Addressables.LoadResourceLocationsAsync("Shader", typeof(Material)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("Shader", typeof(Shader)).Completed += LoadResourceAsync;

        Addressables.LoadResourceLocationsAsync("GameLobbySceneSprite", typeof(Texture2D)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbySceneSprite", typeof(Texture)).Completed += LoadResourceAsync;
        Addressables.LoadResourceLocationsAsync("GameLobbySceneSprite", typeof(Sprite)).Completed += LoadResourceAsync;
    }
    
    private void LoadResourceAsync(AsyncOperationHandle<IList<IResourceLocation>> obj)
    {
        foreach (var resource in obj.Result)
        {
            Debug.Log(resource.PrimaryKey);
            Debug.Log(resource.ResourceType);
        }
    }
}
