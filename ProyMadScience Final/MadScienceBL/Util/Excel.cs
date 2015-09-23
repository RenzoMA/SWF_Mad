using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MadScienceBL.Util
{
    public class Excel
    {
        //String connExcel03 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        String connExcel07 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";


        public DataSet LoadExcel(string ruta, string ext, Boolean header)
        {

            String conStr = "";
            String headerStr = "";

            switch (ext)
            {
                case ".xls": conStr = connExcel07; break;
                case ".xlsx": conStr = connExcel07; break;
            }
            if (header)
                headerStr = "YES";
            else
                headerStr = "NO";

            conStr = String.Format(conStr, ruta, headerStr);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter(cmdExcel);
            DataSet dts = new DataSet("Libro");
            cmdExcel.Connection = connExcel;
            try
            {
                connExcel.Open();
                foreach (String sheet in GetExcelSheetNames(ruta, ext, header))
                {
                    DataTable dt = new DataTable();
                    dt.TableName = sheet;
                    if (sheet.Equals("'FORMATO RESERVAS$'"))
                    {
                        cmdExcel.CommandText = "SELECT * FROM [" + sheet + "] where [FECHA CELEBRACIÓN] not like '' or [NOMBRE CLIENTE ] not like '' or [NOMBRE DEL NIÑO] not like '' ";
                        oda.Fill(dt);

                        dts.Tables.Add(dt);
                    }
                    else
                    {
                        cmdExcel.CommandText = "SELECT * FROM [" + sheet + "]";
                    }
                    if (sheet.Equals("ESPECIALIDADES$"))
                    {
                        cmdExcel.CommandText = "SELECT * FROM [" + sheet + "] where [NOMBRE] not like ''";
                    }
                    if (sheet.Equals("DISPONIBILIDAD$"))
                    {
                        cmdExcel.CommandText = "SELECT * FROM [" + sheet + "] where [API] not like ''";
                    }
                   
                }
                connExcel.Close();
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connExcel.State == ConnectionState.Open)
                {
                    connExcel.Close();
                }
            }
        }

        public string[] GetExcelSheetNames(string ruta, string ext, Boolean header)
        {
            String conStr = "";
            String headerStr = "";

            switch (ext)
            {
                case ".xls": conStr = connExcel07; break;
                case ".xlsx": conStr = connExcel07; break;
            }
            if (header)
                headerStr = "YES";
            else
                headerStr = "NO";

            conStr = String.Format(conStr, ruta, headerStr);
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(conStr);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }
            con.Close();
            return excelSheetNames;

        }
    }
}
