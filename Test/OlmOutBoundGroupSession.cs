#define TEST_OUTBOUND

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace OlmAPI
{
    class OlmOutBoundGroupSession
    {
        unsafe void* session;

        public OlmOutBoundGroupSession()
        {
            IntPtr size = OlmAPI.olm_outbound_group_session_size();
            Console.WriteLine("olm_outbound_group_session_size:" + size);
            var ipArray = Marshal.AllocHGlobal(size);
            unsafe
            {
                session = OlmAPI.olm_outbound_group_session(ipArray.ToPointer());
                IntPtr rLeng = OlmAPI.olm_init_outbound_group_session_random_length(session);
                Console.WriteLine("olm_init_outbound_group_session_random_length:" + rLeng);
                byte[] bytes =
#if TEST_OUTBOUND
                    System.IO.File.ReadAllBytes("OutboundGroupSession.txt");
#else
                new byte[(int)rLeng];
                Random random = new Random();
                random.NextBytes(bytes);
#endif
                bool result = (OlmAPI.olm_error() != OlmAPI.olm_init_outbound_group_session(session, bytes, rLeng));
                if (!result)
                    session = null;
            }
        }

        public string session_id()
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr id_length = OlmAPI.olm_outbound_group_session_id_length(session);
                    byte[] id = new byte[(int)id_length];
                    OlmAPI.olm_outbound_group_session_id(session, id, id_length);
                    return Encoding.UTF8.GetString(id);
                }
            }
        }

        public string session_key()
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr key_length = OlmAPI.olm_outbound_group_session_key_length(session);
                    byte[] key = new byte[(int)key_length];
                    OlmAPI.olm_outbound_group_session_key(session, key, key_length);
                    return Encoding.UTF8.GetString(key);
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

        public string encrypt(byte[] plainText)
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr message_length = OlmAPI.olm_group_encrypt_message_length(session, (IntPtr)plainText.Length);
                    byte[] message_buffer = new byte[(int)message_length];

                    byte[] plaintext_buffer = copyArray(plainText);
                    IntPtr length_result = OlmAPI.olm_group_encrypt(session,
                        plaintext_buffer, (IntPtr)plainText.Length,
                        message_buffer, message_length);
                    Console.WriteLine(length_result);
                    return Encoding.UTF8.GetString(message_buffer);
                }
            }
        }

    }
}
