using System;
using Microsoft.MixedReality.Toolkit;

namespace MRTKExtensions.Messaging
{
    public interface IMessengerService : IMixedRealityExtensionService
    {
        void MarkAsPermanent(Type eventType);
        void Cleanup();
        void PrintEventTable();
        void AddListener<T>(MessengerCallback<T> handler);
        void RemoveListener<T>(MessengerCallback<T> handler);
        void Broadcast<T>(T eventType);
    }
}