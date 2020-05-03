using Microsoft.MixedReality.Toolkit;

namespace MRTKExtensions.Utilities
{
    public static class CapabilitiesCheck
    {
        public static bool IsArticulatedHandSupported =>
            CoreServices.InputSystem is IMixedRealityCapabilityCheck capabilityChecker &&
            capabilityChecker.CheckCapability(MixedRealityCapability.ArticulatedHand);

        public static bool IsEyeTrackingSupported =>
            CoreServices.InputSystem is IMixedRealityCapabilityCheck capabilityChecker &&
            capabilityChecker.CheckCapability(MixedRealityCapability.EyeTracking);
    }
}
