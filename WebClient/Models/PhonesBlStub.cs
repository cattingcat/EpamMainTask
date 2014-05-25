using BusinessLogic;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class PhonesBlStub: IPhoneBll
    {
        private List<Phone> _phones;

        public PhonesBlStub()
        {
            _phones = new List<Phone>
            {
                new Phone{Id=1, Number="123", PersonId=1},
                new Phone{Id=2, Number="234", PersonId=1},
                new Phone{Id=3, Number="345", PersonId=2},
                new Phone{Id=4, Number="456", PersonId=3},
            };
        }

        public IEnumerable<DataAccessors.Entity.Phone> GetPhones()
        {
            return _phones;
        }

        public IEnumerable<DataAccessors.Entity.Phone> GetPhones(object personId)
        {
            return (from p in _phones where p.PersonId == (int)personId select p);
        }

        public DataAccessors.Entity.Phone GetPhone(object id)
        {
            return (from p in _phones where p.Id == (int)id select p).SingleOrDefault();
        }

        public void DeletePhone(object phoneId)
        {
            var p = GetPhone(phoneId);
            _phones.Remove(p);
        }

        public void UpdatePhone(DataAccessors.Entity.Phone phone)
        {
            var p = GetPhone(phone.Id);
            if (p != null)
                DeletePhone(phone.Id);
            _phones.Add(phone);
        }

        public void AddPhone(DataAccessors.Entity.Phone phone)
        {
            var p = GetPhone(phone.Id);
            if (p != null)
                DeletePhone(phone.Id);
            _phones.Add(phone);
        }
    }
}