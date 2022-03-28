using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        E_Categoria entidad = new E_Categoria();
        N_Categoria negocio = new N_Categoria();
        private String idCategoria;
        private char operation;
        public FrmCategoria()
        {
            InitializeComponent();
            this.BtnSave.Visible = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            
        }
        public void mostrarBuscarTablas(String buscar)
        {
            N_Categoria negcio = new N_Categoria();
            tblCategoria.DataSource = negcio.listarCategoria(buscar);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            this.operation = 'C';

            this.txtBuscar.Text = "";
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";

            this.txtNombre.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.BtnSave.Visible = true;
            this.BtnSave.Image = imageList1.Images[0];
            this.txtNombre.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           
            if (tblCategoria.SelectedRows.Count > 0)
            {
                this.operation = 'U';

                idCategoria = tblCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tblCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tblCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tblCategoria.CurrentRow.Cells[3].Value.ToString();

                this.txtNombre.Enabled = true;
                this.txtDescripcion.Enabled = true;

                this.txtNombre.Focus();

                this.BtnSave.Visible = true;
                this.BtnSave.Image = imageList1.Images[1];
            }
            else
            {
                MessageBox.Show("eliga una fila para editar");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tblCategoria.SelectedRows.Count > 0)
            {
                this.operation = 'D';

                idCategoria = tblCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tblCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tblCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tblCategoria.CurrentRow.Cells[3].Value.ToString();
                
                this.BtnSave.Visible = true;
                this.BtnSave.Image = imageList1.Images[2];
            }
            else
            {
                MessageBox.Show("eliga la fila a eliminar");
            }
            
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            mostrarBuscarTablas("");
            accionTbl();
        }
        public void accionTbl()
        {
            tblCategoria.Columns[0].Visible = false;
            tblCategoria.Columns[1].Width = 90;
            tblCategoria.Columns[2].Width = 170;
            tblCategoria.Columns[3].Width = 225;

            tblCategoria.ClearSelection();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            mostrarBuscarTablas(txtBuscar.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (operation.Equals('C'))
            {
                try
                {
                    entidad.Nombre = txtNombre.Text.ToUpper();
                    entidad.Descripcion = txtDescripcion.Text.ToUpper();
                    negocio.create(entidad);

                    MessageBox.Show("Registro con exito!!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo realizar el registro" + ex.Message);
                }
                finally
                {
                    limpiar();
                }
            }
            else if (operation.Equals('U'))
            {
                try
                {
                    entidad.IdCategoria = Convert.ToInt32(idCategoria);
                    entidad.Nombre = txtNombre.Text.ToUpper();
                    entidad.Descripcion = txtDescripcion.Text.ToUpper();
                    negocio.update(entidad);

                    MessageBox.Show("Se edito el registro con exito!!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo actualizar el registro" + ex.Message);
                }
                finally
                {
                    limpiar();
                }
            }
            else if (operation.Equals('D'))
            {
                try
                {
                    entidad.IdCategoria = Convert.ToInt32(idCategoria);
                    negocio.delete(entidad);

                    MessageBox.Show("Registro eliminado con exito!!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falla al eliminar el registro" + ex.Message);
                }
                finally
                {
                    limpiar();
                }
                
            }
        }
        private void limpiar()
        {
            this.txtBuscar.Text = "";
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";

            this.txtCodigo.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtDescripcion.Enabled = false;

            this.BtnSave.Visible = false;

            mostrarBuscarTablas("");
        }
    }
}
