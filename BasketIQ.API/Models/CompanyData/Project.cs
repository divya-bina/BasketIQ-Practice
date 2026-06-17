namespace BasketIQ.API.Models.CompanyData
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Budget { get; set; }
        public List<string> Technologies_Used { get; set; }
    }

    public class RootData
    {
        public Company Company { get; set; }
        public List<SkillsCatalog> Skills_Catalog { get; set; }
        public List<Project> Projects { get; set; }
        public List<Department> Departments { get; set; }
        public List<RolesHierarchy> Roles_Hierarchy { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public int Founded { get; set; }
        public string Headquarters { get; set; }
        public double Revenue_Usd { get; set; }
        public bool Is_Public { get; set; }
    }

    public class SkillsCatalog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public string Manager_Id { get; set; }
    }

    public class RolesHierarchy
    {
        public string Title { get; set; }
        public string Department_Id { get; set; }
        public string Reports_To_Title { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department_Id { get; set; }
        public string Role_Title { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }
        public string Joining_Date { get; set; }
        public int Days_Worked { get; set; }
        public bool Is_Remote { get; set; }
        public List<SkillsMastered> Skills_Mastered { get; set; }
        public List<AssignedProject> Assigned_Projects { get; set; }
    }

    public class SkillsMastered
    {
        public string Skill_Id { get; set; }
        public int Years_Experience { get; set; }
    }

    public class AssignedProject
    {
        public string Project_Id { get; set; }
        public string Role_In_Project { get; set; }
    }

    public class UpdateProjectRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Budget { get; set; }
        public List<string> Technologies_Used { get; set; }
    }

    public class EmployeeWithDepartmentResponse
    {
        public string Id{ get; set; }
        public string Name { get; set; }
        public string Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string Role_Title { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }
        public string Joining_Date { get; set; }
        public int Days_Worked { get; set; }
        public bool Is_Remote { get; set; }
        public List<SkillsMastered> Skills_Mastered { get; set; }
        public List<AssignedProject> Assigned_Projects { get; set; }
    }



    public class SkillWithCategory
    {
        public string Skill_Name { get; set; }

        public string Category { get; set; }
       
    }

    public class EmployeeWithCategoryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string Role_Title { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }
        public string Joining_Date { get; set; }
        public int Days_Worked { get; set; }
        public bool Is_Remote { get; set; }
        public List<SkillWithCategory> Skills_Mastered { get; set; }
        
        

    }


    public class EmployeeWithProjectResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string Role_Title { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }
        public string Joining_Date { get; set; }
        public int Days_Worked { get; set; }
        public bool Is_Remote { get; set; }
        public List<SkillsMastered> Skills_Mastered { get; set; }
        public List<AssignedProjectWithName> Assigned_Projects { get; set; } 
    }

    public class AssignedProjectWithName
    {
     
        public string Project_Name { get; set; }   
       
    }

}