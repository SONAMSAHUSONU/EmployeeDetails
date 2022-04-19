using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails
{
     class Program
    {

        static void Main(string[] args)
        {
            Program obj = new Program();
            List<EmpDetails> employe = obj.GetData();
            foreach (var item in employe)
            {
                Console.WriteLine(item.E_id);
                Console.WriteLine(item.E_Fname);
                Console.WriteLine(item.E_Lname);
                Console.WriteLine(item.E_Mobile);
                Console.WriteLine(item.E_Age);
                Console.WriteLine(item.E_Email);

            }
            
            Console.ReadLine();

        }
        public List<EmpDetails> GetData()
        {
            string Myconnection = "server=DESKTOP-93EJUAM;database=EMP_Test;Integrated Security = SSPI"; //we make the connection here
            
                SqlConnection con = new SqlConnection(Myconnection);
                SqlCommand cmd = new SqlCommand("SP_GetEmpsData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                List<EmpDetails> GetData = new List<EmpDetails>();

                while (dr.Read())
                {
                    EmpDetails oEmpDetails = new EmpDetails();

                    oEmpDetails.E_id = Convert.ToInt32(dr["E_id"]);
                    oEmpDetails.E_Fname = Convert.ToString(dr["E_Fname"]);
                    oEmpDetails.E_Lname = Convert.ToString(dr["E_Lname"]);
                    oEmpDetails.E_Mobile = Convert.ToString(dr["E_Mobile"]);
                    oEmpDetails.E_Age = Convert.ToInt32(dr["E_Age"]);
                    oEmpDetails.E_Email = Convert.ToString(dr["E_Email"]);
                    GetData.Add(oEmpDetails);
                }
                return GetData;

            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
    }
    public class EmpDetails
    {
        public int E_id { get; set; }
        public string  E_Fname { get; set; }
        public string  E_Lname { get; set; }
        public string E_Mobile { get; set; }
        public int E_Age { get; set; }
        public string E_Email { get; set; }

    }
}
