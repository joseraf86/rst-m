using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace rst
{
    class Usuario
    {
        private string login;
        private string password;
        private string did;
        private string server;
        private static Usuario instance;

        /* Platform Invoke Data: parametros especificos del terminal*/
        [DllImport("coredll.dll")]
        private static extern bool KernelIoControl(
            Int32 IoControlCode,
            IntPtr InputBuffer, 
            Int32 InputBufferSize, 
            byte[] OutputBuffer, 
            Int32 OutputBufferSize, 
            ref Int32 BytesReturned);
        private static Int32 FILE_DEVICE_HAL = 0x00000101;
        private static Int32 FILE_ANY_ACCESS = 0x0;
        private static Int32 METHOD_BUFFERED = 0x0;
        private static Int32 IOCTL_HAL_GET_DEVICEID = ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14) | ((21) << 2) | (METHOD_BUFFERED);

        private Usuario() {
            
        }

        public static Usuario GetInstance() {
            if (instance == null)
                instance = new Usuario();
            return instance;
        }

        public void SetLogin(string login) {
            this.login = login;
        }

        public void SetServer(string server)
        {
            this.server = server;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetLogin() {
            return login;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetDID()
        {
            if (did != null) return this.did;
            
            HTTP.Cifrado cifrado;
            byte[] outputBuffer = new byte[256];
            Int32 outputBufferSize, bytesReturned;
            outputBufferSize = outputBuffer.Length;
            bytesReturned = 0;
            
            // Call KernelIoControl passing the previously defined
            // IOCTL_HAL_GET_DEVICEID parameter
            // We don’t need to pass any input buffers to this call
            // so InputBuffer and InputBufferSize are set to their null
            // values
            bool retVal = KernelIoControl(IOCTL_HAL_GET_DEVICEID,
                    IntPtr.Zero,
                    0,
                    outputBuffer,
                    outputBufferSize,
                    ref bytesReturned);

            // If the request failed, exit the method now
            if (retVal == false)
            {
                return null;
            }

            // Examine the OutputBuffer byte array to find the start of the 
            // Preset ID and Platform ID, as well as the size of the
            // PlatformID. 
            // PresetIDOffset – The number of bytes the preset ID is offset
            //                  from the beginning of the structure
            // PlatformIDOffset - The number of bytes the platform ID is
            //                    offset from the beginning of the structure
            // PlatformIDSize - The number of bytes used to store the
            //                  platform ID
            // Use BitConverter.ToInt32() to convert from byte[] to int
            Int32 presetIDOffset = BitConverter.ToInt32(outputBuffer, 4);
            Int32 platformIDOffset = BitConverter.ToInt32(outputBuffer, 0xc);
            Int32 platformIDSize = BitConverter.ToInt32(outputBuffer, 0x10);

            // Convert the Preset ID segments into a string so they can be 
            // displayed easily.
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0:X8}-{1:X4}-{2:X4}-{3:X4}-",
                 BitConverter.ToInt32(outputBuffer, presetIDOffset),
                 BitConverter.ToInt16(outputBuffer, presetIDOffset + 4),
                 BitConverter.ToInt16(outputBuffer, presetIDOffset + 6),
                 BitConverter.ToInt16(outputBuffer, presetIDOffset + 8)));

            // Break the Platform ID down into 2-digit hexadecimal numbers
            // and append them to the Preset ID. This will result in a 
            // string-formatted Device ID
            for (int i = platformIDOffset;
                 i < platformIDOffset + platformIDSize;
                 i++)
            {
                sb.Append(String.Format("{0:X2}", outputBuffer[i]));
            }
            //3FBF5000-7351-0801-3633-433238384542
            
            cifrado = new HTTP.Cifrado();
            this.did = cifrado.MD5(sb.ToString());

            // return the Device ID string
            return did;
        }

        public string GetServer()
        {
            return server;
        }
    }
}
