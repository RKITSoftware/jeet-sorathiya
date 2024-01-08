using System;

namespace _12._1_Single_Inheritance
{
    #region Employee
    /// <summary>
    /// base class employees.
    /// </summary>
    class Employee
    {

        #region public field
        /// <summary>
        /// Gets or sets the Name, Role of the employee.
        /// </summary>
        public string Name { get; set; }
        public string Role { get; set; }
        #endregion

        #region public method
        /// <summary>
        /// Common method for all employees.
        /// </summary>
        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {Name}, a {Role}.");
        }
        #endregion
    }
    #endregion

    #region TeamLead
    /// <summary>
    /// derived class TeamLeads, inheriting from the Employee class.
    /// </summary>
    class TeamLead : Employee
    {
        #region public field
        /// <summary>
        /// Gets or sets the TeamSize.
        /// </summary>
        public int TeamSize { get; set; }
        #endregion

        #region public method
        /// <summary>
        /// method for to display team size.
        /// </summary>
        public void DisplayTeamSize()
        {
            Console.WriteLine($"I have {TeamSize} members in my Team");
        }
        #endregion
    }
    #endregion

    #region Trainee
    /// <summary>
    /// derived class Trainees, inheriting from the Employee class.
    /// </summary>
    class Trainee : Employee
    {
        #region public field
        /// <summary>
        /// Gets or sets trainingprogram.
        /// </summary>
        public string TrainingProgram { get; set; }
        #endregion

        #region public method
        /// <summary>
        /// method for display training program.
        /// </summary>
        public void DisplayTrainingProgram()
        {
            Console.WriteLine($"I am enrolled in the {TrainingProgram} training program.");
        }
        #endregion
    }
    #endregion

    #region Program
    /// <summary>
    /// class program
    /// </summary>
    internal class Program
    {
        #region main method
        /// <summary>
        /// main method.
        /// </summary>
        static void Main()
        {
            TeamLead objofTeamLead = new TeamLead
            {
                Name = "Jeet",
                Role = "Team Lead",
                TeamSize = 10
            };

            objofTeamLead.Introduce();
            objofTeamLead.DisplayTeamSize();

            Trainee objofTrainee = new Trainee
            {
                Name = "Aryan",
                Role = "Trainee",
                TrainingProgram = "Software Development"
            };

            objofTrainee.Introduce();
            objofTrainee.DisplayTrainingProgram();
        }
        #endregion
    }
    #endregion

}
