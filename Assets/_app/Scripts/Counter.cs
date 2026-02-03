using Unity.Netcode;
using UnityEngine;

namespace MCounter
{
    public class Counter : NetworkBehaviour
    {
        public NetworkVariable<int> CountNumber = new NetworkVariable<int>(
            0, 
            readPerm: NetworkVariableReadPermission.Everyone, 
            writePerm: NetworkVariableWritePermission.Server);

        private void Start()
        {
            UIManipulation.Singleton.ButtonCountListener(() => {
                IncreaseCounterNumberServerRpc();
                });
            UIManipulation.Singleton.ButtonResetListener(() =>{
                ResetCountServerRpc();
            });
        }

        public override void OnNetworkSpawn()
        {
            CountNumber.OnValueChanged += UpdateUI;
        }

        public override void OnNetworkDespawn()
        {
            CountNumber.OnValueChanged -= UpdateUI;
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
        private void IncreaseCounterNumberServerRpc()
        {
            CountNumber.Value++;
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
        private void ResetCountServerRpc()
        {
            CountNumber.Value = 0;
        }

        private void UpdateUI(int new_health, int old_health)
        {
            UIManipulation.Singleton.SetNumber(CountNumber.Value);
        }
    }
}