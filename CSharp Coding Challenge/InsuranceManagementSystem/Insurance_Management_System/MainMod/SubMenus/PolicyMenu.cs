using Insurance_Management_System.DAO;
using Insurance_Management_System.Exceptions;
using Insurance_Management_System.Model;

namespace Insurance_Management_System.MainMod.SubMenus
{
    internal class PolicyMenu
    {
        readonly IPolicyService _policyService = new InsuranceServiceImpl();
        readonly PrettyConsole _prettyConsole = new();
        public PolicyMenu()
        {
            Console.Title = "Policy";
        }

        public void Menu()
        {
            int choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n------------------------------ Policy ------------------------\n");
                    Console.WriteLine("1. Add Policy");
                    Console.WriteLine("2. Display All Policies");
                    Console.WriteLine("3. Display Policy by ID");
                    Console.WriteLine("4. Update Policy");
                    Console.WriteLine("5. Delete Policy");
                    Console.WriteLine("6. Claim Policy");
                    Console.WriteLine("7. Exit");
                    Console.Write("> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddPolicyMenu();
                            break;
                        case 2:
                            DisplayPolicies();
                            break;
                        case 3:
                            UpdatePolicyMenu();
                            break;
                        case 4:
                            DeletePolicyMenu();
                            break;
                        case 7:
                            Console.WriteLine("Exiting Policy menu");
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid Option! Try again");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 5);
        }

        private void DisplayPolicies()
        {
            List<Policy> policies = _policyService.GetAllPolicies();
            foreach (Policy policy in policies)
            {
                Console.WriteLine(policy.ToString());
            }

        }
        private void AddPolicyMenu()
        {
            try
            {
                Console.WriteLine();
                Policy policy = new();
                Console.WriteLine("\nAdd Policy Number\n");
                Console.Write("> ");
                policy.PolicyNumber = Console.ReadLine();
                Console.WriteLine("\nAdd Policy Type\n");
                Console.Write("> ");
                policy.PolicyType = Console.ReadLine();
                Console.WriteLine("\nAdd Amount Covered\n");
                Console.Write("> ");
                policy.AmountCovered = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nAdd Start Date\n");
                Console.Write("> ");
                policy.StartDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("\nAdd End Date\n");
                Console.Write("> ");
                policy.EndDate = Convert.ToDateTime(Console.ReadLine());
                AddPolicy(policy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddPolicy(Policy policy)
        {
            bool addPolicyStatus = _policyService.CreatePolicy(policy);
            if (!addPolicyStatus)
            {
                _prettyConsole.Print("Error Adding Policy\n", false);
            }
            _prettyConsole.Print("Added Policy Successfully\n", true);
        }

        private void UpdatePolicyMenu()
        {
            DisplayPolicies();
            int choice;
            string fieldToUpdate = string.Empty;
            object? newValue = null;
            Console.WriteLine("Enter the PolicyID of the Policy");
            Console.Write("> ");
            int policyID = Convert.ToInt32(Console.ReadLine());
            bool isPresent = _policyService.IsPolicyPresent(policyID);
            try
            {
                if (isPresent)
                {
                    do
                    {
                        Console.WriteLine("Select the field to update");
                        Console.WriteLine("1. Policy Number");
                        Console.WriteLine("2. Policy Type");
                        Console.WriteLine("3. Amount covered");
                        Console.WriteLine("4. Start Date");
                        Console.WriteLine("5. End Date");
                        Console.WriteLine("6. Claim Policy");
                        Console.WriteLine("7. Exit");
                        Console.Write("> ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                fieldToUpdate = "PolicyNumber";
                                Console.WriteLine("Enter new value of Policy Number");
                                Console.Write("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 2:
                                fieldToUpdate = "PolicyType";
                                Console.WriteLine("Enter new value of Policy type");
                                Console.Write("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 3:
                                fieldToUpdate = "AmountCovered";
                                Console.WriteLine("Enter new value of Amount covered");
                                Console.Write("> ");
                                newValue = Convert.ToDouble(Console.ReadLine());
                                break;
                            case 4:
                                fieldToUpdate = "StartDate";
                                Console.WriteLine("Enter new value of Start Date");
                                Console.Write("> ");
                                newValue = Convert.ToDateTime(Console.ReadLine());
                                break;
                            case 5:
                                fieldToUpdate = "EndDate";
                                Console.WriteLine("Enter new value of EndDate");
                                Console.Write("> ");
                                newValue = Convert.ToDateTime(Console.ReadLine());
                                break;
                            case 6:
                                Console.WriteLine("Exiting Update Policy Menu");
                                break;
                        }
                        UpdatePolicy(fieldToUpdate, newValue, policyID);
                    } while (choice != 5);
                }
                else
                {
                    throw new PolicyNotFoundException($"The policyId {policyID} could not be found.\n", policyID);
                }
            }
            catch (PolicyNotFoundException pnfe)
            {
                Console.WriteLine(pnfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdatePolicy(string fieldName, object? newValue, int vehicleID)
        {
            bool updateStatus = _policyService.UpdatePolicy(fieldName, newValue, vehicleID);
            if (updateStatus)
            {
                _prettyConsole.Print($"Successfully updated {fieldName}\n", true);
            }
            else
            {
                _prettyConsole.Print($"Error updating {fieldName}\n", false);
            }
        }
        private void DeletePolicyMenu()
        {
            DisplayPolicies();
            Console.WriteLine("\nEnter the Vehicle Id:\n");
            Console.Write("> ");
            int policyID = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool isPresent = _policyService.IsPolicyPresent(policyID);
                if (isPresent)
                {
                    DeletePolicy(policyID);
                }
                else
                {
                    throw new PolicyNotFoundException($"The policyID {policyID} could not be found.\n", policyID);
                }
            }
            catch (PolicyNotFoundException pnfe)
            {
                Console.WriteLine(pnfe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeletePolicy(int policyID)
        {
            bool deletePolicyStatus = _policyService.DeletePolicy(policyID);
            if (!deletePolicyStatus)
            {
                _prettyConsole.Print("Error Deleting Policy\n", false);
            }
            _prettyConsole.Print("Deleted Policy Successfully\n", true);
        }
    }
}
