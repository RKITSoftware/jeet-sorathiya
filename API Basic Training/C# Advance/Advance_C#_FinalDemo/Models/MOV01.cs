using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advance_C__FinalDemo.Models
{
    /// <summary>
    /// Represents a movie model
    /// </summary>
    [Alias("MOV01")] // Specifies the table name in the database
    public class MOV01
    {
        /// <summary>
        /// Gets or sets the ID of the movie
        /// </summary>
        [AutoIncrement] // Auto-incrementing primary key
        [PrimaryKey] // Primary key attribute
        public int V01F01 { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie
        /// </summary>
        public string V01F02 { get; set; }

        /// <summary>
        /// Gets or sets the release date of the movie
        /// </summary>
        public DateTime V01F03 { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the category of the movie
        /// </summary>
        [ForeignKey(typeof(CAT01))] // Specifies the foreign key relationship with the CAT01 table
        public int V01F04 { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the director of the movie
        /// </summary>
        [ForeignKey(typeof(DIR01))] // Specifies the foreign key relationship with the DIR01 table
        public int V01F05 { get; set; }
    }
}