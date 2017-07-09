using HW_CustomerMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YajiaMvc.Models.InputVlidation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ValidateEmail : DataTypeAttribute
    {

        public ValidateEmail() : base(DataType.Text)
        {

        }
        public override bool IsValid(object value)
        {
            客戶聯絡人 l_person = (客戶聯絡人)value;
            return isRepeatedEmail(l_person);
        }


        public bool isRepeatedEmail(客戶聯絡人 l_person)
        {
            客戶資料Entities db = new 客戶資料Entities();

            if (l_person.Id!=0)
            {
                return true;
            }
            var l_data = db.客戶聯絡人.Where(a =>a.客戶Id== l_person.客戶Id && a.Email == l_person.Email).ToList();
            return l_data.Count == 0;
        }
    }
}