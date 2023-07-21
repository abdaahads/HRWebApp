namespace BOL;

public class Employee
{
    private int id;
    private string empname;
    private string designation;
    private string city;
    private Department department;
    private int salary;
    private DateOnly joiningdate;

    public Employee()
    {

    }

    public Employee(int id, string empname, string designation, string city, Department department, int salary, DateOnly joiningdate)
    {
        this.id = id;
        this.empname = empname;
        this.designation = designation;
        this.city = city;
        this.department = department;
        this.salary = salary;
        this.joiningdate = joiningdate;
    }

    public int ID { get { return id; } set { this.id = value; } }
    public string EMPNAME { get { return empname; } set { this.empname = value; } }
    public string DESIGNATION { get { return designation; } set { this.designation = value; } }
    public string CITY { get { return city; } set { this.city = value; } }
    public Department DEPARTMENT { get { return department; } set { this.department = value; } }
    public int SALARY { get { return salary; } set { this.salary = value; } }
    public DateOnly JOININGDATE { get { return joiningdate; } set { this.joiningdate = value; } }

    
    public override string ToString()
    {
        return "Employee: \nId: " + this.id + "\nEmployee Name: " + this.empname + "\nDesignation: " + this.designation + "\nCity: " + this.city + "\nDepartment: " + this.department + "\nSalary: " + this.salary + "\nJoining Date: " + this.joiningdate;
    }
}

public enum Department
{
    HR, SALES, FINANCE, MARKETING, IT, SUPPORT
}

