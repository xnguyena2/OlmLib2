#define TEST_ACCOUNT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OlmAPI
{
    class OlmAccount
    {
        unsafe void* account;

        public OlmAccount()
        {
            IntPtr size = OlmAPI.olm_account_size();
            Console.WriteLine("olm_account_size:" + size);
            var accArray = Marshal.AllocHGlobal(size);
            unsafe
            {
                account = OlmAPI.olm_account(accArray.ToPointer());
            }
        }

        public void create()
        {
            unsafe
            {
                IntPtr size = OlmAPI.olm_create_account_random_length(account);
                byte[] bytes =
#if TEST_ACCOUNT
                    System.IO.File.ReadAllBytes("Output.txt");
#else
                new byte[(int)size];
                Random random = new Random();
                random.NextBytes(bytes);
#endif
                fixed (byte* p = bytes)
                {
                    OlmAPI.olm_create_account(account, p, size);
                }
            }
        }

        public Newtonsoft.Json.Linq.JObject identity_keys()
        {
            unsafe
            {
                IntPtr size = OlmAPI.olm_account_identity_keys_length(account);
                byte[] bytes = new byte[(int)size];
                fixed (byte* p = bytes)
                {
                    OlmAPI.olm_account_identity_keys(account, p, size);
                    return Newtonsoft.Json.Linq.JObject.Parse(Encoding.UTF8.GetString(bytes));
                }
            }
        }

        public string sign(byte[] message)
        {
            unsafe
            {
                IntPtr out_length = OlmAPI.olm_account_signature_length(account);
                byte[] message_buffer = copyArray(message);
                byte[] out_buffer = new byte[(int)out_length];
                fixed (byte* p = message_buffer)
                {
                    fixed (byte* q = out_buffer)
                    {
                        OlmAPI.olm_account_sign(account, p, (IntPtr)message.Length, q, out_length);
                        return Encoding.UTF8.GetString(out_buffer);
                    }
                }
            }
        }

        public byte[] createCBuffer(byte[] oldBuffer)
        {
            byte[] newBuffer = new byte[oldBuffer.Length + 1];
            oldBuffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }

        public byte[] copyArray(byte[] oldBuffer)
        {
            byte[] newBuffer = new byte[oldBuffer.Length];
            oldBuffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }
    }
}
