using System;
namespace MRTKExtensions.HandControl
{
    public class HandControlMessage 
    {
        public HandControlMessage(bool isLeftHanded)
        {
            IsLeftHanded = isLeftHanded;
        }
        public bool IsLeftHanded { get; }

        public bool IsFromSpeechCommand { get; set; }
    }
}
