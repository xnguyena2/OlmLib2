using Newtonsoft.Json.Linq;
using OlmAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            OlmAccount ac = new OlmAccount();
            ac.create();
            JObject keys = ac.identity_keys();
            JObject sign_json = new JObject();
            string[] al = { "m.olm.v1.curve25519-aes-sha2", "m.megolm.v1.aes-sha2" };
            JArray algorithms = new JArray(al);
            sign_json.Add("algorithms", algorithms);
            sign_json.Add("device_id", "WCIJUNLGHF");
            sign_json.Add("device_keys", keys);
            sign_json.Add("user_id", "@test1:ec2-54-164-232-153.compute-1.amazonaws.com");
            Console.WriteLine(sign_json.ToString(Newtonsoft.Json.Formatting.None).Length);
            Console.WriteLine(ac.sign(Encoding.UTF8.GetBytes(sign_json.ToString(Newtonsoft.Json.Formatting.None))));


            OlmOutBoundGroupSession outbound = new OlmOutBoundGroupSession();
            Console.WriteLine(outbound.encrypt(Encoding.UTF8.GetBytes("hello")));
            Console.ReadLine();
        }
    }
}
