using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ManejoArchivos.BE
{
    /// <summary>
    /// Objeto que representa a las propiedades y metodos comunes de una Entidad
    /// </summary>
    [Serializable]
    public class Base
    {
        #region Variables Publicas

        public int resultado { get; set; }
        public string mensaje { get; set; }
        public string usureg { get; set; }
        public string usumod { get; set; }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Valida el valor de la fecha, en caso sea igual a DateTime.MinValue devolverá null
        /// </summary>
        public object ValidarFecha(DateTime fecha)
        {
            object valor = null;

            if (fecha != DateTime.MinValue) valor = fecha;

            return valor;
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out short data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? (short)0 : Convert.ToInt16(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out byte[] data)
        {
            object rpta = DevolverData(dr, campo);

            data = (rpta == null) ? new byte[0] : rpta as byte[];
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out int data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToInt32(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out long data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToInt64(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out decimal data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToDecimal(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out bool data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? false : Convert.ToBoolean(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out string data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? string.Empty : Convert.ToString(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        protected void CargarVariable(IDataReader dr, string campo, out DateTime data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? DateTime.MinValue : Convert.ToDateTime(rpta);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Devuelve el valor del campo encontrado, sino encuentra el campo o el campo es nulo, devuelve null
        /// </summary>
        private object DevolverData(IDataReader dr, string campo)
        {
            object rpta = null;

            for (int iReader = 0; iReader < dr.FieldCount; iReader++)
            {
                if (string.Compare(dr.GetName(iReader), campo, true) == 0)
                {
                    if (!dr.IsDBNull(iReader))
                    {
                        rpta = dr.GetValue(iReader);
                        break;
                    }
                }
            }

            return rpta;
        }

        #endregion

        #region Liberación de Recursos

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Finalizador del objeto
        /// </summary>
        ~Base()
        {
            this.Dispose(false);
        }

        #endregion

    }

    /// <summary>
    /// Objeto que representa las operaciones de copia y clonacion de objetos
    /// </summary>
    public static class ObjectClone
    {

        /// <summary>
        /// Obtiene una copia de un objeto
        /// </summary>
        public static T Clone<T>(T objToClone)
        {
            using (Stream oStream = new MemoryStream())
            {
                IFormatter oFormatter = new BinaryFormatter();
                oFormatter.Serialize(oStream, objToClone);
                oStream.Seek(0, SeekOrigin.Begin);
                T oCloned = (T)oFormatter.Deserialize(oStream);
                oStream.Dispose();
                return oCloned;
            }
        }

    }
}
