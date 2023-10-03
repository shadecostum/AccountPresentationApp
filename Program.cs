using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcoountAppClassLibrary.Service;
using AccountPresentationApp;

namespace AccountPresentationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountControler manager = new AccountControler();
            manager.Run();
        }
    }
}
