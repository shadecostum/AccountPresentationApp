using AcoountAppClassLibrary.Service;
using AcoountAppClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcoountAppClassLibrary.Service;
using System.IO;

namespace AccountPresentationApp
{
    public class AccountControler
    {
        //1used to call accountmanager inside this class so we can acces the function of this class NB;
        private AccountManager accountManager;//constructore injection
        private List<AccountPerson> listController;//constructor injection
        string filePath = AccountManager.sfilePath;//constructor injection


        public AccountControler()
        {
            accountManager = new AccountManager();//1.1by calling here we can call accm every in th class function
            listController = accountManager.personsList;//list from another class called here
        }

        public void Run()
        {
            while (true)
            {
                //checking file path valid not valid call this function
                if (!FileDataExists(AccountManager.sfilePath))//static string called jzt class added.stringname 
                {
                    Console.WriteLine("Welcome ! Enter Account Deatails to Create new Account");
                    Console.WriteLine("Enter the Account Name");
                    string accountName = Console.ReadLine();
                    Console.WriteLine("enter the Bank Name");
                    string bankName = Console.ReadLine();
                    Console.WriteLine("Enter the Deposite Money");
                    int balance = Convert.ToInt32(Console.ReadLine());

                    //2.1 created object and stroed in file not in list so no add function needed
                    accountManager.CreateAccount(accountName, bankName, balance);


                }
                else
                {
                    Console.WriteLine();
                    //3 read file  function called path given and file data stored in Account person variable 
                    AccountPerson readFileObj = accountManager.ReadFilePass();
                    //4.checking file exist print welcome back


                    if (readFileObj != null)
                    {
                        Console.WriteLine("Welcome Back " + readFileObj.AccountName + "\n" + readFileObj.BankName +
                            "\n" + readFileObj.Balance);


                        //4.1 List added the read file data calling this function
                        accountManager.ListCreated(readFileObj);

                        while (true)
                        {

                            int chooseNumber = Display();

                            switch (chooseNumber)
                            {
                                case 1:
                                    //5 check data exist  AccountPerson  to fetch and change deposite amount
                                    Console.WriteLine("Enter the amount to Deposite");
                                    int depositeAmount = Convert.ToInt32(Console.ReadLine());
                                    accountManager.DepositAmount(depositeAmount);
                                    Console.WriteLine("Add succes :" + depositeAmount + " to Your account");
                                    accountManager.SavingFile();
                                    // accountManager.DepositAmount( readFileObj, out amount);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the amount to Widraw");
                                    int widrowAmount = Convert.ToInt16(Console.ReadLine());
                                    string feedBack;
                                    try
                                    {

                                        accountManager.WidrowAmount(widrowAmount, out feedBack);
                                        Console.WriteLine(feedBack);
                                        accountManager.SavingFile();
                                    }
                                    catch (Exception be)
                                    {
                                        Console.WriteLine(be.Message);
                                    }



                                    break;
                                case 3:
                                    foreach (var item in listController)
                                    {
                                        Console.WriteLine(item.AccountName + "\n" + item.BankName + "\n" + item.Balance);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("saving your Transaction");
                                    accountManager.SavingFile();
                                    return;

                                default:
                                    Console.WriteLine("invalid entry");
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static bool FileDataExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public int Display()
        {
            Console.WriteLine("What do you wish to Do..........");
            Console.WriteLine("1.Deposite\n2.Withdraw\n3.DisplayBalance\n4.Exit");
            int choosNumber = Convert.ToInt16(Console.ReadLine());
            return choosNumber;
        }
    }
}
