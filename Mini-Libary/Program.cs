using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace Mini_Libary
{
    public class Programm
    {
        public static Libary libary = new Libary();
        
        public static void Main(string[] args)
        {
            Build.BuildLibary(libary);
            Interface.InterfaceMethod();
        }
    }
}

//Сделать Unit-Тесты на проверку