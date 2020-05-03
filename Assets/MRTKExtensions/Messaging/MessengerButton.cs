using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace MRTKExtensions.Messaging
{
    public class MessengerButton<T> : MonoBehaviour where T:class, new()
    {
        private IMessengerService service = null;
        public void Click()
        {
            service = service ?? MixedRealityToolkit.Instance.GetService<IMessengerService>();
            service.Broadcast(new T());
        }
    }
}
