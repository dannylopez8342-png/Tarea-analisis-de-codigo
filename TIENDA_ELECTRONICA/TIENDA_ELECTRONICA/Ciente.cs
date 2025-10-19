using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TIENDA_ELECTRONICA
{
    class Ciente  //Ciente = Cliente solo que el programador no habia comido y tenia hambre (Se comió la L)
    {
        public void AgregarCliente(string pIdCliente, string pNombre, string pApellido, string pTelefono, string pCorreo, string pDireccion)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_Insertar_Cliente";
            mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
            mComando.Parameters.AddWithValue("@P_NOMBRE", pNombre);
            mComando.Parameters.AddWithValue("@P_APELLIDO", pApellido);
            mComando.Parameters.AddWithValue("@P_TELEFONO", pTelefono);
            mComando.Parameters.AddWithValue("@P_CORREO", pCorreo);
            mComando.Parameters.AddWithValue("@P_DIRECCION", pDireccion);
            mComando.ExecuteNonQuery();

        }


        public void ModificarCliente(string pIdCliente, string pNombre, string pApellido, string pTelefono, string pCorreo, string pDireccion)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_Modificar_Cliente";
            mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
            mComando.Parameters.AddWithValue("@P_NOMBRE", pNombre);
            mComando.Parameters.AddWithValue("@P_APELLIDO", pApellido);
            mComando.Parameters.AddWithValue("@P_TELEFONO", pTelefono);
            mComando.Parameters.AddWithValue("@P_CORREO", pCorreo);
            mComando.Parameters.AddWithValue("@P_DIRECCION", pDireccion);
            mComando.ExecuteNonQuery();
        }


        public void EliminarCliente(string pIdCliente)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "SP_Eliminar_Cliente";
            mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);
            mComando.ExecuteNonQuery();
        }



        public DataTable ListarCliente(string pIdCliente)
        {
            SqlConnection mConexion = new SqlConnection(@"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True");
            mConexion.Open();

            SqlCommand mComando = new SqlCommand();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            DataTable Datos = new DataTable();

            mComando.Connection = mConexion;
            mComando.CommandType = CommandType.StoredProcedure;
            mComando.CommandText = "sp_Listar_Cliente";
            mComando.Parameters.AddWithValue("@P_IdCliente", pIdCliente);

            Adaptador.SelectCommand = mComando;
            Adaptador.Fill(Datos);

            return Datos;
        }



    }
    
}
