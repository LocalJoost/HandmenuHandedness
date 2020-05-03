using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using MRTKExtensions.Audio;
using MRTKExtensions.Messaging;
using UnityEngine;

namespace MRTKExtensions.HandControl
{
    [RequireComponent(typeof(SolverHandler))]
    public class DominantHandHelper : MonoBehaviour
    {
        [SerializeField] 
        private bool _dominantHandControlled;
        private IMessengerService _messenger;
        private SolverHandler _solver;

        private void Start()
        {
            _messenger = MixedRealityToolkit.Instance.GetService<IMessengerService>();
            _messenger.AddListener<HandControlMessage>(ProcessHandControlMessage);
            _solver = GetComponent<SolverHandler>();
        }

        private void ProcessHandControlMessage(HandControlMessage msg)
        {
            var isChanged = SetSolverHandedness(msg.IsLeftHanded);
            // Only display sound when and actual change has occured from a speech command.
            // _dominantHandControlled check is to prevent a double sound
            if (msg.IsFromSpeechCommand && isChanged && _dominantHandControlled)
            {
                _messenger.Broadcast(new ConfirmSoundMessage());
            }
        }

        private bool SetSolverHandedness(bool isLeftHanded)
        {
            var desiredHandedness = isLeftHanded ^_dominantHandControlled ? Handedness.Left : Handedness.Right;
            var isChanged = desiredHandedness != _solver.TrackedHandness;
            _solver.TrackedHandness = desiredHandedness;
            return isChanged;
        }
    }
}
