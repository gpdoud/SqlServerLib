using System;

using SqlServerLibrary;

namespace SqlServerConsole {
    class Program {
        static void Main(string[] args) {

            SqlServerLib ssl = new SqlServerLib();
            ssl.Connect("localhost\\sqlexpress", "PrsDb31");
            ssl.Disconnect();
        }
    }
}
