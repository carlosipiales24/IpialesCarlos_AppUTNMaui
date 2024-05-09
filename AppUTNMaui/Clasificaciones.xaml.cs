using AppUTNMaui.Models;
namespace AppUTNMaui;

public partial class Clasificaciones : ContentPage
{
    private string ApiUrl = "https://cloudcomputingapi2.azurewebsites.net/api/Clasificaciones";
    public Clasificaciones()
	{
		InitializeComponent();
	}
    private void cmdCrear_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Clasificacion>.Create(ApiUrl, new Clasificacion
        {
            Id = 0,
            Descripcion = txtClasificacion.Text
        });

        if (resultado != null)
        {
            txtIdClasificacion.Text = resultado.Id.ToString();
            // Mostrar un mensaje de �xito al usuario
            DisplayAlert("�xito", "La clasificaci�n ha sido creada correctamente.", "OK");
        }
        else
        {
            // Opcionalmente, puedes manejar la situaci�n de que resultado es null (es decir, la creaci�n fall�)
             DisplayAlert("Error", "No se pudo crear la clasificaci�n.", "OK");
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Clasificacion>.Read_ById(ApiUrl, int.Parse(txtIdClasificacion.Text));
        txtIdClasificacion.Text = resultado.Id.ToString();
        txtClasificacion.Text = resultado.Descripcion;
    }

    private void cmdActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Clasificacion>.Update(ApiUrl, int.Parse(txtIdClasificacion.Text), new Clasificacion
            {
                Id = int.Parse(txtIdClasificacion.Text),
                Descripcion = txtClasificacion.Text
            });

            // Mostrar mensaje de �xito
            DisplayAlert("�xito", "Clasificaci�n actualizada correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la actualizaci�n falle
            DisplayAlert("Error", "Ocurrio un problema para actualizar", "OK");
        }


    }

    private void cmdEliminar_Clicked(object sender, EventArgs e)
    {

        try
        {
            APIConsumer.Crud<Clasificacion>.Delete(ApiUrl, int.Parse(txtIdClasificacion.Text));
            txtIdClasificacion.Text = "";
            txtClasificacion.Text = "";
            // Mostrar mensaje de �xito
            DisplayAlert("�xito", "Clasificaci�n eliminada correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la eliminaci�n falle
            DisplayAlert("Error", "Ocurrio un problema para eliminar", "OK");
        }
    } 

        private void cmdNext_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Productos());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}