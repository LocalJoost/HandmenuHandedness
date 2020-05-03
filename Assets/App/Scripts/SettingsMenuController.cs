using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using MRTKExtensions.HandControl;
using MRTKExtensions.Messaging;
using MRTKExtensions.Utilities;
using UnityEngine;

namespace HandmenuHandedness
{
    public class SettingsMenuController : MonoBehaviour
    {
        private IMessengerService _messenger;

        [SerializeField]
        private Interactable _leftHandedButton;

        public void Start()
        {
            _messenger = MixedRealityToolkit.Instance.GetService<IMessengerService>();
            gameObject.SetActive(CapabilitiesCheck.IsArticulatedHandSupported);
            _messenger.AddListener<HandControlMessage>(ProcessHandControlMessage);
        }

        private void ProcessHandControlMessage(HandControlMessage msg)
        {
            if (msg.IsFromSpeechCommand)
            {
                _leftHandedButton.IsToggled = msg.IsLeftHanded;
            }
        }

        public void SetMainDominantHandControl()
        {
            SetMainDominantHandDelayed();
        }

        private async Task SetMainDominantHandDelayed()
        {
            await Task.Delay(100);
            _messenger.Broadcast(new HandControlMessage(_leftHandedButton.IsToggled));
        }
    }
}