using System;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;




namespace ADSearch
{
    class ADSearch
    {
        public static void getUser(String userID, PrincipalContext domain, String filter)
        {
            try
            {
                if (filter != null)
                {
                    // Search for User
                    UserPrincipal user = UserPrincipal.FindByIdentity(domain, userID);
                    if (user != null)
                    {
                        var groups = user.GetGroups();
                        foreach (Principal group in groups)
                        {
                            if (group.Name == filter ^ group.Name.Contains(filter))
                            Console.WriteLine("{1, -5}\n",group.Name);
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("User is does not have any groups!");
                    }

                }
                else
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(domain, userID);
                    if (user != null)
                    {
                        var groups = user.GetGroups();
                        foreach (Principal group in groups)
                        {
                            Console.WriteLine("{1, -5}\n", group.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("User is does not have any groups!");
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void getRef(String refID, PrincipalContext domain, String filter)
        {
            try
            {
                if (filter != null)
                {
                    // Search for reference
                    UserPrincipal reference = UserPrincipal.FindByIdentity(domain, refID);
                    
                    if (reference != null)
                    {
                        var groups = reference.GetGroups();
                        foreach (Principal group in groups)
                        {
                            if (group.Name == filter ^ group.Name.Contains(filter))
                                Console.WriteLine("{1, -5}\n", group.Name);
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("User is does not have any groups!");
                    }
                }
                else
                {
                    UserPrincipal reference = UserPrincipal.FindByIdentity(domain, refID);
                    if (reference != null)
                    {
                        var groups = reference.GetGroups();
                        foreach (Principal group in groups)
                        {
                            Console.WriteLine("{1, -5}\n", group.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("User is does not have any groups!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured: " + ex);
            }
        }
        public static void Main(string[] args)
        {
            // Get userID and check if we want to reference against something
            PrincipalContext AD = new PrincipalContext(ContextType.Domain, "<Domain Name Here>");
            Console.Write("Enter User ID: ");
            String userID = Console.ReadLine();

            Console.WriteLine("\nEnter Reference ID: ");
            String refID = Console.ReadLine();

            Console.WriteLine("\nEnter Group Filter: ");
            String filter_name = Console.ReadLine();

            if (filter_name != null)
            {
                Console.WriteLine("\n{0, -20} {1, 5}\n", "Username", "GroupName");
                getUser(userID, AD, filter_name);
                Console.WriteLine("------------------------------------------------------\n");
                getRef(refID, AD, filter_name);
            }
            else
            {
                Console.WriteLine("\n{0, -20} {1, 5}\n", "Username", "GroupName");
                getUser(userID, AD, filter_name = null);
                Console.WriteLine("------------------------------------------------------\n");
                getRef(refID, AD, filter_name = null);
            }
        }
    }
}