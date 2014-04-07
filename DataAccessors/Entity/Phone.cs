using MyOrm.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessors.Entity
{
    [Serializable]
    [Table(TableName="PhoneTbl")]
    public class Phone
    {
        [Id(ColumnName="id", ColumnType=DbType.Int32)]
        public int Id { get; set; }
        [Column(ColumnName = "number", ColumnType = DbType.String)]
        public string Number { get; set; }

        // from ORM-relation version
        //[One(SecondTable="PersonTable", ThisColumn="person_id")]
        //public Person Owner { get; set; }
    }
}
