
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class ControllerPositionReset : UdonSharpBehaviour
{
    private VRCPlayerApi _player = Networking.LocalPlayer;
    public string[] _adminUsers;

    public VRCObjectSync controller;
    public VRC_Pickup pickup;
    private Rigidbody pickupRigid;
    public Vector3 startPos;
    public Quaternion startRot;

    void Start()
    {
        _player = Networking.LocalPlayer;
        //startPos = new Vector3(-10.934f, 59.43f, -1.612f);
        //startRot = new Quaternion(0f, 90f, 0f, 0f);
        pickupRigid = pickup.GetComponent<Rigidbody>();
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

    public override void Interact()
    {
        bool allow = CheckAllowListStatus();
        if (allow)
        {
            if (pickup.currentPlayer != null)
            {
                pickup.Drop();
            }

            pickupRigid.position = startPos;
            pickupRigid.rotation = startRot;
            Networking.SetOwner(Networking.LocalPlayer, controller.gameObject);
            controller.Respawn();
        }
    }
}
