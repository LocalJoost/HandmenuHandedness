
using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.Messaging;
using UnityEngine;

namespace MRTKExtensions.Audio
{
	public class ConfirmSoundRinger : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{
            var service = MixedRealityToolkit.Instance.GetService<IMessengerService>();
            service.AddListener<ConfirmSoundMessage>(ProcessMessage);
		}

		private void ProcessMessage(ConfirmSoundMessage arg1)
		{
			PlayConfirmationSound();
		}

		private AudioSource _audioSource;
		private void PlayConfirmationSound()
		{
			if (_audioSource == null)
			{
				_audioSource = GetComponent<AudioSource>();
			}
			if (_audioSource != null)
			{
				_audioSource.Play();
			}
		}
	}
}
