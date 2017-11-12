namespace Assets.Scripts
{
    public static class OpaqueDetector
    {
        public static bool IsOpaque
        {
            get
            {
#if !UNITY_EDITOR && UNITY_UWP
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(
                "Windows.Graphics.Holographic.HolographicDisplay"))
            {
               return Windows.Graphics.Holographic.HolographicDisplay.GetDefault()?.IsOpaque == true;
            }
#endif
                return false;
            }
        }
    }
}
