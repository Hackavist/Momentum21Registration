using System;

namespace MomentumRegistrationApi.Helpers
{
    public static class Helpers
    {
        public static string StringFromByteArray(byte[] array) => System.Text.Encoding.UTF8.GetString(array);

        public static byte[] ByteArrayFromBase64String(string s) => Convert.FromBase64String(s);
    }
}