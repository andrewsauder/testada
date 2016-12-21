using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Testada
{
    class db
    {
        public string connectionStr = "";

        public db(string useConnectionStr)
        {
            this.connectionStr = useConnectionStr;
        }



        public int write(string query, object[] parameters = null)
        {

            using (SqlConnection openCon = new SqlConnection(connectionStr))
            {

                using (SqlCommand qObj = new SqlCommand(query))
                {
                    qObj.Connection = openCon;

                    if (parameters != null)
                    {
                        foreach (object[] param in parameters)
                        {
                            //qObj.Parameters.Add("@" + param[0], param[1]).Value = param[2];
                            qObj.Parameters.AddWithValue("@" + param[0], param[1]);
                        }
                    }

                    openCon.Open();
                    SqlDataReader rdr = qObj.ExecuteReader();
                    openCon.Close();
                }
            }

            return 0;

        }

        public IDictionary<string, dynamic> readOneRow(string query, object[] parameters = null)
        {

            object[] obj = { };

            IDictionary<string, dynamic> dict = new Dictionary<string, dynamic>();

            using (SqlConnection newCon = new SqlConnection(connectionStr))
            {

                SqlCommand newCmd = new SqlCommand(query, newCon);

                if (parameters != null)
                {
                    foreach (object[] param in parameters)
                    {
                        newCmd.Parameters.AddWithValue("@" + param[0], param[1]);
                    }
                }

                newCon.Open();
                SqlDataReader rdr = newCmd.ExecuteReader();
                rdr.Read();

                //if there is a row of data
                try
                {
                    var columns = new List<string>();

                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dict[rdr.GetName(i)] = rdr[i];
                    }

                }
                //no data was returned from query
                catch
                {
                    //return blank object
                }
                //run wether data was returned or not
                finally
                {
                    // Always call Close when done reading.
                    rdr.Close();
                }

            }

            return dict;

        }

        public List<Dictionary<string, dynamic>> read(string query, object[] parameters = null)
        {

            object[] obj = new object[0];

            List<Dictionary<string, dynamic>> list = new List<Dictionary<string, dynamic>>();

            using (SqlConnection newCon = new SqlConnection(connectionStr))
            {

                SqlCommand newCmd = new SqlCommand(query, newCon);

                if (parameters != null)
                {
                    foreach (object[] param in parameters)
                    {
                        newCmd.Parameters.AddWithValue("@" + param[0], param[1]);
                    }
                }

                newCon.Open();
                SqlDataReader rdr = newCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {

                            dict[rdr.GetName(i)] = rdr[i];

                        }

                        list.Add(dict);
                    }
                }

                rdr.Close();

            }

            return list;

        }
    }

}
