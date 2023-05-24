using System;
using System.Web.UI;

namespace BrendonEksamen
{
    public partial class Index : System.Web.UI.Page
    {
        DBlayer dbl = new DBlayer(); // Create an instance of DBLayer

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dbl.BindGrid(); // Call BindGrid() on the dbl instance
            }
        }
        protected void ButtonSearchByElev_Click(object sender, EventArgs e)
        {
            GridViewByElev.DataSource = dbl.GetElevByNavn(TextBoxByElev.Text);
            GridViewByElev.DataBind();
        }

        protected void ButtonSearchByFag_Click(object sender, EventArgs e)
        {
            GridViewByFag.DataSource = dbl.GetElevByFag(TextBoxByFag.Text);
            GridViewByFag.DataBind();
        }
        protected void ButtonSearchByKlasse_Click(object sender, EventArgs e)
        {
            GridViewByKlasse.DataSource = dbl.GetElevByKlasse(TextBoxByKlasse.Text);
            GridViewByKlasse.DataBind();
        }

        protected void ButtonSearchByKlasseogFag_Click(object sender, EventArgs e)
        {
            GridViewByKlasseogFag.DataSource = dbl.GetElevByKlasseogFag(TextBoxByKlasseNavn.Text, TextBoxByFagNavn.Text);
            GridViewByKlasseogFag.DataBind();
        }
    }
}
