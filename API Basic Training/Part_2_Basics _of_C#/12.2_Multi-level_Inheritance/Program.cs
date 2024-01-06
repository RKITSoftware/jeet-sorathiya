using System;

namespace _12._2_Multi_level_Inheritance
{
    #region Employee
    /// <summary>
    /// base class Employee
    /// </summary>
    class Employee
    {
        #region field
        /// <summary>
        /// Gets or sets the name, Role of the employee.
        /// </summary>
        public string Name { get; set; }
        public string Role { get; set; }
        #endregion

        #region method
        /// <summary>
        /// method introduce
        /// </summary>
        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {Name}, a {Role}.");
        }
        #endregion
    }
    #endregion

    #region HR
    /// <summary>
    /// class HR, inheriting from the Employee class.
    /// </summary>
    class HR : Employee
    {
        #region field
        /// <summary>
        /// Gets or sets the department
        /// </summary>
        public string Department { get; set; }
        #endregion

        #region method
        /// <summary>
        /// method DisplayDepartment
        /// </summary>
        public void DisplayDepartment()
        {
            Console.WriteLine($"from {Department} department.");
        }
        #endregion
    }
    #endregion

    #region TeamLead
    /// <summary>
    ///class Team Leads, inheriting from the HR class.
    /// </summary>
    class TeamLead : HR
    {
        #region field
        /// <summary>
        /// Gets or sets TeamSize
        /// </summary>
        public int TeamSize { get; set; }
        #endregion

        #region method
        /// <summary>
        /// method DisplayTeamSize
        /// </summary>
        public void DisplayTeamSize()
        {
            Console.WriteLine($"I lead a team of {TeamSize} members.");
        }
        #endregion
    }
    #endregion

    #region Trainee
    /// <summary>
    /// class Trainees, inheriting from the TeamLead class.
    /// </summary>
    class Trainee : TeamLead
    {
        #region field
        /// <summary>
        /// Gets or sets the trainingprogram
        /// </summary>
        public string TrainingProgram { get; set; }
        #endregion

        #region method
        /// <summary>
        ///method DisplayTrainingProgram
        /// </summary>
        public void DisplayTrainingProgram()
        {
            Console.WriteLine($"I am enrolled in the {TrainingProgram} training program.");
        }
        #endregion
    }
    #endregion

    #region Program Class
    /// <summary>
    ///program class
    /// </summary>
    class Program
    {
        #region Main Method
        /// <summary>
        /// main method
        /// </summary>
        static void Main()
        {
            HR objofHr = new HR
            {
                Name = "Rushi",
                Role = "HR Professional",
                Department = "Human Resources"
            };

            objofHr.Introduce();
            objofHr.DisplayDepartment();


            TeamLead teamLead = new TeamLead
            {
                Name = "Jeet",
                Role = "Team Lead",
                Department = "Engineering",
                TeamSize = 10
            };

            teamLead.Introduce();
            teamLead.DisplayDepartment();
            teamLead.DisplayTeamSize();

            Trainee trainee = new Trainee
            {
                Name = "Aryan",
                Role = "Trainee",
                Department = "Engineering",
                TeamSize = 5,
                TrainingProgram = "Software Development"
            };

            trainee.Introduce();
            trainee.DisplayDepartment();
            trainee.DisplayTeamSize();
            trainee.DisplayTrainingProgram();
        }
        #endregion
    }
    #endregion

}
