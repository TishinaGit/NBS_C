using Cinemachine;
using Controller;
using Inventory;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
 
public class GameLobbySceneInstaller : MonoInstaller
{ 
    public Transform TransformCamera;
    public GameObject AimTargetForCamera;
    public GameObject PlayerPrefab;
    public AddSpriteForItem AddSpriteForItem; 
    public InventoryPanel InventoryPanel; 
    public CinemachineFreeLook CinemachineFreeLook;
    public List<GameObject> ItemsData;
    public List<InventoryCell> InventoryCells;
     
    public override void InstallBindings()
    {  
        CameraTransform();

        CameraAimTarget();

        CinemachineFreeLookForCanvas();

        Player();

        AddSpriteItem();

        InventoryPanelGameScene();

        ListInventoryCell();

        ListGameObjectsInventoryCells(); 
    }
  
    public void CameraTransform()
    { 
        Container.Bind<Transform>().FromInstance(TransformCamera).AsSingle();
    }
     
    public void Player()
    {
        PlayerController playerController = Container.InstantiatePrefabForComponent<PlayerController>(PlayerPrefab);
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle(); 
    }

    public void CameraAimTarget()
    {
        Container.Bind<GameObject>().FromInstance(AimTargetForCamera).AsSingle();
    }

    public void CinemachineFreeLookForCanvas()
    { 
        Container.Bind<CinemachineFreeLook>().FromInstance(CinemachineFreeLook).AsSingle(); 
    }
    public void AddSpriteItem()
    {
        Container.Bind<AddSpriteForItem>().FromInstance(AddSpriteForItem).AsSingle(); 
    }

    public void ListInventoryCell()
    {
        Container.Bind<List<InventoryCell>>().FromInstance(InventoryCells).AsSingle(); 
    }

    public void ListGameObjectsInventoryCells()
    {
        Container.Bind<List<GameObject>>().FromInstance(ItemsData).AsSingle();
    } 
    public void InventoryPanelGameScene()
    {
        Container.Bind<InventoryPanel>().FromInstance(InventoryPanel).AsSingle();
    } 
}
 


 