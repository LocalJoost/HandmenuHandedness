
using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.Messaging;
using System.Collections.Generic;
using UnityEngine;

namespace MRTKExtensions.Audio
{
    public class SpokenFeedbackManager : MonoBehaviour
    {
        private Queue<string> _messages = new Queue<string>();
        private IMessengerService _messenger;
        private void Start()
        {
            _messenger = _messenger = MixedRealityToolkit.Instance.GetService<IMessengerService>();
            _messenger.AddListener<SpokenFeedbackMessage>(AddTextToQueue);
         //   _ttsManager = GetComponent<TextToSpeech>(); TODO
        }

        private void AddTextToQueue(SpokenFeedbackMessage msg)
        {
            _messages.Enqueue(msg.Message);
        }

     //   private TextToSpeech _ttsManager; TODO

        private void Update()
        {
            SpeakText();
        }

        private void SpeakText()
        {
            // TODO
            //if (_ttsManager != null && _messages.Count > 0)
            //{
            //    if(! (_ttsManager.SpeechTextInQueue() || _ttsManager.IsSpeaking()))
            //    {
            //        _ttsManager.StartSpeaking(_messages.Dequeue());
            //    }
            //}
        }
    }
}

