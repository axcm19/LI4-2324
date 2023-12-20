namespace LeiloesOnline.Business.Objects

{
    public class Administrador
    {
        // Atributos do administrador
        private string email_administrador;
        private string username;
        private string admi_password;

        public Administrador()
        {
            email_administrador = "";
            username = "";
            admi_password = "";
        }

        public Administrador(string email, string username, string pass)
        {
            email_administrador = email;
            this.username = username;
            admi_password = pass;
        }

        public Administrador(Administrador ad)
        {
            email_administrador = ad.email_administrador;
            username = ad.username;
            admi_password = ad.admi_password;
        }

        public Administrador Clone()
        {
            Administrador result = new Administrador(this);
            return result;
        }

        public string get_email_administrador()
        {
            return this.email_administrador;
        }

        public string get_username()
        {
            return this.username;
        }

        public string get_admi_password()
        {
            return this.admi_password;
        }
    }
}

/*
 CREATE TABLE Administrador(
	email_administrador VARCHAR(45) NOT NULL,
	username VARCHAR(45),
	admi_password VARCHAR(45),
	PRIMARY KEY(email_administrador)
);
 */
