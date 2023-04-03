using BambulBee.OnlineLoan.COMMON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    public class Logger
    {
        private static string logPath = string.Empty;

        public static void Write(string message)
        {
            try
            {
                if (GlobalValue.EnableLogger)
                {
                    string errorFilename = Path.Combine(GlobalValue.LogFilePath, System.DateTime.Today.ToString("yyyyMMdd") + "_ErrorLog.log");

                    StreamWriter sw = new StreamWriter(errorFilename, true);
                    sw.WriteLine(System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + ": " + message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Write(string filename, string message)
        {
            try
            {
                if (GlobalValue.EnableLogger)
                {
                    string errorFilename = Path.Combine(GlobalValue.LogFilePath, System.DateTime.Today.ToString("yyyyMMdd") + "_" + filename + ".log");

                    using (StreamWriter sw = new StreamWriter(errorFilename, true))
                    {
                        sw.WriteLine(System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + ": " + message);
                        sw.Flush();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Write(Exception exception)
        {
            try
            {
                if (GlobalValue.EnableLogger)
                {
                    string errorFilename = Path.Combine(GlobalValue.LogFilePath, System.DateTime.Today.ToString("yyyyMMdd") + "_ErrorLog.log");

                    using (StreamWriter sw = new StreamWriter(errorFilename, true))
                    {
                        sw.WriteLine("Date          : " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                        sw.WriteLine("Message       : " + exception.Message);
                        sw.WriteLine("Source        : " + exception.Source);
                        sw.WriteLine("StackTrace    : " + exception.StackTrace);
                        sw.WriteLine("----------------------------------------------------------------------------------");
                        sw.Flush();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Write(Exception exception, List<Parameter> parameters)
        {
            try
            {
                if (GlobalValue.EnableLogger)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (Parameter parameter in parameters)
                    {
                        builder.Append(parameter.Name.ToString()).Append(",").Append((object)parameter.Value ?? "Null").Append("|");
                    }

                    string errorFilename = Path.Combine(GlobalValue.LogFilePath, System.DateTime.Today.ToString("yyyyMMdd") + "_ErrorLog.log");

                    using (StreamWriter sw = new StreamWriter(errorFilename, true))
                    {
                        sw.WriteLine("Date          : " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                        sw.WriteLine("User          : " + GlobalValue.LoggedUser);
                        sw.WriteLine("Message       : " + exception.Message);
                        sw.WriteLine("Source        : " + exception.Source);
                        sw.WriteLine("StackTrace    : " + exception.StackTrace);
                        sw.WriteLine("Parameters    : " + builder.ToString().TrimEnd('|'));
                        sw.WriteLine("----------------------------------------------------------------------------------");
                        sw.Flush();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public class Parameter
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}