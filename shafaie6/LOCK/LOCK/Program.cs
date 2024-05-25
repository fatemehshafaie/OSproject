﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOCK
{
    class Program
    {
        static readonly object locker = new object(); 

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(WithdrawMoney);
                thread.Start(i + 1);
            }
            Console.ReadKey();
        }

        static void WithdrawMoney(object accountId)
        {
            lock (locker) 
            {
                Console.WriteLine($"Account {accountId} is withdrawing money...");
                Thread.Sleep(2000); 
                Console.WriteLine($"Account {accountId} has withdrawn money.");
            } 
        }
    }
}
