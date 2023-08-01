
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LocalHideUIWhitelist : UdonSharpBehaviour
{
    private VRCPlayerApi _player = Networking.LocalPlayer;
    public string[] _adminUsers;

    public Canvas[] canvases;
    public MeshRenderer[] controllerMeshes;
    public Collider[] colliders;

    void Start()
    {
        _player = Networking.LocalPlayer;
    }

    private bool CheckAllowListStatus()
    {
        bool allowlist = false;
        foreach (string _adminPlayers in _adminUsers)
        {
            if (Networking.LocalPlayer.displayName == _adminPlayers)
                allowlist = true;
        }

        return allowlist;
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        bool allow = CheckAllowListStatus();

        if (canvases.Length > 0)
        {
            foreach (Canvas canvas in canvases)
                canvas.enabled = allow;
        }
        
        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
                collider.enabled = allow;
        }

        if (controllerMeshes.Length > 0)
        {
            foreach (MeshRenderer mesh in controllerMeshes)
                mesh.enabled = allow;
        }
    }

    public override void OnPlayerRespawn(VRCPlayerApi player)
    {
        bool allow = CheckAllowListStatus();

        if (canvases.Length > 0)
        {
            foreach (Canvas canvas in canvases)
                canvas.enabled = allow;
        }

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
                collider.enabled = allow;
        }

        if (controllerMeshes.Length > 0)
        {
            foreach (MeshRenderer mesh in controllerMeshes)
                mesh.enabled = allow;
        }
    }
}
