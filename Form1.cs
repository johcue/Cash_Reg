using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taller6Ejercicio4_Caja_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DefinirSaldo.Checked = true;
            btnIngresar.Enabled = false;
        }
        class Caja
        {
            public double ValorIngresado, Saldo, Sum = 0, ValorPago, Devuelta, Ingresos = 0, Egresos = 0;

            public bool PermitirSaldo(double valor)
            {
                if (valor >= 50000)
                    return false;
                else
                    return true;
            }
            public void SumaProductos(double Valor)
            {
                Sum += Valor;
            }
            public void QuitaProductos(double Valor)
            {
                Sum -= Valor;
            }

            public bool PosiblePago(double Valor)
            {
                if (Valor > Saldo)
                    return false;
                else
                    return true;
            }
            public void EfectuarPago(double VPagado, double VDevuelto)
            {
                Ingresos += -VPagado + VDevuelto;
                Saldo += -VPagado + VDevuelto;
            }
        }
        Caja NuevoUsuario = new Caja();

        private void btnIng1_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "1";
        }

        private void brnIng2_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "2";
        }

        private void brnIng3_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "3";
        }

        private void brnIng4_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "4";
        }

        private void brnIng5_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "5";
        }

        private void brnIng6_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "6";
        }

        private void brnIng7_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "7";
        }

        private void brnIng8_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "8";
        }

        private void brnIng9_Click(object sender, EventArgs e)
        {
            txtCajaIng.Text += "9";
        }

        private void brnIng0_Click(object sender, EventArgs e)
        {
            if (txtCajaIng.Text != "0")
            {
                txtCajaIng.Text += "0";
            }
        }

        private void brnIng00_Click(object sender, EventArgs e)
        {
            if (txtCajaIng.Text != "0" && txtCajaIng.Text != string.Empty)
            {
                txtCajaIng.Text += "00";
            }
            else if (txtCajaIng.Text == string.Empty)
            {
                txtCajaIng.Text += "0";
 
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtCajaIng.Text != string.Empty)
            {
                txtCajaIng.Text = txtCajaIng.Text.Remove(txtCajaIng.Text.Length - 1, 1);
        
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            if (txtCajaIng.Text != string.Empty)
            {
                txtCajaIng.Text = string.Empty;
            }
            else
            {
                txtCajaIng.Text = "No hay nada en la caja";
            }
        }

        private void DefinirSaldo_CheckedChanged(object sender, EventArgs e)
        {
            lblAdvSaldo.Visible = false;
            AdvExceso.Visible = false;
            btnRetirar.Visible = false;
            TexIngresos.Visible = false;
            lblValIngresos.Visible = false;
            TexEgresos.Visible = false;
            lblValEgresos.Visible = false;
            Lista.Items.Clear();
            VPagoCliente.Visible = false;
            VPago.Visible = false;
            VDevuCliente.Visible = false;
            VDevu.Visible = false;
            NuevoUsuario.Sum = 0;
            DefinirSaldo.Enabled = false;
            lblPresaldo.Visible = false;
            lblTextoSaldo.Visible = false;
            IngresoPrecio1.Visible = false;
            IngresoPrecio2.Visible = false;
            Lista.Visible = false;
            btnQuitar.Visible = false;
            btnFacturar.Visible = false;
            PreTotal.Visible = false;
            PagoNoPosible.Visible = false;
            btnPagar.Visible = false;
            AdvPago.Visible = false;
            btnPagar.Visible = false;
            PreTotal.ForeColor = Color.Maroon;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            NuevoUsuario.ValorIngresado = Convert.ToDouble(txtCajaIng.Text);
            if (DefinirSaldo.Checked) // Se ingresa el saldo inicial (o de la caja)
            {
                DefinirSaldo.Checked = false;
                if (NuevoUsuario.PermitirSaldo(NuevoUsuario.ValorIngresado))
                {
                    lblAdvSaldo.Visible = false;
                    btnQuitar.Enabled = false;
                    btnFacturar.Enabled = false;
                    DefinirSaldo.Enabled = true;
                    NuevoUsuario.Saldo = NuevoUsuario.ValorIngresado;
                    lblPresaldo.Text = "$ " + NuevoUsuario.Saldo;
                    lblTextoSaldo.Visible = true;
                    lblPresaldo.Visible = true;
                    IngresoPrecio1.Visible = true;
                    IngresoPrecio2.Visible = true;
                    Lista.Visible = true;
                    Lista.Enabled = true;
                    btnQuitar.Visible = true;
                    btnFacturar.Visible = true;
                }
                else
                {
                    DefinirSaldo.Checked = true;
                    lblAdvSaldo.Text = "Saldo ingresado no válido, Intente de nuevo.";
                    lblAdvSaldo.Visible = true;
                }
            }
            else
            {
                if (PreTotal.ForeColor == Color.Maroon) //Se ingresan los valores de compra
                {
                    VPagoCliente.Visible = false;
                    VPago.Visible = false;
                    VDevuCliente.Visible = false;
                    VDevu.Visible = false;
                    PagoNoPosible.Visible = false;
                    btnPagar.Visible = false;
                    AdvPago.Visible = false;
                    NuevoUsuario.SumaProductos(NuevoUsuario.ValorIngresado);
                    Lista.Items.Add("$ " + NuevoUsuario.ValorIngresado);
                    PreTotal.Visible = true;
                    PreTotal.Text = "Total: $ " + NuevoUsuario.Sum;
                    btnQuitar.Enabled = true;
                    btnFacturar.Enabled = true;
                }
                if (PreTotal.ForeColor == Color.Aqua) // Se ingresa el valor de devuelta
                {

                    VDevuCliente.Visible = true;
                    VDevu.Text = "";
                    VDevu.Visible = true;
                    NuevoUsuario.Devuelta = NuevoUsuario.ValorIngresado - NuevoUsuario.Sum;
                    VDevu.Text = "$ " + NuevoUsuario.Devuelta;
                    VPago.Text = "$ " + NuevoUsuario.ValorIngresado;
                    NuevoUsuario.ValorPago = NuevoUsuario.ValorIngresado;
                    if ((NuevoUsuario.PosiblePago(NuevoUsuario.ValorPago) && NuevoUsuario.ValorPago >= NuevoUsuario.Sum) || NuevoUsuario.Devuelta == 0)
                    {
                        btnPagar.Visible = true;
                    }
                    else
                    {
                        AdvPago.Visible = true;
                        if (NuevoUsuario.ValorPago < NuevoUsuario.Sum)
                            PagoNoPosible.Text = "No se puede efectuar el pago.";
                        else
                            PagoNoPosible.Text = "No hay saldo suficiente para devolver.";
                        PagoNoPosible.Visible = true;
                        Lista.Enabled = true;
                        PreTotal.ForeColor = Color.Maroon;
                        btnQuitar.Enabled = true;
                        btnFacturar.Enabled = true;
                    }
                }
            }
            txtCajaIng.Text = string.Empty;
            
        }

        private void txtCajaIng_TextChanged(object sender, EventArgs e)
        {
            if (txtCajaIng.Text == String.Empty)
            {
                btnIngresar.Enabled = false;
            }
            else
            {
                btnIngresar.Enabled = true;
            }
                
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            VPagoCliente.Visible = false;
            VPago.Visible = false;
            VDevuCliente.Visible = false;
            VDevu.Visible = false;
            PagoNoPosible.Visible = false;
            btnPagar.Visible = false;
            AdvPago.Visible = false;
            btnPagar.Visible = false;
            if (!(Lista.SelectedIndex == -1))
            {
                NuevoUsuario.QuitaProductos(Convert.ToDouble(Convert.ToString(Lista.Items[Lista.SelectedIndex]).Replace("$ ", "")));
                Lista.Items.RemoveAt(Lista.SelectedIndex);
                PreTotal.Text = "Total: $ " + NuevoUsuario.Sum;
            }
            if (Lista.Items.Count == 0)
            {
                btnQuitar.Enabled = false;
                btnFacturar.Enabled = false;
                PreTotal.Visible = false;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Lista.Enabled = false;
            btnQuitar.Enabled = false;
            btnFacturar.Enabled = false;
            btnPagar.Visible = false;
            PagoNoPosible.Visible = false;
            AdvPago.Visible = false;
            PreTotal.ForeColor = Color.Aqua;
            VPago.Text = "<Ingrese el valor con el que el usuario paga>";
            VPagoCliente.Visible = true;
            VPago.Visible = true;
            VDevuCliente.Visible = false;
            VDevu.Text = "";
            VDevu.Visible = false;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            NuevoUsuario.Sum = 0;
            btnPagar.Visible = false;
            PreTotal.Text = String.Empty;
            Lista.Items.Clear();
            Lista.Enabled = true;
            VPagoCliente.Visible = false;
            VPago.Visible = false;
            VDevuCliente.Visible = false;
            VDevu.Visible = false;
            PreTotal.ForeColor = Color.Maroon;
            NuevoUsuario.EfectuarPago(NuevoUsuario.Devuelta, NuevoUsuario.ValorPago);//Egresos: Valores retirados una vez superado el tope.
            lblPresaldo.Text = "$ " + NuevoUsuario.Saldo;
            if (NuevoUsuario.Saldo > 200000)
            {
                AdvExceso.Visible = true;
                btnRetirar.Visible = true;
            }
            else
            {
                AdvExceso.Visible = false;
                btnRetirar.Visible = false;
            }
            lblValIngresos.Text = "$ " + NuevoUsuario.Ingresos;
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            AdvExceso.Visible = false;
            btnRetirar.Visible = false;
            NuevoUsuario.Egresos += NuevoUsuario.Saldo - 30000;
            NuevoUsuario.Saldo = 30000;
            lblValEgresos.Text = "$ " + NuevoUsuario.Egresos;
            lblPresaldo.Text = "$ " + NuevoUsuario.Saldo;
        }

        private void lblValIngresos_TextChanged(object sender, EventArgs e)
        {
            if (lblValIngresos.Text != String.Empty)
            {
                TexIngresos.Visible = true;
                lblValIngresos.Visible = true;
            }
            else
            {
                TexIngresos.Visible = false;
                lblValIngresos.Visible = false;
            }
        }

        private void lblValEgresos_TextChanged(object sender, EventArgs e)
        {
            if (lblValEgresos.Text != String.Empty)
            {
                TexEgresos.Visible = true;
                lblValEgresos.Visible = true;
            }
            else
            {
                TexEgresos.Visible = false;
                lblValEgresos.Visible = false;
            }
        }

        private void PreTotal_TextChanged(object sender, EventArgs e)
        {
            if (NuevoUsuario.Sum == 0)
            {
                PreTotal.Visible = false;
            }
        }








      


       




        
    }
}
