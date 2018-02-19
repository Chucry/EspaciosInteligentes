using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EspaciosInteligentes.Persistence;

namespace EspaciosInteligentes
{
    public partial class login : System.Web.UI.Page
    {
        public EIContext db;

        public login()
        {
            db = new EIContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Login1.FailureText = "No es posible iniciar sesión";

            if (db.Clients.Any(c => c.Email == Login1.UserName))
            {
                var client = db.Clients.FirstOrDefault(c => c.Email == Login1.UserName);

                if (client != null && client.Password == Login1.Password)
                {
                    Login1.FailureText = "Sesión iniciada con éxito";
                }
            }

            if (db.Employees.Any(c => c.Email == Login1.UserName))
            {
                var employee = db.Employees.FirstOrDefault(c => c.Email == Login1.UserName);

                if (employee != null && employee.Password == Login1.Password)
                {
                    Login1.FailureText = "Sesión iniciada con éxito";
                }
            }
        }
    }
}