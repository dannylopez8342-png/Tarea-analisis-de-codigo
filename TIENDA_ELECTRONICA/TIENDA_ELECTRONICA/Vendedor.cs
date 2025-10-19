using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TIENDA_ELECTRONICA
{
    public class Vendedor
    {
        public void AgregarVendedor(string pIdvendedor, string pNombre, string pApellido, string pTelefono, string pCorreo, DateTime pFechaingreso)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "SP_InsertarVendedor";
            mComando.Parameters.AddWithValue("@P_IdVendedor", pIdvendedor);
            mComando.Parameters.AddWithValue("@P_Nombre", pNombre);
            mComando.Parameters.AddWithValue("@P_Apellido", pApellido);
            mComando.Parameters.AddWithValue("@P_Telefono", pTelefono);
            mComando.Parameters.AddWithValue("@P_Correo", pCorreo);
            mComando.Parameters.AddWithValue("@P_FechaIngreso", pFechaingreso);
            mComando.ExecuteNonQuery();

        }

        public void ModificarVendedor(string pIdvendedor, string pNombre, string pApellido, string pTelefono, string pCorreo, DateTime pFechaingreso)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_ModificarVendedor";
            mComando.Parameters.AddWithValue("@P_IdVendedor", pIdvendedor);
            mComando.Parameters.AddWithValue("@P_NOMBRE", pNombre);
            mComando.Parameters.AddWithValue("@P_APELLIDO", pApellido);
            mComando.Parameters.AddWithValue("@P_Telefono", pTelefono);
            mComando.Parameters.AddWithValue("@P_Correo", pCorreo);
            mComando.Parameters.AddWithValue("@P_FechaIngreso", pFechaingreso);
            mComando.ExecuteNonQuery();
        }


        public void EliminarVendedor(string pIdVendedor)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_EliminarVendedor";
            mComando.Parameters.AddWithValue("@PIdVendedor", pIdVendedor);
            mComando.ExecuteNonQuery();
        }


        public DataTable ListarVendedor(string pIdVendedor)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            DataTable Datos = new DataTable();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_Listar_Vendedor";
            mComando.Parameters.AddWithValue("@P_IdVendedor", pIdVendedor);


            Adaptador.SelectCommand = mComando;
            Adaptador.Fill(Datos);

            return Datos;

        }

    }


}

