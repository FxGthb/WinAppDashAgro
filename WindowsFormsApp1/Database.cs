﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Database
    {
        #region Attributes
        public SqlConnection connecion;
        private SqlCommand command;
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private BindingSource bindingSource;
        #endregion


        public Database()
        {
            this.connecion = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            
        }

        public bool openconnection()
        {
            try
            {
                this.connecion.Open();
                return true;
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show(sqlexception.ToString());
            }
            return false;
        }

        public bool closeconnecion()
        {
            try
            {                
                    this.connecion.Close();
                    return true;
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show(sqlexception.ToString());
            }
            return false;
        }

        public DataSet select(string querytext, string tableName)
        {
            dataSet = new DataSet();
            bindingSource = new BindingSource();
            command = new SqlCommand(querytext, connecion) { CommandType = CommandType.StoredProcedure };
            dataAdapter = new SqlDataAdapter {SelectCommand = command};
            dataAdapter.Fill(dataSet, tableName);
            //bindingSource.DataSource = dataSet.Tables[tableName];
            //foreach (DataRowView dr in bindingSource.List)
            //{
            //    MessageBox.Show(dr.ToString());
            //}
            return dataSet;                     
        }


        public void insert(string procName, List<Object> list, List<String> listparam)
        {
            var i = 0;
            command = new SqlCommand(procName, this.connecion) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            foreach (var val in list)
            {
                command.Parameters.AddWithValue(listparam[i++], val); 
            }
            command.ExecuteNonQuery();       
        }
    }
}