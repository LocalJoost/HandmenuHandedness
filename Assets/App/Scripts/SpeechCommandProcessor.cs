using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.HandControl;
using MRTKExtensions.Messaging;
using UnityEngine;

namespace HandmenuHandedness
{
    public class SpeechCommandProcessor : MonoBehaviour
    {
        private IMessengerService _messenger;

        private void Start()
        {
            _messenger = MixedRealityToolkit.Instance.GetService<IMessengerService>();
        }

        public void SetLeftHanded(bool isLeftHanded)
        {
            _messenger.Broadcast(new HandControlMessage(isLeftHanded) { IsFromSpeechCommand = true });
        }
    }
}