using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    public static NetworkManagerUI Instance;

    private Button hostButton;
    private Button clientButton;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        hostButton = root.Q<Button>("HostButton");
        clientButton = root.Q<Button>("ClientButton");

        // ホストボタンのクリックイベント登録
        if (hostButton != null)
        {
            hostButton.clicked += OnHostButtonClicked;
        }

        // クライアントボタンのクリックイベント登録
        if (clientButton != null)
        {
            clientButton.clicked += OnClientButtonClicked;
        }
    }

    // ホストボタンがクリックされたら
    private void OnHostButtonClicked()
    {
        NetworkManager.Singleton.StartHost();
    }

    // クライアントボタンがクリックされたら
    private void OnClientButtonClicked()
    {
        NetworkManager.Singleton.StartClient();
    }
}
