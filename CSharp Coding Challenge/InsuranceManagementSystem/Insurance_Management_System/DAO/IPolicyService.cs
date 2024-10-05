using Insurance_Management_System.Model;

namespace Insurance_Management_System.DAO
{
    internal interface IPolicyService
    {
        public bool IsPolicyPresent(int policyId);
        public bool ClaimPolicy(int policyID);
        public bool CreatePolicy(Policy policy);
        public Policy GetPolicy(int policyId);
        public List<Policy> GetAllPolicies();
        public bool UpdatePolicy(string fieldName, object newValue, int policyID);
        public bool DeletePolicy(int policyID);
        public bool RegisterUser(User user);
        public bool Login(string username, string password);
    }
}
