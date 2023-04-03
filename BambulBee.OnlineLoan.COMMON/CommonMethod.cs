using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace BambulBee.OnlineLoan.COMMON
{
    public class CommonMethod
    {
        public List<ComboModel> getEnumDescription<T>()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboModel { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> getEnumDescriptionWithSelect<T>()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = "- Select -" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboModel { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public string GetPasswordResetMessage(string name, string userID, string password)
        {
            throw new System.NotImplementedException();
        }

        public List<ComboModel> ComboDataBindByEnum<T>()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = "- Select -", Value = "" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboModel { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataBindByEnum<T>(string selectString)
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = selectString, Value = "" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboModel { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataBindByEnumhh()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = "HH", Value = "" });

                for (int i = 0; i < 24; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboModel { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataBindByEnumMM()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = "MM", Value = "" });

                for (int i = 0; i < 60; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboModel { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataDateOfMonth()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Text = "DD", Value = "" });
                for (int i = 0; i <= 31; i++)
                {
                    string date = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboModel { Value = date, Text = date });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataBindHH()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboModel { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboModel> ComboDataBindMM()
        {
            List<ComboModel> oData = new List<ComboModel>();
            try
            {
                oData.Add(new ComboModel { Value = "0", Text = "00" });
                oData.Add(new ComboModel { Value = "30", Text = "30" });
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ConvertHundredMinutesToMinutes(string time)
        {
            decimal minutes = Convert.ToDecimal(time);
            decimal hundred = minutes / 100;
            decimal retval = hundred * 60;

            return Convert.ToInt32(retval);
        }

        public static int ConvertHundredTimetoMinutes(decimal time)
        {
            int hour = 0;
            int minutes = 0;

            hour = Convert.ToInt32(time.ToString().Split('.')[0]);

            if (time.ToString().Contains("."))
                minutes = Convert.ToInt32(time.ToString().Split('.')[1]);

            return (hour * 60) + ConvertHundredMinutesToMinutes((minutes * 10).ToString());
        }

        public static int ConvertMinutesToHundredMinutes(int minutepart)
        {
            decimal minutes = Convert.ToDecimal(minutepart);
            decimal a = minutes / 60;
            int b = Convert.ToInt32(a * 100);

            return b;
        }

        public static decimal ConvertMinutesToHundredTime(decimal totalminutes)
        {
            int hours = Convert.ToInt32(totalminutes) / 60;
            decimal minutes = totalminutes % 60;
            decimal a = minutes / 60;
            decimal b = a * 100;
            int hundred = Convert.ToInt32(b);
            string time = hours.ToString() + "." + hundred.ToString();
            return Convert.ToDecimal(time);
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}