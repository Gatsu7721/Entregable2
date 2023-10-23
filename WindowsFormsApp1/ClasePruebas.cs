using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class ClasePruebas
    {
        ModelDatosDataContext db = new ModelDatosDataContext();

        public List<Tb_Prueba> listar()
        {
            List<Tb_Prueba> list = db.Tb_Prueba.ToList();
            return list;
        }

        public Tb_Prueba obtener(int key)
        {
            Tb_Prueba objeto = db.Tb_Prueba.Single(r=>r.idPrueba== key);
            return objeto;
        }

        public void registrar(Tb_Prueba objprueba)
        {
            db.Tb_Prueba.InsertOnSubmit(objprueba);
            db.SubmitChanges();
        }
        public void actualizar(Tb_Prueba objprueba)
        {
            Tb_Prueba objactualiza = db.Tb_Prueba.Single(r => r.idPrueba == objprueba.idPrueba);
            objactualiza.nombre = objprueba.nombre;
            objactualiza.apellido = objprueba.apellido;
            objactualiza.dni = objprueba.dni;
            db.SubmitChanges();
        }

        public void eliminar(int key)
        {
            Tb_Prueba objeliminar = db.Tb_Prueba.Single(r => r.idPrueba == key);
            db.Tb_Prueba.DeleteOnSubmit(objeliminar);
            db.SubmitChanges();
        }

    }
}
