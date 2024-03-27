namespace Filters.Models
{
    /// <summary>
    /// class representing a result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Roll number of the student.
        /// </summary>
        public int RollNumber { get; set; }
        /// <summary>
        /// Name of the student.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SPI of the student.
        /// </summary>
        public double Spi { get; set; }
        /// <summary>
        /// CPI of the student.
        /// </summary>
        public double Cpi { get; set; }
        /// <summary>
        /// CGPA of the student.
        /// </summary>
        public double Cgpa { get; set; }
    }
}
