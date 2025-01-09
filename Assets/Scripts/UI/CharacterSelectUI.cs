using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button readyButton;

    [SerializeField] private Transform lobbyPlayerTemplate;
    [SerializeField] private Transform lobbyPlayersContainer;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            GameLobbyManager.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        readyButton.onClick.AddListener(() =>
        {
            CharacterSelectReady.Instance.SetPlayerReady();
        });
    }

    private void UpdateLobbyList(List<PlayerData> playerDataList)
    {
        foreach (Transform child in lobbyPlayersContainer)
        {
            if (child == lobbyPlayersContainer) continue;
            Destroy(child.gameObject);
        }

        foreach (PlayerData lobby in playerDataList)
        {
            Transform lobbyTransform = Instantiate(lobbyPlayerTemplate, lobbyPlayersContainer);
            lobbyTransform.gameObject.SetActive(true);
            //lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }
}
