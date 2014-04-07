using MyOrm.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace DataAccessors.Entity
{
    [Serializable]
    [Table(TableName = "PersonTable")]
    public class Person
    {
        public Person()
        {
            DayOfBirth = DateTime.Now;
        }

        [Id(ColumnName = "identificator", ColumnType = DbType.Int32)]
        public int ID { get; set; }
        [Column(ColumnName = "NameColumn", ColumnType = DbType.String)]
        public string Name { get; set; }
        [Column(ColumnName = "LastNameColumn", ColumnType = DbType.String)]
        public string LastName { get; set; }
        [Column(ColumnName = "dob", ColumnType = DbType.Date)]
        public DateTime DayOfBirth { get; set; }
        
        // from ORM-relation version
        /*
        [XmlIgnore]
        [Many(SecondTable = "PhoneTbl", SecondColumn = "person_id")]
        public ICollection<Phone> Phones { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0, 5}, name: {1, 10}, lastname: {2, 10}, DayOfBirth: {3}, Phones: {4, 3}",
                ID, Name.Trim(), LastName.Trim(), DayOfBirth.ToString("d MMM yyyy"), Phones == null ? 0 : Phones.Count);
        }
        */

        public override string ToString()
        {
            return String.Format("id: {0, 5}, name: {1, 10}, lastname: {2, 10}, DayOfBirth: {3}",
                ID, Name.Trim(), LastName.Trim(), DayOfBirth.ToString("d MMM yyyy"));
        }
    }
}
