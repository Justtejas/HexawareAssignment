using Insurance_Management_System.Model;
using Insurance_Management_System.Util;
using System.Data.SqlClient;

namespace Insurance_Management_System.DAO
{
    internal class InsuranceServiceImpl : IPolicyService
    {
        public bool IsPolicyPresent(int policyID)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "select * from Policies where PolicyID = @policyID";
            cmd.Parameters.AddWithValue("@policyID", policyID);
            cmd.Connection = conn;
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            bool isPresent = reader.HasRows;
            conn.Close();
            return isPresent;
        } 
        public bool ClaimPolicy(int policyID)
        {
            return true;
        }
        public bool CreatePolicy(Policy policy)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "Insert into Policies values(@PolicyNumber, @PolicyType, @AmountCovered,@StartDate,@EndDate)";
            cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
            cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
            cmd.Parameters.AddWithValue("@AmountCovered", policy.AmountCovered);
            cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
            cmd.Connection = conn;
            conn.Open();
            int createStatus = cmd.ExecuteNonQuery();
            conn.Close();
            return createStatus > 0; }
        public Policy GetPolicy(int policyId)
        {
            Policy policy = new();
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "Select * from Policies where PolicyID = @policyID";
            cmd.Parameters.AddWithValue("@policyID", policyId);
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    policy.PolicyID = Convert.ToInt32(reader["PolicyID"]);
                    policy.PolicyNumber = Convert.ToString(reader["PolicyNumber"]);
                    policy.PolicyType = Convert.ToString(reader["PolicyType"]);
                    policy.AmountCovered = Convert.ToDouble(reader["AmountCovered"]);
                    policy.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    policy.EndDate = Convert.ToDateTime(reader["EndDate"]);
                }
            }
            conn.Close();
            return policy;
        }
        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new();
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "Select * from Policies";
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Policy policy = new Policy(
                    Convert.ToInt32(reader["PolicyID"]),
                    Convert.ToString(reader["PolicyNumber"]),
                    Convert.ToString(reader["PolicyType"]),
                    Convert.ToDouble(reader["AmountCovered"]),
                    Convert.ToDateTime(reader["StartDate"]),
                    Convert.ToDateTime(reader["EndDate"])
                    );
                    policies.Add(policy);
                }
            }
            conn.Close();
            return policies;
        }
        public bool UpdatePolicy(string fieldName, object newValue, int policyID)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = $"Update Policies set {fieldName} = @newValue where PolicyID = @policyID";
            cmd.Parameters.AddWithValue("@policyID", policyID);
            cmd.Parameters.AddWithValue("@newValue", newValue);
            cmd.Connection = conn;
            conn.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            conn.Close();
            return updateStatus > 0;
        }
        public bool DeletePolicy(int policyID)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = $"Delete from Policies where PolicyID = @policyID";
            cmd.Parameters.AddWithValue("@policyID", policyID);
            cmd.Connection = conn;
            conn.Open();
            int deleteStatus = cmd.ExecuteNonQuery();
            conn.Close();
            return deleteStatus > 0;
        }
        public bool RegisterUser(User user)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "Insert into Users values(@UserID, @UserName, @Password)";
            cmd.Parameters.AddWithValue("@UserID", user.UserID);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Connection = conn;
            conn.Open();
            int registerStatus = cmd.ExecuteNonQuery();
            conn.Close();
            return registerStatus > 0; }
        public bool Login(string username, string password)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            using SqlCommand cmd = new();
            cmd.CommandText = "Select UserName,Password from Users where UserName = @username";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Convert.ToString(reader["UserName"]) == username && Convert.ToString(reader["Password"]) == password)
                    {
                        return true;
                    }
                }
            }
            conn.Close();
            return false;
        }
    }
}

