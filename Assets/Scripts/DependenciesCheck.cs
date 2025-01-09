using System.Linq;
using UnityEngine;

public class DependenciesCheck : MonoBehaviour
{
    void Start()
    {
        if (System.AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "Unity.Netcode.Runtime") == null)
        {
            Debug.LogError("Netcode for GameObjects package is not installed. Please install it through the Package Manager to use this SDK.");
            enabled = false; // Disable this script
            return;
        }

        if (System.AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "Unity.Services.Lobbies") == null)
        {
            Debug.LogError("Lobbies package is not installed. Please install it through the Package Manager to use this SDK.");
            enabled = false; // Disable this script
            return;
        }

        if (System.AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "Unity.Services.Relay") == null)
        {
            Debug.LogError("Relay package is not installed. Please install it through the Package Manager to use this SDK.");
            enabled = false; // Disable this script
            return;
        }

        Debug.Log("All needed packages are present to work with ScenesSDK");
    }
}
