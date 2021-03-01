using System;

namespace MomentumRegistrationApi.Helpers
{
    public static class Helpers
    {
        public static string StringFromByteArray(byte[] array) => Convert.ToBase64String(array,Base64FormattingOptions.InsertLineBreaks);

        public static byte[] ByteArrayFromBase64String(string s) => Convert.FromBase64String(s);
    }
}