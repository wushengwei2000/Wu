using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public static class Company
    {

        // IMPORTANT: DO NOT MODIFY THIS CLASS
        public sealed class Employee
        {

            private readonly int id;
            private readonly string name;
            private List<Employee> reports;

            public Employee(int id, string name)
            {
                this.id = id;
                this.name = name;
                this.reports = new List<Employee>();
            }

            public int getId()
            {
                return id;
            }

            public string getName()
            {
                return name;
            }

            public IList<Employee> getReports()
            {
                return reports;
            }

            public void addReport(Employee employee)
            {
                reports.Add(employee);
            }
        }

        //
        // Read the attached PDF for more explanation about the problem
        //
        // Note: Don't modify the signature of this function 
        //
        public static Employee closestCommonManager(Employee ceo, Employee firstEmployee, Employee secondEmployee)
        {
            //Algorithm Design: 
            //Assumption:     Employee ID is unique 
            //Data Structure: 1 Queue to hold breadth-first search one of the first found Employee  
            //                1 Stack to hold the higher managers (not necessary direct managers) of firstEmployee
            //                1 Queue for Breadth-first Search secondEmployee 
            //
            
            if (ceo == null || firstEmployee == null || secondEmployee == null)
                return null;
            if (firstEmployee.getId() == ceo.getId() || secondEmployee.getId() == ceo.getId())
                return ceo;
            if (firstEmployee.getId() == secondEmployee.getId())
                return firstEmployee;
            
            //Step 1: Breadth-first found one of the employee && push all its higher managers into a stack (including himself)
            Queue<Employee> searchQueueFindFirst = new Queue<Employee>();
            Stack<Employee> higherManagersOfFirstFound = new Stack<Employee>();

            Employee firstLocatedEmployee = null;
            searchQueueFindFirst.Enqueue(ceo);
            while (searchQueueFindFirst.Count > 0)
            {
                var head = searchQueueFindFirst.Dequeue();
                higherManagersOfFirstFound.Push(head);

                if (head.getId() == firstEmployee.getId())
                {
                    firstLocatedEmployee = head;
                    break;
                }
                else if (head.getId() == secondEmployee.getId())
                {
                    firstLocatedEmployee = head;
                    break;
                }

                foreach (var report in head.getReports())
                {
                    searchQueueFindFirst.Enqueue(report);
                }
            }

            //Step 2: Loop First-found's higher Manager and Check if they are the manager of second employee 
            Employee commonManager = firstLocatedEmployee;
            Employee secondEmployeeToLocate = firstLocatedEmployee.getId() == firstEmployee.getId()
                ? secondEmployee
                : firstEmployee;
            while (higherManagersOfFirstFound.Count > 0)
            {
                var top = higherManagersOfFirstFound.Pop();

                if(top.getId()!=commonManager.getId() && !top.getReports().Contains(commonManager))
                    continue; //Skip Searching If not Direct Manager of Employee 1

                //Assign Stack Top to Common Manager and Prove it
                commonManager = top;

                //Breath-First Search Second Employee 
                bool secondEmployeeLocated = false;
                Queue<Employee> queue2SearchSecondEmployee = new Queue<Employee>();
                queue2SearchSecondEmployee.Enqueue(commonManager);
                while (queue2SearchSecondEmployee.Count > 0)
                {
                    Employee queueTop = queue2SearchSecondEmployee.Dequeue();
                    if (queueTop.getId() == secondEmployeeToLocate.getId())
                    {
                        secondEmployeeLocated = true;
                        break;
                    }
                    foreach (var report in queueTop.getReports())
                    {
                        queue2SearchSecondEmployee.Enqueue(report);
                    }
                }
                if (secondEmployeeLocated)
                {
                    break;
                }
            }

            return commonManager;
        }
    }
}
