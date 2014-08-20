using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class Amazon
    {
        //Questions 1: Print Customers and Their Refered Customers  
        public static void PrintCustomerTree(Customer c)
        {
            //Looping Implementations 
            Stack<Customer> holder = new Stack<Customer>();
            c.Level = 0;
            holder.Push(c);

            while (holder.Count>0)
            {
                var current = holder.Pop();
                current.Print();

                if (current.ReferedCustomers!=null && current.ReferedCustomers.Any(customer=>!customer.Printed))
                {
                    holder.Push(current);
                    for (int i = current.ReferedCustomers.Count - 1; i >= 0; i--)
                    {
                        current.ReferedCustomers[i].Level = current.Level + 1;
                        holder.Push(current.ReferedCustomers[i]);
                    }
                }
            }
        }

        public static void PrintCusomterRecursive(Customer c)
        {
            var prefix = c.Level == 0
                ? ""
                : Enumerable.Repeat("\t", c.Level).Aggregate((s1, s2) => s2 == null ? s1 : s1 + s2);

            Console.WriteLine(prefix+ c.Name);
            if (c.ReferedCustomers != null && c.ReferedCustomers.Count > 0)
            {
                foreach (var cus in c.ReferedCustomers)
                {
                    cus.Level = c.Level+1;
                    PrintCusomterRecursive(cus);
                }
            }
        }

        public static void PrintCusomterTree(Customer c)
        {
            
        }
    }


    public class Customer
    {
        public string Name { get; set; }
        public double Purchases { get; set; }
        public IList<Customer> ReferedCustomers { get; set; }

        //Questions 2: Calculate Customer Rewards based on the hierarchy 
        public double GetRewards(ICustomerReward rewardScheme)
        {
            return rewardScheme.CalculateReward(this);
        }

        public bool Printed { get; set; }           //For Printing Purpose
        public int Level { get; set; }
        public void Print()
        {
            if (!Printed)
            {
                Console.WriteLine(string.Format("{0}{1}",
                    Level==0? "": Enumerable.Repeat("\t", Level).Aggregate((s1,s2)=> s2==null? s1: s1+s2),
                    Name)); // Level Number of "\t" + Name
                Printed = true;
            }
        }

        private int _totalChildNodeCount = 0;
        public int TotalChildNodeCount
        {
            get
            {
                if (_totalChildNodeCount == 0 && ReferedCustomers!=null && ReferedCustomers.Count>0)
                    _totalChildNodeCount = ReferedCustomers.Count + ReferedCustomers.Sum(c => c.TotalChildNodeCount);   
                return _totalChildNodeCount;
            }
        }

    }

    //Reward Strategy Pattern 
    public interface ICustomerReward
    {
        double CalculateReward(Customer customer);
    }

    public class ReferingReward : ICustomerReward
    {
        private const double SelfPurchaseReward = 0.3;
        private const double RefererPurchaseReward = 0.1;

        public double CalculateReward(Customer customer)
        {
            return customer.Purchases * SelfPurchaseReward + 
                (customer.ReferedCustomers==null? 0.0: customer.ReferedCustomers.Sum(c => c.GetRewards(this)) * RefererPurchaseReward);
        }
    }

}
