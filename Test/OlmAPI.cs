using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OlmAPI
{
    public class OlmAPI
    {
        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr olm_outbound_group_session_size();

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* olm_outbound_group_session(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_init_outbound_group_session_random_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_init_outbound_group_session(void* sessionP, byte[] random, IntPtr random_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr olm_error();

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe char[] olm_outbound_group_session_last_error(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_outbound_group_session_id_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_outbound_group_session_id(void* sessionP, byte[] id, IntPtr id_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint olm_outbound_group_session_message_index(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_outbound_group_session_key_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_outbound_group_session_key(void* sessionP, byte[] key, IntPtr key_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_group_encrypt_message_length(void* sessionP, IntPtr plaintext_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_group_encrypt(void* sessionP, byte[] plaintext, IntPtr plaintext_length, byte[] message, IntPtr message_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_unpickle_outbound_group_session(void* sessionP, void* key, IntPtr key_length, void* pickled, IntPtr pickled_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_pickle_outbound_group_session_length(void* sessionP);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_pickle_outbound_group_session(void* sessionP, void* key, IntPtr key_length, void* pickled, IntPtr pickled_length);

        //__declspec(dllexport) 
        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_size();

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* olm_account(void* memory);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_create_account_random_length(void* account);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_create_account(void* account, void* random, IntPtr random_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_identity_keys_length(void* account);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_identity_keys(void* account, void* identity_keys, IntPtr identity_key_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_signature_length(void* account);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_sign(void* account, void* message, IntPtr message_length, void* signature, IntPtr signature_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_generate_one_time_keys_random_length(void* account, IntPtr number_of_keys);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_generate_one_time_keys(void* account, IntPtr number_of_keys, void* random, IntPtr random_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_one_time_keys_length(void* account);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_account_one_time_keys(void* account, void* one_time_keys, IntPtr one_time_keys_length);


        //__declspec(dllexport) 
        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* olm_session(void* memory);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_create_outbound_session_random_length(void* session);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_create_outbound_session(void* session, void* account, void* their_identity_key, IntPtr their_identity_key_length, void* their_one_time_key, IntPtr their_one_time_key_length, void* random, IntPtr random_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_create_inbound_session(void* session, void* account, void* one_time_key_message, IntPtr message_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_encrypt_random_length(void* session);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_encrypt_message_type(void* session);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_encrypt_message_length(void* session, IntPtr plaintext_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_encrypt(void* session, void* plaintext, IntPtr plaintext_length, void* random, IntPtr random_length, void* message, IntPtr message_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_decrypt_max_plaintext_length(void* session, IntPtr message_type, void* message, IntPtr message_length);

        [DllImport("Olmlib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr olm_decrypt(void* session, IntPtr message_type, void* message, IntPtr message_length, void* plaintext, IntPtr max_plaintext_length);

    }
}
