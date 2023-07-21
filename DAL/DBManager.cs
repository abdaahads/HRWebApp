namespace DAL;

using BOL;
using MySql.Data.MySqlClient;

public class DBManager
{
    public static string conString = @"server=localhost;port=3306;user=root; password=root1234;database=HRWEBAPP";

    public static List<Employee> GetAllEmployees()
    {
        List<Employee> empList = new List<Employee>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string query = "SELECT * FROM EMPLOYEES";

            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string empname = reader["empname"].ToString();
                string designation = reader["designation"].ToString();
                string city = reader["city"].ToString();
                Department department = Enum.Parse<Department>(reader["department"].ToString());
                int salary = int.Parse(reader["salary"].ToString());
                DateOnly joiningdate = DateOnly.FromDateTime(DateTime.Parse(reader["joiningdate"].ToString()));

                Employee newEmployee = new Employee(id, empname, designation, city, department, salary, joiningdate);

                empList.Add(newEmployee);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

        return empList;
    }

    public static void InsertEmployee (Employee newEmployee)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string query ="INSERT INTO EMPLOYEES VALUES ("+newEmployee.ID+",'"+newEmployee.EMPNAME+"','"+newEmployee.DESIGNATION+"','"+newEmployee.CITY+"','"+newEmployee.DEPARTMENT+"','"+newEmployee.SALARY+"','"+newEmployee.JOININGDATE.ToString("yyyy-MM-dd")+"')";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    public static void DeleteEmployeeById (int id)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string query = "DELETE FROM EMPLOYEES WHERE ID = " + id;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    public static Employee GetEmployeeById(int empid)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;

        Employee foundEmployee = new Employee();

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string query = "SELECT * FROM EMPLOYEES WHERE ID = " + empid;
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string empname = reader["empname"].ToString();
                string designation = reader["designation"].ToString();
                string city = reader["city"].ToString();
                Department department = Enum.Parse<Department>(reader["department"].ToString());
                int salary = int.Parse(reader["salary"].ToString());
                DateOnly joiningdate = DateOnly.FromDateTime(DateTime.Parse(reader["joiningdate"].ToString()));

                foundEmployee = new Employee(id, empname, designation, city, department, salary, joiningdate);

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
        return foundEmployee;
    }

    public static void UpdateEmployee (Employee emp)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;
        Employee foundEmployee = new Employee();

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            string query = "UPDATE EMPLOYEES SET EMPNAME = '" + emp.EMPNAME + "', DESIGNATION = '" + emp.DESIGNATION + "', CITY = '" + emp.CITY + "', DEPARTMENT = '" + emp.DEPARTMENT + "', SALARY = '" + emp.SALARY + "', JOININGDATE = '" + emp.JOININGDATE.ToString("yyyy-MM-dd") + "' WHERE ID = " + emp.ID;

            cmd.CommandText = query;

            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}

