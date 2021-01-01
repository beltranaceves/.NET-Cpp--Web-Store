using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.View.ApplicationObjects;
using System;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.User
{
    public partial class UpdateClientDetails : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientDetails clientDetails =
                    SessionManager.FindClientDetails(Context);

                txtFirstName.Text = clientDetails.FirstName;
                txtFirstSurname.Text = clientDetails.FirstSurname;
                txtSecondSurname.Text = clientDetails.LastSurname;
                txtEmail.Text = clientDetails.Email;
                txtAddress.Text = clientDetails.ClientAddress;
                /* Combo box initialization */
                UpdateComboLanguage(clientDetails.ClientLanguage);
                UpdateComboCountry(clientDetails.ClientLanguage,
                    clientDetails.Country);
            }
        }

        /// <summary>
        /// Loads the languages in the comboBox in the *selectedLanguage*.
        /// Also, the selectedLanguage will appear selected in the
        /// ComboBox
        /// </summary>
        private void UpdateComboLanguage(String selectedLanguage)
        {
            this.comboLanguage.DataSource = Languages.GetLanguages(selectedLanguage);
            this.comboLanguage.DataTextField = "text";
            this.comboLanguage.DataValueField = "value";
            this.comboLanguage.DataBind();
            this.comboLanguage.SelectedValue = selectedLanguage;
        }

        /// <summary>
        /// Loads the countries in the comboBox in the *selectedLanguage*.
        /// Also, the *selectedCountry* will appear selected in the
        /// ComboBox
        /// </summary>
        private void UpdateComboCountry(String selectedLanguage, String selectedCountry)
        {
            this.comboCountry.DataSource = Countries.GetCountries(selectedLanguage);
            this.comboCountry.DataTextField = "text";
            this.comboCountry.DataValueField = "value";
            this.comboCountry.DataBind();
            this.comboCountry.SelectedValue = selectedCountry;
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance
        /// containing the event data.</param>
        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ClientDetails clientDetails =
                    new ClientDetails(txtFirstName.Text, txtFirstSurname.Text, txtSecondSurname.Text,
                        txtEmail.Text, comboLanguage.SelectedValue, txtAddress.Text,
                        comboCountry.SelectedValue, "USER");

                SessionManager.UpdateClientDetails(Context,
                    clientDetails);

                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/MainPage.aspx"));
            }
        }

        protected void ComboLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            /* After a language change, the countries are printed in the
             * correct language.
             */
            this.UpdateComboCountry(comboLanguage.SelectedValue,
                comboCountry.SelectedValue);
        }
    }
}