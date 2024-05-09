using AppUTNMaui.Models;

namespace AppUTNMaui;

public partial class Productos : ContentPage
{
    private string ApiUrlProd = "https://cloudcomputingapi2.azurewebsites.net/api/Productos";
    public Productos()
	{
		InitializeComponent();
	}

    private void cmdCreateProd_Clicked(object sender, EventArgs e)
    {
        var prod = APIConsumer.Crud<Producto>.Create(ApiUrlProd, new Producto
        {
            Id = 0,
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (prod != null)
        {
            txtIdProducto.Text = prod.Id.ToString();
            DisplayAlert("Éxito", "El producto ha sido creada correctamente.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No se pudo crear el producto.", "OK");
        }
    }
    private void cmdLeerProd_Clicked(object sender, EventArgs e)
    {
        var prod = APIConsumer.Crud<Producto>.Read_ById(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (prod != null)
        {
            txtIdProducto.Text = prod.Id.ToString();
            txtNombreProducto.Text = prod.Nombre.ToString();
            txtExistencia.Text = prod.Existencia.ToString();
            txtPrecioUnitario.Text = prod.PrecioUnitario.ToString();
            txtIVA.Text = prod.IVA.ToString();
            txtClasificacionID.Text = prod.ClasificacionId.ToString();
        }
    }

    private void cmdUpdateProd_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Producto>.Update(ApiUrlProd, int.Parse(txtIdProducto.Text), new Producto
            {
                Id = int.Parse(txtIdProducto.Text),
                Nombre = txtNombreProducto.Text,
                Existencia = double.Parse(txtExistencia.Text),
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                IVA = double.Parse(txtIVA.Text),
                ClasificacionId = int.Parse(txtClasificacionID.Text)
            });
            // Mostrar mensaje de éxito
            DisplayAlert("Éxito", "Producto actualizado correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la actualización falle
            DisplayAlert("Error", "Ocurrio un problema para actualizar", "OK");
        }
       
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Producto>.Delete(ApiUrlProd, int.Parse(txtIdProducto.Text));
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtExistencia.Text = "";
            txtPrecioUnitario.Text = "";
            txtIVA.Text = "";
            txtClasificacionID.Text = "";
            // Mostrar mensaje de éxito
            DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la actualización falle
            DisplayAlert("Error", "Ocurrio un problema para eliminar", "OK");
        }

       
    }

    private void cmdRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clasificaciones());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}