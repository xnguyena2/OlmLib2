using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ExampleClient
{
    class OlmAPI
    {
        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr olm_outbound_group_session_size();

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe void* olm_outbound_group_session(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_init_outbound_group_session_random_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_init_outbound_group_session(void* sessionP, byte[] random, IntPtr random_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr olm_error();

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe char[] olm_outbound_group_session_last_error(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_outbound_group_session_id_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_outbound_group_session_id(void* sessionP, byte[] id, IntPtr id_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe uint olm_outbound_group_session_message_index(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_outbound_group_session_key_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_outbound_group_session_key(void* sessionP, byte[] key, IntPtr key_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_group_encrypt_message_length(void* sessionP, IntPtr plaintext_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_group_encrypt(void* sessionP, byte[] plaintext, IntPtr plaintext_length, byte[] message, IntPtr message_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_unpickle_outbound_group_session(void* sessionP, void* key, IntPtr key_length, void* pickled, IntPtr pickled_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_pickle_outbound_group_session_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe IntPtr olm_pickle_outbound_group_session(void* sessionP, void* key, IntPtr key_length, void* pickled, IntPtr pickled_length);

        static unsafe void* session;

        public static bool init()
        {
            IntPtr size = olm_outbound_group_session_size();
            Console.WriteLine("olm_outbound_group_session_size:" + size);
            var ipArray = Marshal.AllocHGlobal(size);
            unsafe
            {
                session = olm_outbound_group_session(ipArray.ToPointer());
                IntPtr rLeng = olm_init_outbound_group_session_random_length(session);
                Console.WriteLine("olm_init_outbound_group_session_random_length:" + rLeng);
                Random random = new Random();
                byte[] bytes = new byte[(int)rLeng];
                random.NextBytes(bytes);
                //byte[] ex = createCBuffer(bytes);
                bool result = (olm_error() != olm_init_outbound_group_session(session, bytes, rLeng));
                if (!result)
                    session = null;
                return result;
            }
        }

        public static string session_id()
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr id_length = olm_outbound_group_session_id_length(session);
                    byte[] id = new byte[(int)id_length];
                    olm_outbound_group_session_id(session, id, id_length);
                    return Encoding.UTF8.GetString(id);
                }
            }
        }

        public static string session_key()
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr key_length = olm_outbound_group_session_key_length(session);
                    byte[] key = new byte[(int)key_length];
                    olm_outbound_group_session_key(session, key, key_length);
                    return Encoding.UTF8.GetString(key);
                }
            }
        }

        public static byte[] createCBuffer(byte[] oldBuffer)
        {
            byte[] newBuffer = new byte[oldBuffer.Length + 1];
            oldBuffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }

        public static byte[] copyArray(byte[] oldBuffer)
        {
            byte[] newBuffer = new byte[oldBuffer.Length];
            oldBuffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }

        public static string encrypt(byte[] plainText)
        {
            unsafe
            {
                if (session == null)
                    return null;
                else
                {
                    IntPtr message_length = olm_group_encrypt_message_length(session, (IntPtr)plainText.Length);
                    byte[] message_buffer = new byte[(int)message_length];

                    byte[] plaintext_buffer = copyArray(plainText);
                    IntPtr length_result = olm_group_encrypt(session,
                        plaintext_buffer, (IntPtr)plainText.Length,
                        message_buffer, message_length);
                    Console.WriteLine(length_result);
                    return Encoding.UTF8.GetString(message_buffer);
                }
            }
        }

    }
}
